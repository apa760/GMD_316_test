using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private List<InventorySlot> playerInventory;

    WorldItemManager worldItemManager;

    void Start()
    {
        worldItemManager = GameObject.FindWithTag("GameManager").GetComponent<WorldItemManager>();
    }

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

        playerInventory.Add(new InventorySlot(_item, iQuantity, worldItemManager.itemsDatabase.itemIdDict[_item]));
        
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


    public Dictionary<int, int[]> GetSaveInventory()
    {
        //Save Data layout: Dictionary<int inventory slot number, int [] = [[0]item ID, [1]item StackSize]
        Dictionary<int, int[]> savedDict = new Dictionary<int, int[]>();

        for(int i = 0; i < playerInventory.Count; i++)
        {
            int[] slotData = new int[2];
            int itemId = playerInventory[i].ID;
            int itemStackSize = playerInventory[i].stackSize;
            slotData[0] = itemId;
            slotData[1] = itemStackSize;
            savedDict.Add(i, slotData);
        }
        return savedDict;
    }

    public void LoadInventoryData(Dictionary<int, int[]> savedData)
    {
        playerInventory = new List<InventorySlot>();
        //Save Data layout: Dictionary<int inventory slot number, int [] = [[0]item ID, [1]item StackSize]
        foreach (KeyValuePair<int,int[]> lineItem in savedData)
        {

            int _loadedItemID = lineItem.Value[0];
            int _loadedStackSize = lineItem.Value[1];

            SOItem _loadedItem = worldItemManager.itemsDatabase.itemIDSwap[_loadedItemID];
            
            playerInventory.Add(new InventorySlot(_loadedItem, _loadedStackSize, _loadedItemID));
        }
    }
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
