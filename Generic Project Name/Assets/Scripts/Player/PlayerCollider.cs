using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{    
    [SerializeField] HpBar hpBar;
    PlayerStat playerStat;

    [Header("I-Frames")]
    float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    void Awake()
    {
        playerStat = FindObjectOfType<PlayerStat>();
    }

    void Update() 
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }

    public void TakeDamage(float damage)
    {        
        if(!isInvincible)
        {
            playerStat.currentHealth -= damage;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
            
            bool isCriticalHit = Random.Range(0,100) < 30;

            DamgePopup.Create(this.gameObject.transform.position, (int)damage, isCriticalHit);
            
            hpBar.SetState(playerStat.currentHealth, playerStat.characterData.MaxHp);
            
            if(playerStat.currentHealth <= 0)
            {
                playerStat.Kill();
            }
        }
    }

    public void RestoreHealth(float amount)
    {
        if (playerStat.currentHealth < playerStat.characterData.MaxHp)
        {
            playerStat.currentHealth += amount;

            if(playerStat.currentHealth > playerStat.characterData.MaxHp)
            {
                playerStat.currentHealth = playerStat.characterData.MaxHp;
            }
            hpBar.SetState(playerStat.currentHealth, playerStat.characterData.MaxHp);
        }
    }
}
