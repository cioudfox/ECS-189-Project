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

    public float currentDamage;
    public float currentSpeed;
    public float currentHp;
    public float despawnDistance = 20.0f;

    Transform player;

    public bool isThisBoss;

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
        else if(isThisBoss)
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
            FindObjectOfType<SoundManager>().PlaySoundEffect("enemyDie");
        }
    }


    public void Kill()
    {
        if(isThisBoss)
        {
            Winning();
        }
        else
        {
            Destroy(gameObject);

            float gemChance = Random.value;
            float mushroomChance = Random.value;
            float heartChance = Random.value;
            float criticalChance = Random.value;
            float swiftChance = Random.value;

            if (gemChance < 0.6f) 
                Instantiate(gemPrefab, transform.position, Quaternion.identity);

            if (mushroomChance < 0.4f) 
                Instantiate(mushroomPrefab, transform.position, Quaternion.identity);

            if (heartChance < 0.3f) 
                Instantiate(heartPrefab, transform.position, Quaternion.identity);

            if (criticalChance < 0.25f) 
                Instantiate(criticalPrefab, transform.position, Quaternion.identity);

            if (swiftChance < 0.2f) 
                Instantiate(swiftPrefab, transform.position, Quaternion.identity);            
        }

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
        if(!isThisBoss)
        {
            EnemySpawner es = FindObjectOfType<EnemySpawner>();
            transform.position = player.position + es.GenerateRandomPosition();
        }
        else
        {
            currentSpeed = 5*enemyData.Speed;
        }
    }

    public void Winning()
    {
        FindObjectOfType<BossAnimator>().Die();
        FindObjectOfType<Winning>().ShowWinning();
    }
}
