using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public SOItem[] allItems;


    [SerializeField]
    GameObject player;



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CreateItem(player.transform.position);
        }
    }


    public void CreateItem(Vector3 ItemPos)
    {
        foreach(SOItem item in allItems)
        {
            int RandNumber = Random.Range(0, allItems.Length - 1);
            //if the key name matches the requested name to remove variable
            SOItem SelectedItem = allItems[RandNumber];
        }

    }

}
