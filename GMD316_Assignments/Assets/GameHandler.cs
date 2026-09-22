using UnityEngine;
using System.Collections.Generic;

public class GameHandler : MonoBehaviour
{

    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            List<InventorySlot> playerInventory = player.GetComponent<PlayerInventory>().GetPlayerInventory();
            

        }
    }
}
