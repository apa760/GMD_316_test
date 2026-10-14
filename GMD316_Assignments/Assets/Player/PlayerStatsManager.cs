using UnityEngine;
using System.Collections.Generic;

public class PlayerStatsManager : MonoBehaviour
{
    public PlayerStatsObject playerStats;

    WorldItemManager worldItemManager;

    void Start()
    {
        worldItemManager = GameObject.FindWithTag("GameManager").GetComponent<WorldItemManager>();
        playerStats.LEVELUP.AddListener(OnLevelUp);
    }

    void Update()
    {
        HandleHotbarInputs();
        DebugInputs();
    }

    private void DebugInputs()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log($"Player health was = {playerStats.Health}");
            playerStats.Health = playerStats.Health - 1;
            Debug.Log($"Player takes 1 damage. Player health = {playerStats.Health}");
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            AddEXP(25);
            Debug.Log($"Player gained {25} exp! Player is now at {playerStats.ExpPoints}");
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            playerStats.Level = 1;
            playerStats.ExpPoints = 0;
            playerStats.Health = 5;
            playerStats.playerInventory.Clear();
            Debug.Log($"{playerStats} was reset!");
        }
        
    }

    private void HandleHotbarInputs()
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

//EXP Functions------------------------------------------------------------------------------------------
public void AddEXP(int exp)
{
    playerStats.ExpPoints += exp;
    
}

public void OnLevelUp()
{
    playerStats.Level += 1;
    Debug.Log($"Player Level Up! New Level = {playerStats.Level}");
}

// Inventory Functions ----------------------------------------------------------------------------------

    public void AddItemToInventory(SOItem _item, int _quantity)
    {
        int iQuantity = _quantity;
        
        for(int slotIndex = 0; slotIndex < playerStats.playerInventory.Count; slotIndex++)
        {
            if(playerStats.playerInventory[slotIndex].item == _item)
            {
                InventorySlot slot = playerStats.playerInventory[slotIndex];

                if(playerStats.playerInventory[slotIndex].item.isStackable)
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

        playerStats.playerInventory.Add(new InventorySlot(_item, iQuantity, worldItemManager.itemsDatabase.itemIdDict[_item]));
        
    }

    public void RemoveItemFromInventory(int inventoryIndexValue, int _amountToRemove)
    {
        InventorySlot slot = playerStats.playerInventory[inventoryIndexValue];

        if(slot != null)
        {
            if(slot.stackSize == _amountToRemove)
            {
                playerStats.playerInventory.RemoveAt(inventoryIndexValue);    
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

        for(int i = 0; i < playerStats.playerInventory.Count; i++)
        {
            int[] slotData = new int[2];
            int itemId = playerStats.playerInventory[i].ID;
            int itemStackSize = playerStats.playerInventory[i].stackSize;
            slotData[0] = itemId;
            slotData[1] = itemStackSize;
            savedDict.Add(i, slotData);
        }
        return savedDict;
    }

    public void LoadInventoryData(Dictionary<int, int[]> savedData)
    {
        playerStats.playerInventory = new List<InventorySlot>();
        //Save Data layout: Dictionary<int inventory slot number, int [] = [[0]item ID, [1]item StackSize]
        foreach (KeyValuePair<int,int[]> lineItem in savedData)
        {

            int _loadedItemID = lineItem.Value[0];
            int _loadedStackSize = lineItem.Value[1];

            SOItem _loadedItem = worldItemManager.itemsDatabase.itemIDSwap[_loadedItemID];
            
            playerStats.playerInventory.Add(new InventorySlot(_loadedItem, _loadedStackSize, _loadedItemID));
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

