using UnityEngine;

public class ItemToPickUp : MonoBehaviour
{
    public SOItem itemSO;
    public int stackSize;


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameObject playerObject = col.gameObject;
            playerObject.GetComponent<PlayerStatsManager>().AddItemToInventory(itemSO, stackSize);
            Debug.Log(itemSO.itemName + ": " + itemSO.itemDescription);
            Debug.Log("Rarity: " + itemSO.itemRarity.ToString());
            Debug.Log("Weight: " + itemSO.itemWeight.ToString());
            Debug.Log("___________________________________________________________________");
            Destroy(gameObject);

        }
    }
}
