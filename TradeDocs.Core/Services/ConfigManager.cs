using System;
using System.IO;
using System.Text.Json;
using TradeDocsV3.Models;

namespace TradeDocsV3.Services;

public static class ConfigManager
{
    // Використовуємо спільну папку ProgramData
    private static readonly string ConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TradeDocsV3");
    private static readonly string ConfigPath = Path.Combine(ConfigFolder, "appsettings.json");

    public static AppSettings Load()
    {
        EnsureConfigExists();

        try
        {
            var json = File.ReadAllText(ConfigPath);
            var settings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();

            // Розшифровка (DPAPI LocalMachine дозволяє розшифрувати і службі, і юзеру на цьому ПК)
            if (settings.Security.UseEncryption)
            {
                settings.Database.EncryptedMSSQL = SecureConfig.Decrypt(settings.Database.EncryptedMSSQL);
                settings.Database.EncryptedSQLite = SecureConfig.Decrypt(settings.Database.EncryptedSQLite);
            }

            // Якщо шляху до SQLite немає - ставимо дефолтний у тій же спільній папці
            if (string.IsNullOrWhiteSpace(settings.Database.EncryptedSQLite))
            {
                settings.Database.EncryptedSQLite = $"Data Source={Path.Combine(ConfigFolder, "local.db")}";
                Save(settings);
            }

            return settings;
        }
        catch
        {
            return new AppSettings();
        }
    }

    public static void Save(AppSettings settings)
    {
        EnsureConfigExists();

        var copy = new AppSettings
        {
            Database = new()
            {
                EncryptedMSSQL = settings.Security.UseEncryption ? SecureConfig.Encrypt(settings.Database.EncryptedMSSQL) : settings.Database.EncryptedMSSQL,
                EncryptedSQLite = settings.Security.UseEncryption ? SecureConfig.Encrypt(settings.Database.EncryptedSQLite) : settings.Database.EncryptedSQLite
            },
            Security = settings.Security,
            Sync = settings.Sync
        };

        var json = JsonSerializer.Serialize(copy, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ConfigPath, json);
    }

    private static void EnsureConfigExists()
    {
        if (!Directory.Exists(ConfigFolder))
        {
            Directory.CreateDirectory(ConfigFolder);
        }
    }
}