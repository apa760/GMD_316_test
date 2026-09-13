using UnityEngine;
using System.Collections.Generic;

public class PlayerInteractions : MonoBehaviour
{


    private PlayerInventory pInventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pInventory =  GetComponent<PlayerInventory>();    
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) // Plant 1 seed from inventory
        {
            PlantSeed();
        }
    }

    void PlantSeed()
    {
        Debug.Log("Tried to remove 1 seed from inventory");
        foreach (KeyValuePair<SOItem, int> item in pInventory.inventoryDict)
        {
            if(item.Key.itemName == "Seed")
            {
                pInventory.RemoveItemFromInventory("Seed", 1);
                return;
            }
        }
    }


}
