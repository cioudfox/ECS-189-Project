using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgdbd2d;
    Vector3 movementVector;

    [SerializeField] float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();        
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        movementVector *= speed;

        rgdbd2d.velocity = movementVector;
    }
}
