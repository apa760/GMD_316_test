#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

[CustomEditor(typeof(PlayerSaveData))]
public class PlayerSaveDataEditor : Editor
{
    private static bool unlocked;
    private string passwordInput = "";

private const string StoredPasswordHash = "12e90b8e74f20fc0a7274cff9fcbae14592db12292757f1ea0d7503d30799fd2";

    public override void OnInspectorGUI()
    {

        var data = (PlayerSaveData)target;

        if (!unlocked)
        {
            DrawDefaultInspector();
            EditorGUILayout.Space();
            
            EditorGUILayout.HelpBox("Sensitive player data is locked. Enter the tools password to edit.", MessageType.Warning);
            passwordInput = EditorGUILayout.PasswordField("Password", passwordInput);

            if (GUILayout.Button("Unlock"))
            {
                if (Hash(passwordInput) == StoredPasswordHash)
                    unlocked = true;
                else
                    Debug.LogWarning("Incorrect password.");
            }
            return;
        }

        EditorGUILayout.LabelField("Inventory (decrypted)", string.Join(", ", data.GetInventory()));
        // ...draw editable fields here that call data.SetInventory(list, adminToken)

            EditorGUILayout.Space();
            if (GUILayout.Button("Lock"))
            {
                unlocked = false;
                passwordInput = "";
            }
    }

    private static string Hash(string input)
    {
        using var sha = SHA256.Create();
        byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        var sb = new StringBuilder();
        foreach (byte b in bytes) sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
}
#endif