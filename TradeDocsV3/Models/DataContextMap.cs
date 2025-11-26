using System;
using System.Collections.Generic;

namespace TradeDocsV3.Models;

public class FieldMap
{
    public string TargetField { get; set; } = string.Empty;
    public string SourceColumn { get; set; } = string.Empty;
    public bool IsUsed { get; set; } = true;
}

public class DataContextMap
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DataContextRole Role { get; set; } = DataContextRole.None;
    public string Description { get; set; } = string.Empty;

    public string SourceTable { get; set; } = string.Empty;
    public string SourceVersionColumn { get; set; } = string.Empty;

    public string FilterGroups { get; set; } = string.Empty;

    public bool FullSync { get; set; } = false;

    public List<FieldMap> Fields { get; set; } = new();
}