using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testChainWeaponBehaviour: ChainWeaponBehaviour
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        // Debug.Log(transform.position);
        transform.position += direction * weaponData.Speed *Time.deltaTime;
    }
}