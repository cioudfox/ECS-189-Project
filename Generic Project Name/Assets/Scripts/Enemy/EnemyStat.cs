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
        bool isCriticalHit = Random.Range(0,100) < 30;
        if(isCriticalHit)
        {
            currentHp -= (damage*1.5f);
        }
        else
        {
            currentHp -= damage;
        }
        

        DamgePopup.Create(this.gameObject.transform.position, (int)damage, isCriticalHit);

        
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
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Collider"))
        {
            PlayerCollider playerCollider = collider2D.gameObject.GetComponent<PlayerCollider>();
            playerCollider.TakeDamage(currentDamage);
        }
    }

    // private void OnDestroy()
    // {
    //     EnemyWave ew = FindObjectOfType<EnemyWave>();
    //     ew.OnEnemyKilled();
    // }

    private void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        //  ew = FindObjectOfType<EnemyWave>();
        transform.position = player.position + es.GenerateRandomPosition();
    }
}
