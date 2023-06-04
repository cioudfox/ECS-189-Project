using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStat : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    public float currentDamage;
    public float currentSpeed;
    public float currentHp;
    public float despawnDistance = 10.0f;

    Transform player;

    // Update is called once per frame
    void Awake()
    {
        currentDamage = enemyData.Damage;
        currentSpeed = enemyData.Speed;
        currentHp = enemyData.MaxHp;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
        else
        {
            currentSpeed = enemyData.Speed;
        }
    }

    public void TakeDamage(float damage)
    {   
        float playerCritChance = player.gameObject.GetComponent<PlayerStat>().currentCritChance;
        float realDamage;
        bool isCriticalHit = Random.Range(0,100) < playerCritChance;
        if(isCriticalHit)
        {
            realDamage = damage * 2.0f;
        }
        else
        {
            realDamage = damage;
        }
        realDamage -= enemyData.Defence;
        if(realDamage <= 1)
        {
            currentHp -= 1;
        }
        else
        {
            currentHp -= realDamage;
        }
        
        DamgePopup.Create(this.gameObject.transform.position, (int)realDamage, isCriticalHit);
        
        if(currentHp <= 0)
        {
            Kill();
        }
    }


    public void Kill()
    {
        Destroy(gameObject);
        // Winning();
    }
    private void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            PlayerStat ps = collision2D.gameObject.GetComponent<PlayerStat>();
            ps.TakeDamage(currentDamage);
        }
    }

    private void ReturnEnemy()
    {
        currentSpeed = 5*currentSpeed;
    }
}
