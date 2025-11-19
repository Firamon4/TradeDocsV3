using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TradeDocsV3.Models;

namespace TradeDocsV3.Data.Sync;

public class DatabaseSyncService
{
    private readonly SyncConfig _config;
    private readonly ILogger _logger;
    private const string TARGET_PRIMARY_KEY = "Id";

    public DatabaseSyncService(SyncConfig config, ILogger logger)
    {
        _config = config;
        _logger = logger;
    }

    public void Sync()
    {
        _logger.LogInformation("==== Початок синхронiзацiї ====");

        using var sourceConn = new SqlConnection(_config.SourceConnStr);
        using var targetConn = new SqliteConnection(_config.TargetConnStr);

        try { sourceConn.Open(); } catch { _logger.LogError("Помилка підключення до MSSQL (1C)"); return; }
        try { targetConn.Open(); } catch { _logger.LogError("Помилка підключення до SQLite"); return; }

        foreach (var map in _config.Mappings)
        {
            if (map.Role == DataContextRole.None) continue;

            string targetTableName = DataContextRequirements.GetTargetTableName(map.Role);
            _logger.LogInformation($"[TABLE] {targetTableName}...");

            try
            {
                // КРОК 1: Перевірка структури. Якщо змінилася - DROP & CREATE
                bool structureChanged = EnsureTargetTableStructure(targetConn, map, targetTableName);

                // КРОК 2: Синхронізація даних
                // Якщо структура змінилася, таблиця пуста, тому це буде повне завантаження
                SyncTableData(sourceConn, targetConn, map, targetTableName, structureChanged);

                _logger.LogInformation($"[OK] Завершено для {targetTableName}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ERROR] {targetTableName}: {ex.Message}");
            }
        }
        _logger.LogInformation("==== Кінець ====");
    }

    /// <summary>
    /// Перевіряє, чи відповідає таблиця налаштуванням.
    /// Якщо ні — видаляє її і створює наново.
    /// Повертає true, якщо таблиця була перестворена.
    /// </summary>
    private bool EnsureTargetTableStructure(SqliteConnection conn, DataContextMap map, string tableName)
    {
        // 1. Формуємо очікуваний список колонок (Expected)
        var expectedCols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Активні поля з маппінгу
        foreach (var f in map.Fields.Where(x => x.IsUsed)) expectedCols.Add(f.TargetField);

        // Обов'язкові поля
        foreach (var req in DataContextRequirements.GetRequiredFields(map.Role)) expectedCols.Add(req);

        // Службові
        expectedCols.Add("_LocalSyncVersion");

        // 2. Перевіряємо фактичний стан (Actual)
        var currentCols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        bool tableExists = false;

        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name=@n";
            cmd.Parameters.AddWithValue("@n", tableName);
            tableExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        if (tableExists)
        {
            using var cmdPragma = conn.CreateCommand();
            cmdPragma.CommandText = $"PRAGMA table_info(\"{tableName}\")";
            using var rdr = cmdPragma.ExecuteReader();
            while (rdr.Read()) currentCols.Add(rdr.GetString(1)); // 'name' column
        }

        // 3. Порівнюємо: Чи є різниця?
        // Різниця є, якщо кількість не співпадає АБО якщо є хоча б одна колонка, якої немає в іншому списку
        bool needRecreate = !tableExists || !expectedCols.SetEquals(currentCols);

        if (needRecreate)
        {
            if (tableExists)
            {
                _logger.LogWarning($"[SCHEMA] Структура змінилася. Видалення старої таблиці {tableName}...");
                ExecuteSql(conn, $"DROP TABLE IF EXISTS \"{tableName}\"");
            }

            // Створення нової таблиці
            var defs = new List<string>();
            foreach (var col in expectedCols)
            {
                string type = GetSqliteType(col);
                if (col.Equals(TARGET_PRIMARY_KEY, StringComparison.OrdinalIgnoreCase))
                    defs.Add($"\"{col}\" {type} PRIMARY KEY");
                else
                    defs.Add($"\"{col}\" {type}");
            }

            var sql = $"CREATE TABLE \"{tableName}\" ({string.Join(", ", defs)})";
            ExecuteSql(conn, sql);
            _logger.LogInformation($"[SCHEMA] Створена нова таблиця {tableName} з {expectedCols.Count} колонками.");
            return true; // Так, ми перестворили
        }

        return false; // Структура актуальна
    }

