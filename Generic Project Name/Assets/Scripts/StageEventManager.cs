using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageScriptableObject stageData;
    [SerializeField] EnemySpawner enemySpawner;

    StageTime stageTime;
    int eventIndex;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Update()
    {
        if (eventIndex >= stageData.stageEvents.Count) { return;}

        if (stageTime.time > stageData.stageEvents[eventIndex].time)
        {
            for (int i = 0; i < stageData.stageEvents[eventIndex].count; i++)
            {
                enemySpawner.SpawnEnemy(stageData.stageEvents[eventIndex].enemyToSpawn);
            }
            eventIndex++;
        }
    }
}
