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
        newSaveData.savedInventoryData = player.GetComponent<PlayerInventory>().GetSaveInventory();

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

        player.GetComponent<PlayerInventory>().LoadInventoryData(newLoadData.savedInventoryData);
    }


}

public class SaveData
{
    public Vector3 savedPosition;
    [SerializeField]
    [DictionaryDisplay(keyLabel = "Item ID", valueLabel = "Inventory Stack Size")]
    public Dictionary<int, int[]> savedInventoryData;
}
