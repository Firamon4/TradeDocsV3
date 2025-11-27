using System.Collections.Generic;

namespace TradeDocsV3.Models;

public class ServiceConfigModel
{
    public class ConnectionSettings
    {
        public string SourceDb { get; set; } = ""; 
        public string TargetDb { get; set; } = ""; 
    }

    public class TableItem
    {
        public string SourceTable { get; set; } = "";
        public string TargetTable { get; set; } = "";
        public string KeyColumn { get; set; } = "";
        public string VersionColumn { get; set; } = "";
        public bool FullSync { get; set; } = false;
    }

    public ConnectionSettings Connections { get; set; } = new();
    public List<TableItem> Tables { get; set; } = new();
    public int SyncIntervalSeconds { get; set; } = 30;
}