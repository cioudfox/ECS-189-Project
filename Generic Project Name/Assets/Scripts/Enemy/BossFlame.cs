using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlame : MonoBehaviour
{
    public float damage = 15.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStat ps = collision.gameObject.GetComponent<PlayerStat>();
            ps.TakeDamage(damage);
        }
    }
}
