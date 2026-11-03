using UnityEngine;
using System.Collections.Generic;

public class WorldItemManager : MonoBehaviour
{
    public ItemDatabaseObject itemsDatabase;
    public SOItem[] spawnedItems;

    public GameObject itemObject;

    public SOItem newItemSO;

    public ObjectPooler pooler;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   

        newItemSO = ScriptableObject.CreateInstance<SOItem>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonUp(1))//Right Mouse button
        {
            GameObject newItemObject = pooler.GetObjectFromPool();
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);
            newItemObject.transform.position = worldPos2D;

        }
    }
}
