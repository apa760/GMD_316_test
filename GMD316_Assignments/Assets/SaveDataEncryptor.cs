using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public static class SaveDataEncryptor
{
    // In a real project, don't hardcode this...derive it from something
    // per-installation (e.g. a value generated once and stored in
    // PlayerPrefs or a protected file), so a leaked key doesn't unlock
    // every player's save.
    private const string ProjectSecret = "project-secret";
    private static readonly byte[] Salt = Encoding.UTF8.GetBytes("pinch-of-this-shit");

    public static byte[] Encrypt(string plaintext)
    {
        using Aes aes = Aes.Create();
        aes.Key = InstallationKeyProvider.GetOrCreateKey();

        using var ms = new MemoryStream();
        ms.Write(aes.IV, 0, aes.IV.Length);

        using (var encryptor = aes.CreateEncryptor())
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(plaintext);
        }

        return ms.ToArray();
    }

    public static string Decrypt(byte[] cipherBytes)
    {
        if (cipherBytes == null || cipherBytes.Length == 0) return string.Empty;

        using Aes aes = Aes.Create();
        aes.Key = InstallationKeyProvider.GetOrCreateKey();

        byte[] iv = new byte[aes.BlockSize / 8];
        Array.Copy(cipherBytes, 0, iv, 0, iv.Length);
        aes.IV = iv;

        using var ms = new MemoryStream(cipherBytes, iv.Length, cipherBytes.Length - iv.Length);
        using var decryptor = aes.CreateDecryptor();
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }
}
