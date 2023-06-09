using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform tragetDestination;
    GameObject targetGameObject;

    // public EnemyScriptableObject enemyData;

    EnemyStat enemyStat;
    Rigidbody2D rgdbd2d;

    private bool isRunning;
    private float timer;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        enemyStat = GetComponent<EnemyStat>();
        isRunning = true;
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        tragetDestination = target.transform;
    }

    private void Update() 
    {
        if(!isRunning)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                isRunning = true;
            }
        }
    }
    void FixedUpdate()
    {
        Vector3 direction = (tragetDestination.position - transform.position).normalized;
        if(isRunning)
        {
            rgdbd2d.velocity = direction * enemyStat.currentSpeed;
        }
        else
        {
            rgdbd2d.velocity = direction *0;
        }
    }

    public void StopMoving(float coolTime)
    {
        timer = coolTime;
        isRunning = false;
    }
}
