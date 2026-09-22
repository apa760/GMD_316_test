using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Database", order = 2)]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{

    public SOItem[] items;
    [SerializeField] public Dictionary<SOItem, int> itemIdDict = new Dictionary<SOItem, int>();


    public void OnAfterDeserialize()
    {
        itemIdDict = new Dictionary<SOItem, int>();
        for (int i = 0; i < items.Length; i++)
        {
            itemIdDict.Add(items[i], i);
        }
    }
    public void OnBeforeSerialize()
    {
        //nothing
    }


}
