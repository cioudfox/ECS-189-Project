using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rgdbd2d;

    public float speed = 5.0f;
    public float angle;
    public float damage = 3;
    float timer;
    void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
        rgdbd2d = GetComponent<Rigidbody2D>();

        Vector3 direction = player.position - transform.position;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerStat ps = collision.gameObject.GetComponent<PlayerStat>();
            ps.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
