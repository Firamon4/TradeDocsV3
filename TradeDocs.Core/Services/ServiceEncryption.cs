using System;
using System.IO;
using System.Security.Cryptography;

namespace TradeDocsV3.Services;

public static class ServiceEncryption
{
    private static byte[] LoadKey(string serviceDir)
    {
        string keyPath = Path.Combine(serviceDir, "secret.key");
        if (File.Exists(keyPath)) return File.ReadAllBytes(keyPath);

        using var aes = Aes.Create();
        aes.KeySize = 256;
        aes.GenerateKey();
        File.WriteAllBytes(keyPath, aes.Key);
        return aes.Key;
    }

    public static string Encrypt(string plainText, string serviceDir)
    {
        if (string.IsNullOrEmpty(plainText)) return "";

        using var aes = Aes.Create();
        aes.Key = LoadKey(serviceDir);
        aes.GenerateIV();

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        ms.Write(aes.IV, 0, aes.IV.Length);
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(plainText);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    public static string Decrypt(string cipherText, string serviceDir)
    {
        if (string.IsNullOrEmpty(cipherText)) return "";

        try
        {
            var fullCipher = Convert.FromBase64String(cipherText);
            using var aes = Aes.Create();
            aes.Key = LoadKey(serviceDir);

            var iv = new byte[16];
            Array.Copy(fullCipher, iv, iv.Length);
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(fullCipher, 16, fullCipher.Length - 16);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
        catch { return ""; }
    }
}