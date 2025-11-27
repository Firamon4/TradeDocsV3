using System;

namespace TradeDocsV3.Models;

public class DocumentModel
{
    public string   Id        { get; set; }  = Guid.NewGuid().ToString();
    public string   Type      { get; set; }  = string.Empty; // Order / Return / Income
    public string   Number    { get; set; }  = string.Empty;
    public DateTime Date      { get; set; }  = DateTime.Now;
    public string   Status    { get; set; }  = "Draft";
    public bool     Synced    { get; set; }  = false;
    public string   CreatedBy { get; set; }  = string.Empty;
    public double   TotalSum  { get; set; }
}