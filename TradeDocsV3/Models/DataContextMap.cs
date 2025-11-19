using System;
using System.Collections.Generic;

namespace TradeDocsV3.Models;

public class FieldMap
{
    public string TargetField { get; set; } = string.Empty;  // Назва в програмі (напр. "Article")
    public string SourceColumn { get; set; } = string.Empty; // Назва в 1С (напр. "_Code")
    public bool IsUsed { get; set; } = true;                 // Чи використовувати?
}

public class DataContextMap
{
    public Guid Id              { get; set; } = Guid.NewGuid();
    public DataContextRole Role { get; set; } = DataContextRole.None;
    public string Description   { get; set; } = string.Empty;

    // Джерело (1C)
    public string SourceTable         { get; set; } = string.Empty;
    public string SourceVersionColumn { get; set; } = string.Empty;

    // Маппінг: ЧистеПоле -> Колонка1С
    public List<FieldMap> Fields { get; set; } = new();
}