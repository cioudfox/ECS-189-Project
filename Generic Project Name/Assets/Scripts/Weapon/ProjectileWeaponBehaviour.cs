using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    List<GameObject> markedEnemies;
    protected Transform playerTransform;
    protected float destroyAfterSeconds;
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;
    protected bool chain;
    protected bool explosive;
    protected int additionalProjectileCount;
    protected bool boomerang;
    protected bool onReturn = false;
    protected float damageMultiplier;
    protected int burstProjectileNum;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
        chain = weaponData.Chain;
        explosive = weaponData.Explosive;
        additionalProjectileCount = weaponData.ProjectileNumber;
        boomerang = weaponData.Boomerang;
        damageMultiplier = weaponData.DamageMultiplier;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        burstProjectileNum= weaponData.BurstProjectileCount;
    }
    protected virtual void Start()
    {
        markedEnemies = new List<GameObject>();
        Destroy(gameObject, weaponData.Lifetime);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.z = (float)(Atan2(direction.y, direction.x) * 180 / PI);
        transform.rotation = Quaternion.Euler(rotation);    //Can't simply set the vector because cannot convert
    }

    protected virtual void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject))
        {
            EnemyStat enemy = col.GetComponent<EnemyStat>();
            enemy.TakeDamage(currentDamage * damageMultiplier);
            markedEnemies.Add(col.gameObject);
            currentPierce -= 1;
            if(currentPierce <= 0){
                Destroy(gameObject);
            }
            if(chain)
            {
                // Find the next nearest enemy
                GameObject nextEnemy = FindNextNearestEnemy(col.transform.position);
                if (nextEnemy != null)
                {
                    Vector3 nextDirection = nextEnemy.transform.position - transform.position;
                    DirectionChecker(nextDirection.normalized);
                }
            }
            if(explosive)
            {
                Explode();
            }
        }
        
    }
    private GameObject FindNextNearestEnemy(Vector3 currentPosition)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            if (!markedEnemies.Contains(enemy))
            {
                float distance = Vector3.Distance(currentPosition, enemy.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = enemy;
                }
            }
        }
        return nearestEnemy;
    }
    private void Explode()
    {
        // Spawn smaller projectiles in a spread pattern
        float angleIncrement = 360f / burstProjectileNum;

        // Spawn smaller projectiles evenly in all directions
        for (int i = 0; i < burstProjectileNum; i++)
        {
            float angle = i * angleIncrement;
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * transform.right;
            SpawnSmallProjectile(direction);
        }

        // Destroy the original projectile
        Destroy(gameObject);
    }

    private void SpawnSmallProjectile(Vector3 direction)
    {
        GameObject smallProjectile = Instantiate(weaponData.SmallPrefab, transform.position, Quaternion.identity);
        smallProjectile.GetComponent<testWeaponBehaviour>().DirectionChecker(direction);
        // smallProjectile.SetData(weaponData.SmallPrefab);
    }

}