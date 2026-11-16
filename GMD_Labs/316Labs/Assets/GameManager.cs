using UnityEngine; 
using UnityEngine.UI; 
using System.IO; 
public class GameManager : MonoBehaviour 
{ 
    public Text playerStatsText; 
    private PlayerData playerData; 
    
    private void Start() 
    { 
        playerData = new PlayerData(); 
        LoadPlayerData(); 
        UpdatePlayerStatsText(); 
    } 

    private void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.H)) // Increase health 
        { 
            UpdatePlayerStats(10, 0); 
        }
        
        if (Input.GetKeyDown(KeyCode.S)) // Increase score 
        { 
            UpdatePlayerStats(0, 10);
        } 
    }
    
    public void UpdatePlayerStats(float healthChange, float scoreChange) 
    { 
        playerData.health += healthChange; 
        playerData.score += scoreChange; 
        UpdatePlayerStatsText(); 
        SavePlayerData(); 
    } 
    
    private void UpdatePlayerStatsText() 
    { 
        playerStatsText.text = $"Health: {playerData.health}\nScore: {playerData.score}"; 
    } 
        
    // private void SavePlayerData() 
    // { 
    //     string json = JsonUtility.ToJson(playerData); 
    //     File.WriteAllText(Application.persistentDataPath + "/playerData.json", json); 
    // } 

    private void SavePlayerData() 
    { 
        string json = JsonUtility.ToJson(playerData); 
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json); 
        PlayerPrefs.SetFloat("PlayerHealth", playerData.health); 
        PlayerPrefs.SetFloat("PlayerScore", playerData.score); 
        PlayerPrefs.Save(); 
    }
    
    // private void LoadPlayerData() 
    // { 
    //     string path = Application.persistentDataPath + "/playerData.json"; 
    //     if (File.Exists(path)) 
    //     { 
    //         string json = File.ReadAllText(path); 
    //         playerData = JsonUtility.FromJson<PlayerData>(json); 
    //     } 
    // } 

    private void LoadPlayerData() 
    { 
        string path = Application.persistentDataPath + "/playerData.json"; 
        if (File.Exists(path)) 
        { 
            string json = File.ReadAllText(path); 
            playerData = JsonUtility.FromJson<PlayerData>(json); 
        } 
        else 
        { 
            playerData.health = PlayerPrefs.GetFloat("PlayerHealth", 100); // Default health 
            playerData.score = PlayerPrefs.GetFloat("PlayerScore", 0); // Default score 
        } 
    }

}
