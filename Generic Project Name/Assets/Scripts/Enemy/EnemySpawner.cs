using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTime;
    [SerializeField] GameObject player;
    float timer;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            SpawnEnemy();
            timer = spawnTime;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<EnemyController>().SetTarget(player);
    }

    private Vector3 GenerateRandomPosition()
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
}
