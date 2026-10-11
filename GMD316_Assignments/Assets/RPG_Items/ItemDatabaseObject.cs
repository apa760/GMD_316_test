using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Database", order = 2)]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{

    public SOItem[] items;
    [SerializeField] public Dictionary<SOItem, int> itemIdDict = new Dictionary<SOItem, int>();
    [SerializeField] public Dictionary<int, SOItem> itemIDSwap = new Dictionary<int, SOItem>();


    public void OnAfterDeserialize()
    {
        itemIdDict = new Dictionary<SOItem, int>();
        itemIDSwap = new Dictionary<int, SOItem>(); 
        for (int i = 0; i < items.Length; i++)
        {
            itemIdDict.Add(items[i], i);
            itemIDSwap.Add(i, items[i]);
        }
    }
    public void OnBeforeSerialize()
    {
        //nothing
    }


}
