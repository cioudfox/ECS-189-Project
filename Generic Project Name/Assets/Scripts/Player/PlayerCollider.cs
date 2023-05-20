using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{    
    [SerializeField] HpBar hpBar;
    PlayerStat playerStat;

    [Header("I-Frames")]
    float invincibilityDuration = 0.5f;
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
            StartCoroutine(FlashObject(this.transform.parent.gameObject, 0.25f, Color.red));

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
            
            // DamgePopup.Create(this.gameObject.transform.position, (int)damage, false);
            
            playerStat.hpBar.SetState(playerStat.currentHealth, playerStat.characterData.MaxHp);
            
            if(playerStat.currentHealth <= 0)
            {
                playerStat.Kill();
            }
        }
    }

    public static IEnumerator FlashObject(GameObject obj, float flashDuration, Color c)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        Color flashColor = c;

        renderer.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        renderer.material.color = originalColor;
    }
}
