using UnityEngine;
using System.Collections.Generic;

public class InventoryVersionList : MonoBehaviour
{

    [SerializeField]
    private List<SOItem> playerInventory;



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            PrintPlayerInventory();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)) // remove slot 1 from inventory
        {
            Debug.Log("Tried to remove item 1 from inventory");
            RemoveItemFromInventory(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) // remove slot 2 from inventory
        {
            Debug.Log("Tried to remove item 2 from inventory");
            RemoveItemFromInventory(2);
        }

    }

    public void AddItemToInventory(SOItem item)
    {
        playerInventory.Add(item);
    }

    public void RemoveItemFromInventory(int inventoryIndexValue)
    {
        if(playerInventory[inventoryIndexValue] && playerInventory[inventoryIndexValue] != null)
        {
            playerInventory.RemoveAt(inventoryIndexValue);
        }
        else
        {
            Debug.LogError(inventoryIndexValue.ToString() + " does not have an item in inventory.");
        }
    }

    public List<SOItem> PlayerInventory()
    {
        return playerInventory;
    }

    private void PrintPlayerInventory()
    {
        int num = 1;
        Debug.Log("----------------Inventory----------------");
        //print each item from the inventory dict to the console
        foreach (SOItem item in playerInventory)
        {
            Debug.Log("Slot " + num.ToString() + " : " + item.itemName);
            num += 1;
        }

        Debug.Log("----------------BREAK----------------");
    }
}
