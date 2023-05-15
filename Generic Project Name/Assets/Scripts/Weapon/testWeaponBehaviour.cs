using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testWeaponBehaviour: ProjectileWeaponBehaviour
{
    testWeaponController test;
    protected override void Start()
    {
        base.Start();
        test = FindObjectOfType<testWeaponController>();
    }

    void Update()
    {
        transform.position += direction * test.speed *Time.deltaTime;
    }
}