using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public ObjectDatabase weaponDatabase;
    public ObjectDatabase upgradeDatabase;


    public GameObject player;
    public ScoreManager scoreManager;

    string jsonData;

    SaveDataObj tempSaveData;

    private Vector2 spawnPositionPlayer = new Vector2(-22, 0);


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SaveGame();
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        SaveDataObj newSaveData = new SaveDataObj();

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        WeaponSystem weaponSystem = player.GetComponent<WeaponSystem>();

        newSaveData.savedPoints = scoreManager.currentPoints;
        newSaveData.playerHealth = playerStats.currentHealth;
        newSaveData.playerParts = playerStats.currentMechParts;

        newSaveData.playerWeaponID = weaponDatabase.objectIdDict[weaponSystem.weaponObject];

        foreach (UpgradeObject upgrade in weaponSystem.weaponObject.upgrades)
        {
            newSaveData.playerUpgradeIDs.Add(upgradeDatabase.objectIdDict[upgrade]);
        }

        jsonData = JsonUtility.ToJson(newSaveData);
        tempSaveData = newSaveData;
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
        //C:\Users\antho\AppData\LocalLow\DefaultCompany\GMD316_Assignments
    }

    public void LoadGame()
    {
        SaveDataObj newLoadData = new SaveDataObj();

        jsonData = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        JsonUtility.FromJsonOverwrite(jsonData, newLoadData);

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        WeaponSystem weaponSystem = player.GetComponent<WeaponSystem>();

        player.transform.position = spawnPositionPlayer;

        scoreManager.currentPoints = newLoadData.savedPoints;
        playerStats.currentHealth = newLoadData.playerHealth;
        playerStats.currentMechParts = newLoadData.playerParts;

        if(weaponDatabase.objectIDSwap[newLoadData.playerWeaponID] is WeaponObject weapon)
        {
            weaponSystem.weaponObject = weapon;
        }
        
        
        weaponSystem.weaponObject.upgrades.Clear();
        foreach (int upgradeID in newLoadData.playerUpgradeIDs)
        {
            if(upgradeDatabase.objectIDSwap[upgradeID] is UpgradeObject upgrade)
            {
                weaponSystem.weaponObject.upgrades.Add(upgrade);
            }
            
        }
        
        
    }


}

public class SaveDataObj
{
    public int savedPoints;
    public int playerHealth;
    public int playerParts;
    public int playerWeaponID;
    public List<int> playerUpgradeIDs = new List<int>();
    
}
