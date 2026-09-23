using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public ItemDatabaseObject itemsDatabase;

    [SerializeField]
    private List<InventorySlot> playerInventory;



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            try
            {
                RemoveItemFromInventory(0, 1);
            }
            catch
            {
                Debug.LogError("Slot 1 does not have an item in inventory slot.");
            }
            
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            try
            {
                RemoveItemFromInventory(1, 1);
            }
            catch
            {
                Debug.LogError("Slot 2 does not have an item in inventory slot.");
            }
        }
    }


    public List<InventorySlot> GetPlayerInventory()
    {
        return playerInventory;
    }

    
    public void AddItemToInventory(SOItem _item)
    {
        int iQuantity = _item.quantity;
        
        for(int slotIndex = 0; slotIndex < playerInventory.Count; slotIndex++)
        {
            if(playerInventory[slotIndex].item == _item)
            {
                InventorySlot slot = playerInventory[slotIndex];

                if(playerInventory[slotIndex].item.isStackable)
                {
                    if(slot.stackSize != _item.maxStackSize)
                    {
                        while(slot.stackSize < _item.maxStackSize && iQuantity > 0)
                        {
                            slot.stackSize += 1;
                            iQuantity -= 1;
                        }
                        if(iQuantity <= 0)
                        {
                            return;
                        }
                        
                    }
                }
            }
        }

        playerInventory.Add(new InventorySlot(_item, iQuantity, itemsDatabase.itemIdDict[_item]));
        
    }

    public void RemoveItemFromInventory(int inventoryIndexValue, int _amountToRemove)
    {
        InventorySlot slot = playerInventory[inventoryIndexValue];

        if(slot != null)
        {
            if(slot.stackSize == _amountToRemove)
            {
                playerInventory.RemoveAt(inventoryIndexValue);    
                return;
            }
            else
            {
                slot.stackSize -= _amountToRemove;
            }

            
        }
        else
        {
            Debug.LogError($"{inventoryIndexValue} does not have an item in inventory slot.");
        }
    }


    // private void PrintPlayerInventory()
    // {
    //     int num = 1;
    //     Debug.Log("----------------Inventory----------------");
    //     //print each item from the inventory dict to the console
    //     foreach (SOInventorySlot slot in playerInventoryL)
    //     {
    //         Debug.Log("Slot " + num.ToString() + " : " + slot.item.itemName);
    //         num += 1;
    //     }

    //     Debug.Log("----------------BREAK----------------");
    // }
}


[System.Serializable]
public class InventorySlot
{
    public SOItem item;
    public int stackSize;
    public int ID;

    public InventorySlot(SOItem _item, int _quantity, int _id)
    {
        item = _item;
        stackSize = _quantity;
        ID = _id;
    }

}
