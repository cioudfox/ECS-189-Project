using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testWeaponBehaviour: ProjectileWeaponBehaviour
{
    protected override void Start()
    {
        base.Start();
        
    }

    void Update()
    {
        transform.position += direction * weaponData.Speed *Time.deltaTime;
        Debug.Log(direction);
        if (additionalProjectileCount > 1)
        {
            for (int i = 1; i < additionalProjectileCount; i++)
            {
                ShootAdditionalProjectile(i);
            }
            additionalProjectileCount = 1;
        }
    }
    
    private void ShootAdditionalProjectile(int index)
    {
        GameObject spawnTestWeapon = Instantiate(weaponData.Prefab);
        spawnTestWeapon.transform.position = transform.position;
        spawnTestWeapon.GetComponent<testWeaponBehaviour>().additionalProjectileCount = 1;
        Vector3 randomDirection = Quaternion.Euler(0f, 0f, Random.Range(-10f, 10f)) * direction;
        spawnTestWeapon.GetComponent<testWeaponBehaviour>().DirectionChecker(randomDirection);
    }
}
