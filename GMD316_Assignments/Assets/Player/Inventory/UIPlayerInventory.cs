using UnityEngine;
using System.Collections.Generic;

public class UIPlayerInventory : MonoBehaviour
{

    private PlayerInventory playerInventoryScript;

    [SerializeField] private GameObject inventorySlots;
    [SerializeField] private GameObject inventoryGFX;
    [SerializeField] private GameObject inventorySlotPrefab;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInventoryScript = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            List<InventorySlot> playerInventory = playerInventoryScript.GetPlayerInventory();

            for(int i = 0; i < playerInventory.Count; i++)
            {
                GameObject inventorySlot = Instantiate(inventorySlotPrefab);
                inventorySlot.transform.SetParent(inventorySlots.transform);
                InventorySlotUI slotUI = inventorySlot.GetComponent<InventorySlotUI>();
                slotUI.FillSlot(playerInventory[i].item, playerInventory[i].stackSize);
            }

            inventoryGFX.SetActive(!inventoryGFX.activeSelf);

            if(inventoryGFX.activeSelf == false)
            {
                for(int i = 0; i < inventorySlots.transform.childCount; i++)
                {
                    Destroy(inventorySlots.transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
