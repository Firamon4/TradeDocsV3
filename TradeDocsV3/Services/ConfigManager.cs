using System;
using System.IO;
using System.Text.Json;
using TradeDocsV3.Models;

namespace TradeDocsV3.Services;

public static class ConfigManager
{
    private static readonly string ConfigPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

    public static AppSettings Load()
    {
        AppSettings settings;
        if (File.Exists(ConfigPath))
        {
            try
            {
                var json = File.ReadAllText(ConfigPath);
                settings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
            }
            catch { settings = new AppSettings(); }
        }
        else { settings = new AppSettings(); }

        if (settings.Security.UseEncryption)
        {
            settings.Database.EncryptedMSSQL = SecureConfig.Decrypt(settings.Database.EncryptedMSSQL);
            settings.Database.EncryptedSQLite = SecureConfig.Decrypt(settings.Database.EncryptedSQLite);
        }

        if (string.IsNullOrWhiteSpace(settings.Database.EncryptedSQLite))
        {
            var dbPath = Path.Combine(AppContext.BaseDirectory, "local.db");
            settings.Database.EncryptedSQLite = $"Data Source={dbPath}";
            Save(settings);
        }
        return settings;
    }

    public static void Save(AppSettings settings)
    {
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
}