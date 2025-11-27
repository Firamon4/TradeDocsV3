using System;
using System.Security.Cryptography;
using System.Text;

namespace TradeDocsV3.Services;

public static class SecureConfig
{
    public static string Encrypt(string plain)
    {
        if (string.IsNullOrEmpty(plain)) return string.Empty;
        try
        {
            var data = Encoding.UTF8.GetBytes(plain);
            var protectedData = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(protectedData);
        }
        catch { return string.Empty; }
    }

    public static string Decrypt(string encrypted)
    {
        if (string.IsNullOrEmpty(encrypted)) return string.Empty;
        try
        {
            var data = Convert.FromBase64String(encrypted);
            var unprotected = ProtectedData.Unprotect(data, null, DataProtectionScope.LocalMachine);
            return Encoding.UTF8.GetString(unprotected);
        }
        catch { return string.Empty; }
    }
}