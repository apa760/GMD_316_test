using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{

    public GameObject player;

    string jsonData;

    SaveData tempSaveData;


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
        SaveData newSaveData = new SaveData();

        newSaveData.savedPosition = player.transform.position;

        PlayerStatsManager playerStatManager = player.GetComponent<PlayerStatsManager>();

        newSaveData.savedInventoryData = playerStatManager.GetSaveInventory();
        newSaveData.playerHealth = playerStatManager.playerStats.Health;
        newSaveData.playerExpPoints = playerStatManager.playerStats.ExpPoints;
        newSaveData.playerLevel = playerStatManager.playerStats.Level;

        jsonData = JsonUtility.ToJson(newSaveData);
        tempSaveData = newSaveData;
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
        //C:\Users\antho\AppData\LocalLow\DefaultCompany\GMD316_Assignments
    }

    public void LoadGame()
    {
        SaveData newLoadData = new SaveData();

        jsonData = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        JsonUtility.FromJsonOverwrite(jsonData, newLoadData);

        player.transform.position = newLoadData.savedPosition;

        PlayerStatsManager playerStatManager = player.GetComponent<PlayerStatsManager>();

        playerStatManager.LoadInventoryData(newLoadData.savedInventoryData);
        playerStatManager.playerStats.Health = newLoadData.playerHealth;
        playerStatManager.playerStats.ExpPoints = newLoadData.playerExpPoints;
        playerStatManager.playerStats.Level = newLoadData.playerLevel;
        
    }


}

public class SaveData
{
    public Vector3 savedPosition;
    [SerializeField]
    [DictionaryDisplay(keyLabel = "Item ID", valueLabel = "Inventory Stack Size")]
    public Dictionary<int, int[]> savedInventoryData;
    public int playerHealth;
    public int playerExpPoints;
    public int playerLevel;
}
