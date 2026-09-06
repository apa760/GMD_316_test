using UnityEngine;

public class ItemToPickUp : MonoBehaviour
{
    public SOItem itemSO;


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameObject playerObject = col.gameObject;
            playerObject.GetComponent<PlayerInventory>().AddItemToInventory(itemSO);
            Destroy(gameObject);

        }
    }
}
