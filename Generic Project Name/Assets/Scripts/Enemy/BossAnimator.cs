using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    Animator animator;
    Transform player;
    public LayerMask whatIsPlayer;

    public bool isInAttackRadius;

    public float attackRadius = 25.0f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        isInAttackRadius = Physics2D.OverlapCircle(transform.position,attackRadius,whatIsPlayer);

        if(isInAttackRadius)
        {
            animator.SetBool("IsAttacking",true);
        }
        else
        {
            animator.SetBool("IsAttacking",false);
        }
        Vector3  direction = (player.position - transform.position).normalized;
        // Debug.Log("x:"+direction.x);
        // Debug.Log("y:"+direction.y);
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }

    public void Die()
    {
        animator.SetBool("IsDie",true);
    }
}
