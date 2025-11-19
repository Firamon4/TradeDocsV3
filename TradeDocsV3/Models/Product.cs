namespace TradeDocsV3.Models;

public class Product
{
    public string Id        { get; set; } = string.Empty;
    public string Name      { get; set; } = string.Empty;
    public string? ParentId { get; set; }
    public bool IsFolder    { get; set; }

    public override string ToString() => Name;
}