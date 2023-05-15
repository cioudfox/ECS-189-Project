using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTime;
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
        Vector3 position = new Vector3(
            UnityEngine.Random.Range(-spawnArea.x,  spawnArea.x),
            UnityEngine.Random.Range(-spawnArea.y,  spawnArea.y),
            0.0f
        );

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
    }
}
