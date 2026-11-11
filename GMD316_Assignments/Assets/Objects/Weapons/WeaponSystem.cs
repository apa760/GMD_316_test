using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    public WeaponObject weaponObject;

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
            weaponObject.Fire();
        }
    }
}
