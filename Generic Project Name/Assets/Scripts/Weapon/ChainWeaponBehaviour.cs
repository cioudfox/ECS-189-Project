using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class ChainWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    List<GameObject> markedEnemies;
    protected float destroyAfterSeconds;
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected float currentPierce;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
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
            enemy.TakeDamage(currentDamage);
            markedEnemies.Add(col.gameObject);
            currentPierce -= 1;
            if(currentPierce <= 0){
                Destroy(gameObject);
            }
            else
            {
                // Find the next nearest enemy
                GameObject nextEnemy = FindNextNearestEnemy(col.transform.position);
                if (nextEnemy != null)
                {
                    Vector3 nextDirection = nextEnemy.transform.position - transform.position;
                    DirectionChecker(nextDirection.normalized);
                }
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
}