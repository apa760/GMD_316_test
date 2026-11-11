using UnityEngine;
using UnityEngine.UI;

public class PhudManager : MonoBehaviour
{
    private PlayerStats playerStats;
    private WeaponSystem weaponSystem;

    public Image weaponIcon;

    public GameObject heartIconPrefab;
    public GameObject healthIcons;

    public GameObject ammoIconPrefab;
    public GameObject ammoIcons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        weaponSystem = GameObject.FindWithTag("Player").GetComponent<WeaponSystem>();
        UpdatePHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdatePHUD()
    {
        if(weaponIcon != null)
        {
            weaponIcon.sprite = weaponSystem.weaponObject.weaponSprite;
            weaponIcon.preserveAspect = true;
        }
        
        for (int i = 0; i < playerStats.currentHealth; i++)
        {
            Instantiate(heartIconPrefab, healthIcons.transform);
        }
        for (int i = 0; i < weaponSystem.weaponObject.currentAmmo; i++)
        {
            Instantiate(ammoIconPrefab, ammoIcons.transform);
        }
    }
}
