using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Generic Project Name;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    float currentCooldown;
    //public type?;

    protected PlayerController player;
    
    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerController>();
        currentCooldown = weaponData.CooldownDuration;
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
        currentCooldown = weaponData.CooldownDuration;
    }
}