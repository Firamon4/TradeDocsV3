using System;

namespace TradeDocsV3.Models;

public class DocumentItemModel
{
    public string Id         { get; set; } = Guid.NewGuid().ToString();
    public string DocumentId { get; set; } = string.Empty;
    public string ItemName   { get; set; } = string.Empty;
    public double Quantity   { get; set; }
    public double Price      { get; set; }
    public double Sum        => Quantity * Price;
}