    private void SyncTableData(SqlConnection src, SqliteConnection trg, DataContextMap map, string tableName, bool isFullLoad)
    {
        var syncFields = map.Fields
            .Where(f => f.IsUsed && !string.IsNullOrWhiteSpace(f.SourceColumn))
            .ToList();

        if (syncFields.Count == 0) { _logger.LogWarning("[SKIP] Немає полів для синхронізації"); return; }

        var idField = syncFields.FirstOrDefault(f => f.TargetField.Equals(TARGET_PRIMARY_KEY, StringComparison.OrdinalIgnoreCase));
        if (idField == null) { _logger.LogError($"[ERROR] Немає маппінгу для ID!"); return; }

        // 1. Читаємо 1С
        var srcCols = syncFields.Select(f => f.SourceColumn).ToList();
        srcCols.Add($"CONVERT(BIGINT, {map.SourceVersionColumn}) AS VersionValue");

        var dt = new DataTable();
        using (var da = new SqlDataAdapter($"SELECT {string.Join(", ", srcCols)} FROM {map.SourceTable}", src))
            da.Fill(dt);

        // 2. Якщо це не повне перестворення, читаємо існуючі версії для порівняння
        var localVers = new Dictionary<string, long>();
        if (!isFullLoad)
        {
            using var cmd = trg.CreateCommand();
            cmd.CommandText = $"SELECT {TARGET_PRIMARY_KEY}, _LocalSyncVersion FROM {tableName}";
            using var r = cmd.ExecuteReader();
            while (r.Read()) localVers[r.GetString(0)] = r.IsDBNull(1) ? 0 : r.GetInt64(1);
        }

        // 3. Заливаємо дані
        using var trans = trg.BeginTransaction();
        int ins = 0, upd = 0, del = 0;
        var srcIds = new HashSet<string>();

        foreach (DataRow row in dt.Rows)
        {
            string id = ConvertVal(row[idField.SourceColumn])?.ToString() ?? "";
            if (string.IsNullOrEmpty(id)) continue;

            srcIds.Add(id);
            long ver = Convert.ToInt64(row["VersionValue"]);

            // Якщо це повне завантаження (isFullLoad), ми просто все вставляємо.
            // Якщо ні - перевіряємо версію.
            bool needsUpdate = isFullLoad || !localVers.TryGetValue(id, out var localVer) || localVer != ver;

            if (needsUpdate)
            {
                UpsertRow(trg, syncFields, row, ver, tableName);
                if (!isFullLoad && localVers.ContainsKey(id)) upd++; else ins++;
            }
        }

        // 4. Видаляємо зайве (тільки якщо це не повне перестворення, бо в новій таблиці видаляти нічого)
        if (!isFullLoad)
        {
            foreach (var kv in localVers)
            {
                if (!srcIds.Contains(kv.Key))
                {
                    using var cmd = trg.CreateCommand();
                    cmd.CommandText = $"DELETE FROM {tableName} WHERE {TARGET_PRIMARY_KEY}=@id";
                    cmd.Parameters.AddWithValue("@id", kv.Key);
                    cmd.ExecuteNonQuery();
                    del++;
                }
            }
        }

        trans.Commit();

        if (isFullLoad)
            _logger.LogInformation($"[DATA] Повне завантаження: {ins} записів.");
        else if (ins + upd + del > 0)
            _logger.LogInformation($"[DATA] +{ins}, ~{upd}, -{del}");
        else
            _logger.LogInformation("[DATA] Актуально.");
    }

    private void UpsertRow(SqliteConnection conn, List<FieldMap> fields, DataRow row, long ver, string table)
    {
        var cols = fields.Select(f => $"\"{f.TargetField}\"").ToList();
        cols.Add("\"_LocalSyncVersion\"");
        var paramsName = fields.Select((f, i) => "@p" + i).ToList();

        string sql = $"INSERT OR REPLACE INTO \"{table}\" ({string.Join(", ", cols)}) VALUES ({string.Join(", ", paramsName)}, @ver)";

        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        for (int i = 0; i < fields.Count; i++)
        {
            var val = ConvertVal(row[fields[i].SourceColumn]);
            cmd.Parameters.AddWithValue(paramsName[i], val ?? DBNull.Value);
        }
        cmd.Parameters.AddWithValue("@ver", ver);
        cmd.ExecuteNonQuery();
    }

    private void ExecuteSql(SqliteConnection conn, string sql)
    {
        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    private object ConvertVal(object val)
    {
        if (val == DBNull.Value) return null;
        if (val is byte[] b)
        {
            if (b.Length == 16) return new Guid(b).ToString();
            if (b.Length == 1) return b[0] == 1;
        }
        return val;
    }

    private string GetSqliteType(string col)
    {
        if (col.Equals("IsFolder", StringComparison.OrdinalIgnoreCase)) return "INTEGER";
        if (col.EndsWith("Sum") || col.EndsWith("Price")) return "REAL";
        return "TEXT";
    }
}