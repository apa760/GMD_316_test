using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class SOItem : ScriptableObject

{

    public string itemName;
    public string itemDescription;
    public bool isStackable;
    public int quantity;
    public int maxStackSize;

}
