using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponForge : MonoBehaviour
{
    public WeaponController weaponSlot = new WeaponController();
    public int weaponLevel = 0;

    public void AddWeapon(WeaponController newWeapon)
    {
        weaponSlot = newWeapon;
    }

    public void LevelUpWeapon()
    {
        
    }
}
