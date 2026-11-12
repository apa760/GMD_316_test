using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponObject : ScriptableObject
{
    public Sprite weaponSprite;
    public string weaponName;

    [SerializeField] private int weaponDamage;
    [SerializeField] private float weaponFireSpeed;
    [SerializeField] private int weaponMaxAmmo;
    [SerializeField] private float weaponReloadSpeed;

    public List<UpgradeObject> upgrades = new List<UpgradeObject>();


    public int currentDamage;
    public float currentFireSpeed;
    public int currentAmmo;
    public int currentMaxAmmo;
    public float currentReloadSpeed;

    public GameObject bulletPrefab;

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
                        currentFireSpeed = currentFireSpeed - (currentFireSpeed * upgradeObject.upgradeValue);
                        break;
                    case UpgradeObject.UPGRADE_TYPE.FIRE_TYPE:
                        break;
                    case UpgradeObject.UPGRADE_TYPE.AMMO:
                        currentMaxAmmo = Mathf.RoundToInt(currentDamage + upgradeObject.upgradeValue);
                        break;
                    case UpgradeObject.UPGRADE_TYPE.RELOAD_SPEED:
                        currentReloadSpeed = currentReloadSpeed - (currentReloadSpeed * upgradeObject.upgradeValue);
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

}
