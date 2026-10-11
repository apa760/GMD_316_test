using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class SOItem : ScriptableObject

{

    public string itemName;
    public string itemDescription;
    public enum ITEM_TYPE
    {
        WEAPON,
        POTION,
        MATERIAL
    };
    public ITEM_TYPE itemType;
    public enum ITEM_RARITY
    {
      COMMON,
      UNCOMMON,
      RARE,
      LEGENDARY  
    };
    public ITEM_RARITY itemRarity;
    public int OutputValue;
    public float itemWeight;
    public bool isStackable;
    public int maxStackSize;

}
