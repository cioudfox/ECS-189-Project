using System.Collections;
using System.Collections.Generic;
using Player.Command;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerCommand leftMouse;
    private IPlayerCommand rightMouse;


    [SerializeField]
    public float moveSpeed;

    private Rigidbody2D body;
    private Vector2 moveDir;
    public Vector2 GetMoveDir(){return moveDir;}
    //To preserve states
    private float lastHorizontalVector;
    private float lastVerticalVector;
    private Vector2 lastMovedVector;

    public Vector2 GetLastMovedVector() 
    {
        return lastMovedVector;
    }

    public Vector2 GetMouseDirection()
    {
        Vector3 playerPosition = this.gameObject.transform.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = playerPosition.z;
        
        Vector2 direction = new Vector2(mousePosition.x - playerPosition.x, mousePosition.y - playerPosition.y);
        direction.Normalize();
        return direction;
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f); //If we don't do this and game starts up and don't move, the projectile weapon will have no momentum

        this.leftMouse = ScriptableObject.CreateInstance<ShootingTowardsMouseCommand>();
        this.rightMouse = ScriptableObject.CreateInstance<ShootingForwardCommand>();
    }

    void Update()
    {
        InputManagement();
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized; //Use normalize as moving in diagonal generates a value > 1 so cap it to 1

        if(moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);    //Last moved X
        }

        if(moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);  //Last moved Y
        }

        if(moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);    //While moving
        }




        if (Input.GetMouseButtonDown(0))
        {
            // Left mouse button was clicked
            this.leftMouse.Execute(this.gameObject);
            
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            // Right mouse button was clicked
            this.rightMouse.Execute(this.gameObject);
        }
    }

    void Move()
    {
        if (moveDir.x > 0.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveDir.x < 0.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        body.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);    //Apply velocity
    }
}