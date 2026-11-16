using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectDatabase")]
public class ObjectDatabase : ScriptableObject, ISerializationCallbackReceiver
{

    public ScriptableObject[] objects;
    [SerializeField] public Dictionary<ScriptableObject, int> objectIdDict = new Dictionary<ScriptableObject, int>();
    [SerializeField] public Dictionary<int, ScriptableObject> objectIDSwap = new Dictionary<int, ScriptableObject>();


    public void OnAfterDeserialize()
    {
        objectIdDict = new Dictionary<ScriptableObject, int>();
        objectIDSwap = new Dictionary<int, ScriptableObject>(); 
        for (int i = 0; i < objects.Length; i++)
        {
            objectIdDict.Add(objects[i], i);
            objectIDSwap.Add(i, objects[i]);
        }
    }
    public void OnBeforeSerialize()
    {
        //nothing
    }


}
