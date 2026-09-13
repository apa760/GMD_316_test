using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Player", order = 2)]
public class PlayerSaveData : ScriptableObject
{
    [SerializeField] string playerName;
    [SerializeField] string lastPlayedTime;


    [SerializeField, HideInInspector] private byte[] encryptedInventory;


    public List<string> GetInventory()
    {
        string json = SaveDataEncryptor.Decrypt(encryptedInventory);
        return string.IsNullOrEmpty(json) ? new List<string>() : JsonUtility.FromJson<StringListWrapper>(json).items;
    }

    public bool SetInventory(List<string> items, AccessToken token)
    {
        if(!AccessController.Authorize(token, PlayerAction.ModifyInventory))
        {
            return false;
        }

        string json = JsonUtility.ToJson(new StringListWrapper {items = items});
        encryptedInventory = SaveDataEncryptor.Encrypt(json);
        return true;
    }

    [System.Serializable]
    private class StringListWrapper
    {
        public List<string> items;
    }

    public enum PlayerAction
    {
        ModifyInventory,
    }

    public readonly struct AccessToken
    {
        public readonly string UserId;
        public readonly UserRole Role;

        public AccessToken(string userId, UserRole role)
        {
            UserId = userId;
            Role = role;
        }
    }

    public enum UserRole { Guest, Player, Admin }

    public static class AccessController
    {
        public static bool Authorize(AccessToken token, PlayerAction action)
        {
            // player can modify their inventory during gameplay
            switch (action)
            {
                case PlayerAction.ModifyInventory:
                    return token.Role == UserRole.Player || token.Role == UserRole.Admin;

                default:
                    return false;
            }
        }
    }


}