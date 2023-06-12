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
    private float speed;
    private float statSpeed;
    
    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        enemyStat = GetComponent<EnemyStat>();
    }

    void Start()
    {
        isRunning = true;
        statSpeed = enemyStat.currentSpeed;
        speed = enemyStat.currentSpeed;
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
        if (targetGameObject)
        {
            Vector3 direction = (tragetDestination.position - transform.position).normalized;
            if(isRunning)
            {
                rgdbd2d.velocity = direction * speed;
            }
            else
            {
                rgdbd2d.velocity = direction *0;
            }
        }
    }

    public void StopMoving(float coolTime)
    {
        timer = coolTime;
        isRunning = false;
    }

    public void SlowMoving()
    {
        speed *= 0.2f;
        Debug.Log("Spped : " + speed);
    }

    public void FastMoving()
    {
        speed = statSpeed;
        Debug.Log("Spped : " + speed);
    }
}
