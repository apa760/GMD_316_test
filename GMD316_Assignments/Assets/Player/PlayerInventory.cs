using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    Dictionary<SOItem, int> inventoryDict = new Dictionary<SOItem, int>();


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            PrintPlayerInventory();
        }

        if(Input.GetKeyDown(KeyCode.G)) // remove 1 gold from inventory
        {
            Debug.Log("Tried to remove 1 gold from inventory");
            RemoveItemFromInventory("Gold", 1);
        }
        if(Input.GetKeyDown(KeyCode.T)) // remove 1 trash from inventory
        {
            Debug.Log("Tried to remove 1 trash from inventory");
            RemoveItemFromInventory("Trash", 1);
        }
        if(Input.GetKeyDown(KeyCode.B)) // remove 1 seed from inventory
        {
            Debug.Log("Tried to remove 1 seed from inventory");
            RemoveItemFromInventory("Seed", 1);
        }
    }

    public void AddItemToInventory(SOItem itemToAdd)
    {
        // if the inventory dictionary has the key already
        // then increase the value of the item by the item value variable
        if(inventoryDict.ContainsKey(itemToAdd))
        {
            inventoryDict[itemToAdd] = inventoryDict[itemToAdd] + itemToAdd.itemValue;
        }
        else // if not, add a new key to the dictionary
        {
            inventoryDict.Add(itemToAdd, itemToAdd.itemValue);
        }
        
    }

    public void RemoveItemFromInventory(string itemToRemoveName, int valueToRemove)
    {
        //check each key and value in the item inventory
        foreach(KeyValuePair<SOItem, int> item in inventoryDict)
        {
            //if the key name matches the requested name to remove variable
            if(item.Key.itemName == itemToRemoveName)
            {
                //subtract the valueToRemove from the value in the inventory
                inventoryDict[item.Key] = inventoryDict[item.Key] - valueToRemove;

                //then because dict's work slow, this anticipates if the key's value is 0 or less
                if(inventoryDict[item.Key] - valueToRemove <= 0)
                {
                    // remove the item from the inventory if 0 or less
                    inventoryDict.Remove(item.Key);
                }

                Debug.Log("Removed " + itemToRemoveName + " from player inventory!");
                return;
            }
        }
        Debug.Log(itemToRemoveName + ": Item not in inventory!");
    }

    private void PrintPlayerInventory()
    {
        //print each item from the inventory dict to the console
        foreach (KeyValuePair<SOItem, int> item in inventoryDict)
        {
            Debug.Log(item.Key.itemName + " : " + item.Value);
        }

        Debug.Log("----------------BREAK----------------");
    }

}
