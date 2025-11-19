using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using BCrypt.Net;
using TradeDocsV3.Models;

namespace TradeDocsV3.Data;

public class UserRepository
{
    private readonly AppSettings _settings;
    private const string TB_USERS = "TradeDocs_Users";
    private const string TB_ROLES = "TradeDocs_Roles";

    public UserRepository(AppSettings settings)
    {
        _settings = settings;
        // При створенні репозиторію гарантуємо, що локальна база готова
        InitLocal();
    }

    // --- ІНІЦІАЛІЗАЦІЯ ТАБЛИЦЬ ---

    /// <summary>
    /// Створює таблиці в локальній SQLite.
    /// </summary>
    private void InitLocal()
    {
        using var conn = new SqliteConnection(_settings.Database.EncryptedSQLite);
        conn.Open();

        // Таблиця Users
        ExecuteSqlite(conn, @"
            CREATE TABLE IF NOT EXISTS Users (
                Id TEXT PRIMARY KEY,
                Login TEXT NOT NULL UNIQUE,
                PasswordHash TEXT NOT NULL,
                Role TEXT NOT NULL,
                IsActive INTEGER NOT NULL DEFAULT 1,
                CreatedAt TEXT,
                LastLoginAt TEXT
            )");

        // Таблиця Roles
        ExecuteSqlite(conn, "CREATE TABLE IF NOT EXISTS Roles (Name TEXT PRIMARY KEY)");
        ExecuteSqlite(conn, "INSERT OR IGNORE INTO Roles (Name) VALUES ('Admin'), ('User')");

        // Дефолтний адмін (якщо немає)
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT count(*) FROM Users WHERE Login='admin'";
        if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
        {
            CreateLocalUser(conn, new UserModel { Login = "admin", Role = "Admin", IsActive = true }, BCrypt.Net.BCrypt.HashPassword("admin"));
        }
    }

    /// <summary>
    /// Спробувати створити таблиці в MSSQL (1C). Викликати при старті програми.
    /// </summary>
    public void EnsureMssqlTables()
    {
        if (!IsMssqlOnline(out var connStr)) return;

        try
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            // 1. Таблиця Roles
            string sqlRoles = $@"
                IF OBJECT_ID('{TB_ROLES}', 'U') IS NULL
                BEGIN
                    CREATE TABLE {TB_ROLES} (Name NVARCHAR(50) PRIMARY KEY);
                    INSERT INTO {TB_ROLES} VALUES ('Admin'), ('User');
                END";
            ExecuteMssql(conn, sqlRoles);

            // 2. Таблиця Users
            string sqlUsers = $@"
                IF OBJECT_ID('{TB_USERS}', 'U') IS NULL
                BEGIN
                    CREATE TABLE {TB_USERS} (
                        Id NVARCHAR(50) PRIMARY KEY,
                        Login NVARCHAR(100) NOT NULL UNIQUE,
                        PasswordHash NVARCHAR(255) NOT NULL,
                        Role NVARCHAR(50) NOT NULL,
                        IsActive BIT NOT NULL DEFAULT 1,
                        CreatedAt DATETIME DEFAULT GETDATE(),
                        LastLoginAt DATETIME NULL
                    );
                    -- Створюємо адміна, якщо таблиця нова
                    INSERT INTO {TB_USERS} (Id, Login, PasswordHash, Role, IsActive)
                    VALUES ('{Guid.NewGuid()}', 'admin', '{BCrypt.Net.BCrypt.HashPassword("admin")}', 'Admin', 1);
                END";
            ExecuteMssql(conn, sqlUsers);
        }
        catch { /* Ігноруємо помилки ініціалізації MSSQL, працюємо локально */ }
    }

    // --- ЛОГІН ---

    public bool ValidateUser(string login, string password, out string role)
    {
        role = string.Empty;

        // 1. Спроба через MSSQL (Онлайн)
        if (IsMssqlOnline(out var mssqlStr))
        {
            try
            {
                using var conn = new SqlConnection(mssqlStr);
                conn.Open();
                using var cmd = new SqlCommand($"SELECT Id, PasswordHash, Role, IsActive FROM {TB_USERS} WHERE Login=@l", conn);
                cmd.Parameters.AddWithValue("@l", login);

                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    var hash = r["PasswordHash"].ToString();
                    var isActive = (bool)r["IsActive"];

                    if (isActive && BCrypt.Net.BCrypt.Verify(password, hash))
                    {
                        role = r["Role"].ToString();
                        // Кешуємо успішний вхід локально
                        CacheUserLocal(new UserModel { Id = r["Id"].ToString(), Login = login, Role = role, IsActive = true }, hash);
                        return true;
                    }
                }
            }
            catch { /* Якщо помилка MSSQL - йдемо в локальну */ }
        }

