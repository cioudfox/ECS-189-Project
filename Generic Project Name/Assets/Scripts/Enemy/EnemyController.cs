using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform tragetDestination;
    GameObject targetGameObject;
    public Animator animator;
    
    // public EnemyScriptableObject enemyData;

    EnemyStat enemyStat;

    Rigidbody2D rgdbd2d;
    // Start is called before the first frame update
    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
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

    void FixedUpdate()
    {
        Vector3 direction = (tragetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * enemyStat.currentSpeed;

        var xMovement = transform.position.x - tragetDestination.position.x;
        var yMovement = transform.position.y - tragetDestination.position.y;
        animator.SetFloat("XMovement", xMovement);
        animator.SetFloat("YMovement", yMovement);
        if(Mathf.Abs(transform.position.y - tragetDestination.position.y) < 3)
        {
            animator.SetBool("Horizontal", true);
        }
        else
        {
            animator.SetBool("Horizontal", false);
        }
    }
}
