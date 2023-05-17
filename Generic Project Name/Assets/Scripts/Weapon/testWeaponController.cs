using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testWeaponController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnTestWeapon = Instantiate(weaponData.Prefab);
        spawnTestWeapon.transform.position = transform.position;
        spawnTestWeapon.GetComponent<testWeaponBehaviour>().DirectionChecker(player.GetLastMovedVector());
    }
}