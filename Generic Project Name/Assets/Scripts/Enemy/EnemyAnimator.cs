using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Animator animator;
    Transform player;
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3  direction = (player.position - transform.position).normalized;
        // Debug.Log("x:"+direction.x);
        // Debug.Log("y:"+direction.y);
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
    }
}