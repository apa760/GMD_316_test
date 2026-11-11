using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatMenu : MonoBehaviour
{
    public GameObject gfx;

    private PlayerStats playerStats;
    private WeaponSystem weaponSystem;

    public TextMeshProUGUI healthTextObj;
    public TextMeshProUGUI speedTextObj;
    public TextMeshProUGUI partsTextObj;

    public TextMeshProUGUI weaponNameTextObj;
    public GameObject upgradesNamesList;
    public GameObject upgradeNameTextObjPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        weaponSystem = GameObject.FindWithTag("Player").GetComponent<WeaponSystem>();
        SetStatData();
        SetWeaponData();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(gfx.activeSelf == false)
            {
                SetStatData();
                SetWeaponData();
                gfx.SetActive(true);
            }
            else
            {
                gfx.SetActive(false);
            }
            
        }
    }

    private void SetStatData()
    {
        if(playerStats == null)
        {
            Debug.Log("StatMenu found no PlayerStats.");
            return;
        }

        healthTextObj.text = $"Health: {playerStats.currentHealth}";
        speedTextObj.text = $"Speed: {playerStats.currentMoveSpeed}";
        partsTextObj.text = $"Parts: {playerStats.currentMechParts}";
    }

    private void SetWeaponData()
    {
        if(weaponSystem == null)
        {
            Debug.Log("StatMenu found no WeaponSystem.");
            return;
        }
        else if(weaponSystem.weaponObject == null)
        {
            Debug.Log("StatMenu found no weaponObject in SetWeaponData.");
            return;
        }

        weaponNameTextObj.text = weaponSystem.weaponObject.weaponName;

        if(upgradesNamesList.transform.childCount > 0)
        {
            for (int i = 0; i < upgradesNamesList.transform.childCount; i++)
            {
                Destroy(upgradesNamesList.transform.GetChild(i).gameObject);
            }
        }

        if(weaponSystem.weaponObject.upgrades.Count > 0)
        {
            foreach (UpgradeObject upgradeObject in weaponSystem.weaponObject.upgrades)
            {
                GameObject newTMProUGUI = Instantiate(upgradeNameTextObjPrefab, upgradesNamesList.transform);
                newTMProUGUI.GetComponent<TextMeshProUGUI>().text = upgradeObject.upgradeName;
            }
        }
    }
}
