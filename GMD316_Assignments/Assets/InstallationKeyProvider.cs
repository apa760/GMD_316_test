using UnityEngine;
using System;
using System.Security.Cryptography;

public static class InstallationKeyProvider
{
    private const string PrefsKey = "SaveKey";

    public static byte[] GetOrCreateKey()
    {
        if (PlayerPrefs.HasKey(PrefsKey))
        {
            return Convert.FromBase64String(PlayerPrefs.GetString(PrefsKey));
        }

        byte[] key = new byte[32]; // 256-bit AES key
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
        }

        PlayerPrefs.SetString(PrefsKey, Convert.ToBase64String(key));
        PlayerPrefs.Save();
        return key;
    }
}
