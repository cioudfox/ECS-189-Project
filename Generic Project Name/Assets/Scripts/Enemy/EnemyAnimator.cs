using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Animator animator;
    Transform player;
    float timer;
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            animator.SetBool("IsAttacking",false);
        }
        if (player)
        {
            Vector3  direction = (player.position - transform.position).normalized;
            // Debug.Log("x:"+direction.x);
            // Debug.Log("y:"+direction.y);
            animator.SetFloat("X", direction.x);
            animator.SetFloat("Y", direction.y);
        }
    }

    public void Attack(float coolTime)
    {
        animator.SetBool("IsAttacking",true);
        timer = coolTime;
    }
}