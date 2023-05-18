using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] public GameObject productDropPrefab;

    public EnemyScriptableObject enemyData;

    float currentDamage;
    float currentSpeed;
    float currentHp;
    public float despawnDistance = 20.0f;

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

    // void Update()
    // {
    //     if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
    //     {
    //         ReturnEnemy();
    //     }
    // }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        
        bool isCriticalHit = Random.Range(0,100) < 30;

        DamgePopup.Create(this.gameObject.transform.position, (int)damage, isCriticalHit);

        
        if(currentHp <= 0)
        {
            Kill();
        }
    }


    public void Kill()
    {
        Destroy(gameObject);

        var itemDrop = (GameObject) Instantiate(productDropPrefab, this.gameObject.transform.position, Quaternion.identity);

    }
    // protected virtual void OnTriggerEnter2D(Collider2D col) 
    // {
    //     if(col.CompareTag("Player"))
    //     {
    //         PlayerStat player = col.GetComponent<EnemyStat>();
    //         player.TakeDamage(currentDamage);
    //     }
    // }

    // private void OnDestroy()
    // {
    //     EnemyWave ew = FindObjectOfType<EnemyWave>();
    //     ew.OnEnemyKilled();
    // }

    // private void ReturnEnemy()
    // {
    //     EnemyWave ew = FindObjectOfType<EnemyWave>();
    //     transform.position = player.position + ew.GenerateRandomPosition();
    // }
}
