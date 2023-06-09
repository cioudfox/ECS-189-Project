using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public float coolTime = 2.0f;
    public float range = 5.0f;
    private Transform player;
    private Transform bulletPosition;
    private float timer;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
        bulletPosition = gameObject.transform;
        Debug.Log("BulletPosition: " + bulletPosition.position);
        timer = 0;
    }

    void Update()
    {
        float distance = Vector2.Distance(bulletPosition.position, player.transform.position);
        if(distance < range)
        {
            timer -= Time.deltaTime;

            if(timer < 0)
            {
                timer = coolTime;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
        EnemyController es = GetComponent<EnemyController>();
        es.StopMoving(coolTime);
        EnemyAnimator ea = GetComponent<EnemyAnimator>();
        ea.Attack(coolTime);    
    }
}
