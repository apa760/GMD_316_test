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

        
    }
    public UPGRADE_TYPE upgradeType;
    public float upgradeValue;




}
