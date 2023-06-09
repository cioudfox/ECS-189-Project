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
        if(!onReturn){
            transform.position += direction * weaponData.Speed *Time.deltaTime;
            // Debug.Log(direction);
            if (additionalProjectileCount > 1)
            {
                for (int i = 1; i < additionalProjectileCount; i++)
                {
                    ShootAdditionalProjectile(i);
                }
                additionalProjectileCount = 1;
            }
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
            if(boomerang) {
                if (distanceToPlayer > weaponData.Speed*(weaponData.Lifetime/2))
                {
                    onReturn = true;
                } 
            }
        }
        if (onReturn){
            // Move back towards the player
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
            DirectionChecker(directionToPlayer);
            transform.position += (Vector3)directionToPlayer * weaponData.Speed * Time.deltaTime;

            // Check if the projectile has reached the player
            if (Vector2.Distance(transform.position, playerTransform.position) <= 0.1f)
            {
                Destroy(gameObject);
            }
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
