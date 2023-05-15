using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform tragetDestination;
    GameObject targetGameObject;
    [SerializeField] float speed = 3.0f;

    Rigidbody2D rgdbd2d;
    // Start is called before the first frame update
    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = tragetDestination.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = (tragetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;       
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attack!");
        // need to arrage with the hp system.
    }
}
