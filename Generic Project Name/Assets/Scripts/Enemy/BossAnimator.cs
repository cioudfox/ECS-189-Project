using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    Animator animator;
    Transform player;
    EnemyController es;
    public LayerMask whatIsPlayer;

    public bool isInAttackRadius;
    public bool isInMovingRadius;
    bool isMovingRestored;
    public float attackRadius = 25.0f;
    public float movingRadius = 20.0f;
    public float timer;
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
        es = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        isInAttackRadius = Physics2D.OverlapCircle(transform.position,attackRadius,whatIsPlayer);
        isInMovingRadius = Physics2D.OverlapCircle(transform.position,movingRadius,whatIsPlayer);

        timer -= Time.deltaTime;
        if(timer<0)
        {
            if(isInMovingRadius && isMovingRestored)
            {
                es.SlowMoving();
                timer = 4.0f;
                isMovingRestored = false;
            }
            else
            {
                es.FastMoving();                
                timer = 0.5f;
                isMovingRestored = true;
            }            
        }

        if(isInAttackRadius)
        {
            animator.SetBool("IsAttacking",true);
            // Debug.Log("Slow moving");
        }
        else
        {
            animator.SetBool("IsAttacking",false);
            // Debug.Log("Fast moving");
        }
        Vector3  direction = (player.position - transform.position).normalized;
        // Debug.Log("x:"+direction.x);
        // Debug.Log("y:"+direction.y);
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }

    // void FixedUpdate()
    // {
    // }

    public void Die()
    {
        animator.SetBool("IsDie",true);
    }
}
