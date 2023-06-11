using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rgdbd2d;
    private Animator animator;
    public float speed = 5.0f;
    public float angle;
    public float damage = 3;
    float timer;
    public bool fireball;
    Vector3 direction;
    
    void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
        rgdbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        direction = player.position - transform.position;
        rgdbd2d.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotation+angle);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            Destroy(gameObject);
        }
        if(fireball&&timer > 0.2)
        {
            animator.SetBool("initial",true);
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("impact",true);
            rgdbd2d.velocity = new Vector2(direction.x, direction.y).normalized * 0;
            yield return new WaitForSeconds(0.25f);
            PlayerStat ps = collision.gameObject.GetComponent<PlayerStat>();
            ps.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
