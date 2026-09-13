using UnityEngine;

public class WorldItemManager : MonoBehaviour
{

    public SOItem[] ItemsAll;

    public GameObject itemObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonUp(1))//Right Mouse button
        {
            int randNum = Random.Range(0, ItemsAll.Length - 1);
            SOItem newItemSelected = ItemsAll[randNum];

            GameObject newItemObject = Instantiate(itemObject);
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);
            newItemObject.transform.position = worldPos2D;
            ItemToPickUp itemScript = newItemObject.GetComponent<ItemToPickUp>();
            itemScript.itemSO = newItemSelected;
            newItemObject.GetComponent<SpriteRenderer>().sprite = newItemSelected.icon;
            newItemObject.GetComponent<SpriteRenderer>().color = newItemSelected.color;

        }
    }
}
