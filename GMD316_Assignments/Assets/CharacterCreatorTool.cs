using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CharacterCreatorTool : EditorWindow
{
    private string characterName = "";
    private int health = 1;
    private float moveSpeed = 1.0f;

    private List<string> skills = new List<string>();
    private string newSkill = "";


    [MenuItem("Tools/Add Character")]
    public static void ShowWindow()
    {
        GetWindow<CharacterCreatorTool>("Add Character");
    }

    private void OnGUI()
    {
        GUILayout.Label("Add Character", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        characterName = EditorGUILayout.TextField("Name", characterName);
        health = EditorGUILayout.IntField("Health", health);
        moveSpeed = EditorGUILayout.FloatField("Move Speed", moveSpeed);

        EditorGUILayout.Space();

        GUILayout.Label("Skills", EditorStyles.boldLabel);

        for(int i = 0; i < skills.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            skills[i] = EditorGUILayout.TextField(skills[i]);

            if(GUILayout.Button("Remove", GUILayout.Width(70)))
            {
                skills.RemoveAt(i);
                GUIUtility.ExitGUI();
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        
        newSkill = EditorGUILayout.TextField("New Skill", newSkill);

        if(GUILayout.Button("Add", GUILayout.Width(50)))
        {
            if (!string.IsNullOrWhiteSpace(newSkill))
            {
                skills.Add(newSkill);
                newSkill = "";
            }
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        GUILayout.FlexibleSpace();
        GUI.backgroundColor = Color.blue;

        if(GUILayout.Button("Add Character", GUILayout.Height(40)))
        {
            AddCharacter();
        }
        EditorGUILayout.Space();
        if(GUILayout.Button("Update Character", GUILayout.Height(40)))
        {
            UpdateCharacter();
        }
        EditorGUILayout.Space();
        if(GUILayout.Button("Remove Character", GUILayout.Height(40)))
        {
            RemoveCharacter();
        }

        GUI.backgroundColor = Color.white;

    }

    private void AddCharacter()
    {
        if(string.IsNullOrWhiteSpace(characterName))
        {
            EditorUtility.DisplayDialog(
                "Warning: No Name Given",
                "Please enter a character name to create!",
                "OK"
            );
            return;
        }

        const string folderPath = "Assets/Characters";

        CharacterObject newCharacter = ScriptableObject.CreateInstance<CharacterObject>();

        newCharacter.characterName = characterName;
        newCharacter.health = health;
        newCharacter.moveSpeed = moveSpeed;
        newCharacter.skills = new List<string>(skills);

        string assetName = characterName.Trim();
        string assetPath = AssetDatabase.GenerateUniqueAssetPath($"{folderPath}/{assetName}.asset");

        AssetDatabase.CreateAsset(newCharacter, assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"Created {characterName}: {assetPath}");
        characterName = "";
        health = 1;
        moveSpeed = 1.0f;
        skills.Clear();
        newSkill = "";

    }

    private void UpdateCharacter()
    {
        if(string.IsNullOrWhiteSpace(characterName))
        {
            EditorUtility.DisplayDialog(
                "Warning: No Name Given",
                "Please enter the character name to update!",
                "OK"
            );
            return;
        }

        string assetPath = $"Assets/Characters/{characterName}.asset";

        CharacterObject character = AssetDatabase.LoadAssetAtPath<CharacterObject>(assetPath);

        if (character == null)
        {
            Debug.LogWarning($"Could not find character: {characterName} ");
            return;
        }

        character.characterName = characterName;
        character.health = health;
        character.moveSpeed = moveSpeed;
        character.skills = new List<string>(skills);

        EditorUtility.SetDirty(character);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"Updated {characterName}: {assetPath}");
        characterName = "";
        health = 1;
        moveSpeed = 1.0f;
        skills.Clear();
        newSkill = "";
    }

    private void RemoveCharacter()
    {
        if(string.IsNullOrWhiteSpace(characterName))
        {
            EditorUtility.DisplayDialog(
                "Warning: No Name Given",
                "Please enter the character name to remove!",
                "OK"
            );
            return;
        }
        
        string assetPath = $"Assets/Characters/{characterName}.asset";

        CharacterObject character = AssetDatabase.LoadAssetAtPath<CharacterObject>(assetPath);

        if (character == null)
        {
            Debug.LogWarning($"Could not find character: {characterName} ");
            return;
        }

        bool deleteConfirmed = EditorUtility.DisplayDialog("Remove Character",
            $"Are you sure you want to delete {characterName} object?", "Remove", "Cancel");
        
        if(!deleteConfirmed)
        {
            return;
        }
        AssetDatabase.DeleteAsset(assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"Removed and Deleted {characterName}: {assetPath}");
        characterName = "";
        health = 1;
        moveSpeed = 1.0f;
        skills.Clear();
        newSkill = "";

    }


}
