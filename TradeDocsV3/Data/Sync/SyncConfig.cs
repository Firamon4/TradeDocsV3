using System.Collections.Generic;
using TradeDocsV3.Models;

namespace TradeDocsV3.Data.Sync;

public class SyncConfig
{
    public string SourceConnStr { get; set; } = string.Empty;
    public string TargetConnStr { get; set; } = string.Empty;

    public List<DataContextMap> Mappings { get; set; } = new();
}