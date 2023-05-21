using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] public GameObject gemPrefab;
    [SerializeField] public GameObject mushroomPrefab;
    [SerializeField] public GameObject heartPrefab;

    [SerializeField] public GameObject criticalPrefab;
    [SerializeField] public GameObject swiftPrefab;

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

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
    }

    public void TakeDamage(float damage)
    {   
        float playerCritChance = player.gameObject.GetComponent<PlayerStat>().currentCritChance;
        float realDamage;
        bool isCriticalHit = Random.Range(0,100) < playerCritChance;
        if(isCriticalHit)
        {
            realDamage = damage * 1.5f;
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

        Instantiate(gemPrefab, this.gameObject.transform.position, Quaternion.identity);
        Instantiate(mushroomPrefab, this.gameObject.transform.position, Quaternion.identity);
        Instantiate(heartPrefab, this.gameObject.transform.position, Quaternion.identity);
        Instantiate(criticalPrefab, this.gameObject.transform.position, Quaternion.identity);
        Instantiate(swiftPrefab, this.gameObject.transform.position, Quaternion.identity);

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
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        //  ew = FindObjectOfType<EnemyWave>();
        transform.position = player.position + es.GenerateRandomPosition();
    }
}
