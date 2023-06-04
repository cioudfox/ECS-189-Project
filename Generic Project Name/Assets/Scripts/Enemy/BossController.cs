using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{    
    Transform tragetDestination;
    GameObject targetGameObject;
    
    EnemyStat enemyStat;

    Rigidbody2D rgdbd2d;

    Animator animator;

    Transform player;
    public float attackRadius = 5.0f;
    public bool isInAttackRadius;
    Vector3 direction;
    public LayerMask whatIsPlayer;


    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Start()
    {
        enemyStat = GetComponent<EnemyStat>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        tragetDestination = target.transform;
    }

    void Updata()
    {
        // isInAttackRadius = Physics2D.OverlapCircle(transform.position,attackRadius,whatIsPlayer);

        direction = (tragetDestination.position - transform.position).normalized;
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }
    void FixedUpdate()
    {
        // if(!isInAttackRadius)
        // {
            MoveChracater();
        // }
    }

    public void MoveChracater()
    {
        rgdbd2d.velocity = direction * enemyStat.currentSpeed;
    }
}
