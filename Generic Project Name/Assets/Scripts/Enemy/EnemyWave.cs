using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTime;
    [SerializeField] GameObject player;
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota; // The total number of enemies spawned in this wave
        public float spawnInterval; //Interval between spawn times
        public int totalSpawnCount; // The number of enemies already spawned
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public GameObject enemyPrefab;
        public int enemyCount; // The number of enemy in this wave
        public int spawnCount;
    }

    public List<Wave> waves;
    public int currentWaveIndex = 0;

    [Header("Spawner Attributes")]
    float timer;
    public int enemiesAlive;
    public int maxenemiesAllowed;
    public bool isMaxEnemies;
    public float waveInterval;
    void Start()
    {
        CalculateQuata();
    }

    void Update()
    {
        if(currentWaveIndex < waves.Count && waves[currentWaveIndex].totalSpawnCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }
        timer += Time.deltaTime;
        if (timer >= waves[currentWaveIndex].spawnInterval)
        {
            timer = 0f;
            spawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if (currentWaveIndex < waves.Count -1)
        {
            currentWaveIndex++;
            CalculateQuata();
        }
    }
    void CalculateQuata()
    {
        int currentWaveQuata = 0;
        foreach(var enemyGroup in waves[currentWaveIndex].enemyGroups)
        {
            currentWaveQuata += enemyGroup.enemyCount;
        }

        waves[currentWaveIndex].waveQuota = currentWaveQuata;
        Debug.LogWarning(currentWaveQuata);
    }

    void spawnEnemies()
    {
        if (waves[currentWaveIndex].totalSpawnCount < waves[currentWaveIndex].waveQuota&& !isMaxEnemies)
        {
            foreach(var enemyGroup in waves[currentWaveIndex].enemyGroups)
            {
                if(enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    if(enemiesAlive >= maxenemiesAllowed)
                    {
                        isMaxEnemies = true;
                        return;
                    }
                    Vector3 position = GenerateRandomPosition();

                    position += player.transform.position;

                    GameObject newEnemy = Instantiate(enemyGroup.enemyPrefab, position, Quaternion.identity);
                    newEnemy.GetComponent<EnemyController>().SetTarget(player);
                    newEnemy.transform.parent = transform;

                    enemyGroup.spawnCount++;
                    waves[currentWaveIndex].totalSpawnCount++;
                    enemiesAlive++;
                }
            }
        }

        if(enemiesAlive < maxenemiesAllowed)
        {
            isMaxEnemies = false;
        }
    }
    public Vector3 GenerateRandomPosition()
    {
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        Vector3 position = new Vector3();

        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x,  spawnArea.x);
            position.y = spawnArea.y * f;   
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y,  spawnArea.y);
            position.x = spawnArea.x * f;   
        }
        // position.x = UnityEngine.Random.Range(-spawnArea.x,  spawnArea.x);
        // position.y = UnityEngine.Random.Range(-spawnArea.y,  spawnArea.y);
        position.z = 0.0f;
        return position;        
    }

    public void OnEnemyKilled()
    {
        Debug.Log("Enemy killed called!");
        enemiesAlive--;
    }
}