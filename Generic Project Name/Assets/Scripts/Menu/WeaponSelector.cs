using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public static WeaponSelector instance;
    public WeaponScriptableObject weaponData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);   
        }
        else
        {
            Debug.LogWarning("Extra" + this + " Deleted");
            Destroy(gameObject);
        }
    }

    public static WeaponScriptableObject getData()
    {
        return instance.weaponData;
    }

    public void SelectWeapon(WeaponScriptableObject weapon)
    {
        weaponData = weapon;
    }

    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
