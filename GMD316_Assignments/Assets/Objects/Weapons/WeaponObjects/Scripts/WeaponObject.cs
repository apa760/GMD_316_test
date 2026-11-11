using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponObject : ScriptableObject
{
    public Sprite weaponSprite;
    public string weaponName;

    public int weaponDamage;
    public float weaponFireSpeed;
    public int weaponMaxAmmo;

    public List<UpgradeObject> upgrades = new List<UpgradeObject>();


    public int currentDamage;
    public float currentFireSpeed;
    public int currentAmmo;
    public int currentMaxAmmo;



    public void AddUpgrade(UpgradeObject upgrade)
    {
        upgrades.Add(upgrade);
        Debug.Log($"Added Upgrade: {upgrade.upgradeName}");
        SetWeaponStats();
    }

    public void SetWeaponStats()
    {
        currentDamage = weaponDamage;
        currentFireSpeed = weaponFireSpeed;
        currentMaxAmmo = weaponMaxAmmo;
        currentAmmo = currentMaxAmmo;

        if(upgrades.Count > 0)
        {
            foreach (UpgradeObject upgradeObject in upgrades)
            {
                switch (upgradeObject.upgradeType)
                {
                    case UpgradeObject.UPGRADE_TYPE.DAMAGE:
                        currentDamage = Mathf.RoundToInt(currentDamage + upgradeObject.upgradeValue);
                        break;
                    case UpgradeObject.UPGRADE_TYPE.FIRE_SPEED:
                        break;
                    case UpgradeObject.UPGRADE_TYPE.FIRE_TYPE:
                        break;
                    case UpgradeObject.UPGRADE_TYPE.AMMO:
                        currentMaxAmmo = Mathf.RoundToInt(currentDamage + upgradeObject.upgradeValue);
                        break;
                    default:
                        Debug.Log($"SetWeaponStats switch case didnt match: {upgradeObject.upgradeType}");
                        break;
                }
            }
        }

        Debug.Log($"Current Damage: {currentDamage}");
        Debug.Log($"Current Fire Speed: {currentFireSpeed}");

    }


    public void Fire()
    {

    }



}