        // 2. Спроба через SQLite (Офлайн)
        using (var conn = new SqliteConnection(_settings.Database.EncryptedSQLite))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT PasswordHash, Role FROM Users WHERE Login=@l AND IsActive=1";
            cmd.Parameters.AddWithValue("@l", login);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                if (BCrypt.Net.BCrypt.Verify(password, r.GetString(0)))
                {
                    role = r.GetString(1);
                    return true;
                }
            }
        }
        return false;
    }

    public void UpdateLastLogin(string login)
    {
        // Оновлюємо MSSQL (безпечно)
        if (IsMssqlOnline(out var mssqlStr))
        {
            try
            {
                using var c = new SqlConnection(mssqlStr);
                c.Open();
                // Перевірка чи існує таблиця, щоб не впасти з помилкою
                ExecuteMssql(c, $"IF OBJECT_ID('{TB_USERS}', 'U') IS NOT NULL UPDATE {TB_USERS} SET LastLoginAt=GETDATE() WHERE Login='{login}'");
            }
            catch { }
        }

        // Оновлюємо локально
        using var l = new SqliteConnection(_settings.Database.EncryptedSQLite);
        l.Open();
        ExecuteSqlite(l, $"UPDATE Users SET LastLoginAt=datetime('now') WHERE Login='{login}'");
    }

    // --- CRUD КОРИСТУВАЧІВ ---

    public List<UserModel> GetAllUsers()
    {
        var list = new List<UserModel>();

        // Спробуємо прочитати з MSSQL
        if (IsMssqlOnline(out var mssqlStr))
        {
            try
            {
                using var conn = new SqlConnection(mssqlStr);
                conn.Open();
                using var cmd = new SqlCommand($"SELECT Id, Login, Role, IsActive, CreatedAt, LastLoginAt FROM {TB_USERS} ORDER BY Login", conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new UserModel
                    {
                        Id = r["Id"].ToString(),
                        Login = r["Login"].ToString(),
                        Role = r["Role"].ToString(),
                        IsActive = (bool)r["IsActive"],
                        CreatedAt = r["CreatedAt"] as DateTime? ?? DateTime.MinValue,
                        LastLoginAt = r["LastLoginAt"] as DateTime?
                    });
                }
                return list; // Повернули актуальний список
            }
            catch { /* Помилка - читаємо локально */ }
        }

        // Читаємо локально (резерв)
        using (var conn = new SqliteConnection(_settings.Database.EncryptedSQLite))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Login, Role, IsActive, CreatedAt, LastLoginAt FROM Users ORDER BY Login";
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                DateTime.TryParse(r.GetString(4), out var cr);
                DateTime.TryParse(r.IsDBNull(5) ? "" : r.GetString(5), out var ll);

                list.Add(new UserModel
                {
                    Id = r.GetString(0),
                    Login = r.GetString(1),
                    Role = r.GetString(2),
                    IsActive = r.GetInt32(3) == 1,
                    CreatedAt = cr,
                    LastLoginAt = ll == DateTime.MinValue ? null : ll
                });
            }
        }
        return list;
    }

    public void SaveUser(UserModel user)
    {
        if (!IsMssqlOnline(out var mssqlStr))
            throw new Exception("Збереження можливе тільки в режимі ОНЛАЙН (потрібен доступ до MSSQL).");

        string newHash = null;

        using (var conn = new SqlConnection(mssqlStr))
        {
            conn.Open();
            // Спочатку переконаємося, що таблиця існує
            EnsureMssqlTables();

            using var cmd = conn.CreateCommand();
            string sql;

            if (!string.IsNullOrEmpty(user.NewPassword))
            {
                newHash = BCrypt.Net.BCrypt.HashPassword(user.NewPassword);
                // Update with Password
                sql = $@"
                    MERGE {TB_USERS} AS target
                    USING (SELECT @id AS Id) AS source ON (target.Id = source.Id)
                    WHEN MATCHED THEN
                        UPDATE SET Login=@l, Role=@r, IsActive=@a, PasswordHash=@h
                    WHEN NOT MATCHED THEN
                        INSERT (Id, Login, Role, IsActive, PasswordHash, CreatedAt) VALUES (@id, @l, @r, @a, @h, GETDATE());";
                cmd.Parameters.AddWithValue("@h", newHash);
            }
            else
            {
                // Update without Password
                var defHash = BCrypt.Net.BCrypt.HashPassword("12345");
                sql = $@"
                    MERGE {TB_USERS} AS target
                    USING (SELECT @id AS Id) AS source ON (target.Id = source.Id)
                    WHEN MATCHED THEN
                        UPDATE SET Login=@l, Role=@r, IsActive=@a
                    WHEN NOT MATCHED THEN
                        INSERT (Id, Login, Role, IsActive, PasswordHash, CreatedAt) VALUES (@id, @l, @r, @a, '{defHash}', GETDATE());";
            }

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", user.Id);
            cmd.Parameters.AddWithValue("@l", user.Login);
            cmd.Parameters.AddWithValue("@r", user.Role);
            cmd.Parameters.AddWithValue("@a", user.IsActive);
            cmd.ExecuteNonQuery();
        }

        // Якщо ми знаємо хеш (змінювали пароль), оновимо кеш
        if (newHash != null) CacheUserLocal(user, newHash);
    }

    public void DeleteUser(string id)
    {
        if (!IsMssqlOnline(out var s)) throw new Exception("Видалення тільки онлайн.");

        // Del MSSQL
        using (var c = new SqlConnection(s)) { c.Open(); ExecuteMssql(c, $"DELETE FROM {TB_USERS} WHERE Id='{id}'"); }
        // Del Local
        using (var l = new SqliteConnection(_settings.Database.EncryptedSQLite)) { l.Open(); ExecuteSqlite(l, $"DELETE FROM Users WHERE Id='{id}'"); }
    }

    // --- РОЛІ ---

    public List<string> GetRoles()
    {
        var list = new List<string>();
        // Читаємо з локальної для швидкості
        using var l = new SqliteConnection(_settings.Database.EncryptedSQLite);
        l.Open();
        using var r = new SqliteCommand("SELECT Name FROM Roles ORDER BY Name", l).ExecuteReader();
        while (r.Read()) list.Add(r.GetString(0));
        return list;
    }

    public void AddRole(string role)
    {
        // Add MSSQL
        if (IsMssqlOnline(out var s))
        {
            using var c = new SqlConnection(s); c.Open();
            ExecuteMssql(c, $"IF NOT EXISTS (SELECT 1 FROM {TB_ROLES} WHERE Name='{role}') INSERT INTO {TB_ROLES} VALUES ('{role}')");
        }
        // Add Local
        using var l = new SqliteConnection(_settings.Database.EncryptedSQLite); l.Open();
        ExecuteSqlite(l, $"INSERT OR IGNORE INTO Roles (Name) VALUES ('{role}')");
    }

    // --- Helpers ---

    private bool IsMssqlOnline(out string connStr)
    {
        connStr = _settings.Database.EncryptedMSSQL;
        if (string.IsNullOrWhiteSpace(connStr)) return false;
        try { using var c = new SqlConnection(connStr); c.Open(); return true; } catch { return false; }
    }

    private void CacheUserLocal(UserModel u, string hash)
    {
        using var l = new SqliteConnection(_settings.Database.EncryptedSQLite);
        l.Open();
        CreateLocalUser(l, u, hash);
    }

    private void CreateLocalUser(SqliteConnection conn, UserModel u, string hash)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT OR REPLACE INTO Users (Id, Login, Role, IsActive, PasswordHash, CreatedAt) VALUES (@id, @l, @r, @a, @h, @c)";
        cmd.Parameters.AddWithValue("@id", u.Id);
        cmd.Parameters.AddWithValue("@l", u.Login);
        cmd.Parameters.AddWithValue("@r", u.Role);
        cmd.Parameters.AddWithValue("@a", u.IsActive ? 1 : 0);
        cmd.Parameters.AddWithValue("@h", hash);
        cmd.Parameters.AddWithValue("@c", u.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.ExecuteNonQuery();
    }

    private void ExecuteSqlite(SqliteConnection c, string sql) { using var cmd = c.CreateCommand(); cmd.CommandText = sql; cmd.ExecuteNonQuery(); }
    private void ExecuteMssql(SqlConnection c, string sql) { using var cmd = c.CreateCommand(); cmd.CommandText = sql; cmd.ExecuteNonQuery(); }
}