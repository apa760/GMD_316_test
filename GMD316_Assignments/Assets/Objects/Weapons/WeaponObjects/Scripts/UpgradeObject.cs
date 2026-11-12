using UnityEngine;


[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/Upgrade")]
public class UpgradeObject : ScriptableObject
{
    
    public string upgradeName;
    public string upgradeDescription;
    public enum UPGRADE_TYPE
    {
        DAMAGE,
        FIRE_SPEED,
        FIRE_TYPE,
        AMMO,
        RELOAD_SPEED

        
    }
    public UPGRADE_TYPE upgradeType;
    public float upgradeValue;
        // DAMAGE - whole number value
        // FIRE_SPEED - float percentage
        // FIRE_TYPE - 
        // AMMO - whole number value
        // RELOAD_SPEED - float percentage




}
