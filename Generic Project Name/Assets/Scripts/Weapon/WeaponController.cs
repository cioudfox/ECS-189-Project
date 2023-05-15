using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Generic Project Name;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    //public type?;

    protected PlayerMovement player;
    
    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        currentCooldown = cooldownDuration;
    }   
    
    protected virtual void Update()
    {
        currentCooldown -=  Time.deltaTime;
        if(currentCooldown <= 0f)
        {
            // Debug.Log(currentCooldown);
            Attack();
        }
    }
    protected virtual void Attack()
    {
        // Debug.Log("fire2");
        // Debug.Log(currentCooldown);
        currentCooldown = cooldownDuration;
    }
}