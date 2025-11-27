using System.Collections.Generic;

namespace TradeDocsV3.Models;

public class OneCTableInfo
{
    public string Name { get; set; } = "";       
    public string SQLTable { get; set; } = "";   
    public Dictionary<string, string> Fields { get; set; } = new();
}