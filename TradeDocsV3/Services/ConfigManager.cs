using System;
using System.IO;
using System.Text.Json;
using TradeDocsV3.Models;

namespace TradeDocsV3.Services;

public static class ConfigManager
{
    // AppContext.BaseDirectory вказує на папку bin\Debug\net8.0-windows\, а не на папку з кодом!
    private static readonly string ConfigPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

    public static AppSettings Load()
    {
        AppSettings settings;

        // 1. Намагаємося завантажити, якщо файл є
        if (File.Exists(ConfigPath))
        {
            try
            {
                var json = File.ReadAllText(ConfigPath);
                settings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
            }
            catch
            {
                settings = new AppSettings(); // Якщо файл побитий - створюємо нові
            }
        }
        else
        {
            settings = new AppSettings(); // Файлу немає - створюємо нові
        }

        // 2. Розшифровуємо (ТІЛЬКИ те, що прочитали з файлу)
        // Важливо зробити це ДО ініціалізації дефолтних значень, щоб не розшифровувати їх повторно
        if (settings.Security.UseEncryption)
        {
            // Decrypt повертає empty string, якщо вхідний рядок пустий або не зашифрований, це безпечно
            settings.Database.EncryptedMSSQL = SecureConfig.Decrypt(settings.Database.EncryptedMSSQL);
            settings.Database.EncryptedSQLite = SecureConfig.Decrypt(settings.Database.EncryptedSQLite);
        }

        // 3. Ініціалізація дефолтної бази SQLite, якщо шлях пустий
        // Цей блок тепер виконається, навіть якщо файлу не було!
        if (string.IsNullOrWhiteSpace(settings.Database.EncryptedSQLite))
        {
            var dbPath = Path.Combine(AppContext.BaseDirectory, "local.db");
            settings.Database.EncryptedSQLite = $"Data Source={dbPath}";

            // Зберігаємо дефолтні налаштування на диск (вони там зашифруються)
            Save(settings);
        }

        return settings;
    }

    public static void Save(AppSettings settings)
    {
        // Створюємо копію для збереження (шифруємо паролі)
        var copy = new AppSettings
        {
            Database = new()
            {
                EncryptedMSSQL = settings.Security.UseEncryption
                    ? SecureConfig.Encrypt(settings.Database.EncryptedMSSQL)
                    : settings.Database.EncryptedMSSQL,
                EncryptedSQLite = settings.Security.UseEncryption
                    ? SecureConfig.Encrypt(settings.Database.EncryptedSQLite)
                    : settings.Database.EncryptedSQLite
            },
            Security = settings.Security,
            Sync = settings.Sync
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(copy, options);
        File.WriteAllText(ConfigPath, json);
    }
}