using System.Collections.Generic;

namespace TradeDocsV3.Models;

public class AppSettings
{
    public DatabaseSettings Database { get; set; } = new();
    public SecuritySettings Security { get; set; } = new();
    public SyncSettings     Sync     { get; set; } = new();
}

public class DatabaseSettings
{
    public string EncryptedMSSQL  { get; set; } = string.Empty;
    public string EncryptedSQLite { get; set; } = string.Empty;
}

public class SecuritySettings { public bool UseEncryption { get; set; } = true; }

public class SyncSettings
{
    public List<DataContextMap> Mappings { get; set; } = new();
}