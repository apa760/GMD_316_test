using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class WeaponSystem : MonoBehaviour
{

    public WeaponObject weaponObject;
    [SerializeField] private GameObject firePoint;

    public UnityEvent GUN_FIRED;
    public UnityEvent GUN_RELOADED;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(weaponObject)
        {
            weaponObject.SetWeaponStats();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(weaponObject)
            {
                Fire();
            }
        }
    }

    public void Fire()
    {
        if(weaponObject.currentAmmo > 0)
        {
            GameObject newBullet = Instantiate(weaponObject.bulletPrefab, firePoint.transform.position, Quaternion.identity);
            weaponObject.currentAmmo -= 1;
            GUN_FIRED.Invoke();
            if(weaponObject.currentAmmo == 0)
            {
                StartCoroutine(Reload());
            }
        }

    }

    
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(weaponObject.currentReloadSpeed);
        weaponObject.currentAmmo = weaponObject.currentMaxAmmo;
        GUN_RELOADED.Invoke();
        yield break;
    }
}
