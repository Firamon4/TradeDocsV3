using System;

namespace TradeDocsV3.Models;

public class UserModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Login { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
    public bool IsActive { get; set; } = true;
    public string? NewPassword { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? LastLoginAt { get; set; }
}