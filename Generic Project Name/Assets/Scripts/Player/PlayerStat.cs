using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    CharacterScriptableObject characterData;
    [SerializeField] public HpBar hpBar;

    public float currentHealth;
    public float currentMaxHp;
    public float currentRecovery;
    public float currentMovespeed;

    [Header("I-Frames")]
    float invincibilityDuration = 0.5f;
    float invincibilityTimer;
    bool isInvincible;

    float speedBuffTimer;
    float speedBuffTimerDuration = 5.0f;
    bool speedIsBuffed;

    public float currentCritChance;
    float critBuffTimer;
    float critBuffTimerDuration = 5.0f;
    bool critIsBuffed;
    float currentRecoveryTimer;

    float originalWeaponAttackSpeed;
    
    // WeaponForge forge;
    void Awake()
    {
        characterData = CharacterSelector.getData();
        CharacterSelector.instance.DestroySingleton();

        // forge = GetComponent<WeaponForge>();

        currentHealth = characterData.MaxHp;
        currentMaxHp = characterData.MaxHp;
        currentRecovery = characterData.Recovery;
        currentMovespeed = characterData.MovingSpeed;
        currentCritChance = characterData.CriticalChance;
        originalWeaponAttackSpeed = this.gameObject.GetComponentInChildren<testWeaponController>().weaponData.CooldownDuration;
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

        if (speedBuffTimer > 0)
        {
            speedBuffTimer -= Time.deltaTime;
        }
        else if (speedIsBuffed)
        {
            speedIsBuffed = false;
            currentMovespeed = characterData.MovingSpeed;
            this.gameObject.GetComponentInChildren<testWeaponController>().weaponCooldown = originalWeaponAttackSpeed;
        }

        if (critBuffTimer > 0)
        {
            critBuffTimer -= Time.deltaTime;
        }
        else if (critIsBuffed)
        {
            critIsBuffed = false;
            currentCritChance = characterData.CriticalChance;
        }
        currentRecoveryTimer-= Time.deltaTime;
        if(currentHealth < characterData.MaxHp && 0 < currentHealth &&  currentRecoveryTimer < 0.0f){
            currentHealth += currentRecovery;
            if(currentHealth > characterData.MaxHp)
            {
                currentHealth = characterData.MaxHp;
            }
            hpBar.SetState(currentHealth, characterData.MaxHp);
            currentRecoveryTimer = 1.0f;
        }
       
    }

    public void TakeDamage(float damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;

            FindObjectOfType<SoundManager>().PlaySoundEffect("playerGetHit");


            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
            hpBar.SetState(currentHealth, currentMaxHp);
            
            StartCoroutine(PlayerController.FlashObject(this.gameObject, 0.25f, Color.red));

            if(currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        GetComponent<GameOver>().ShowGameOver();
    }

    public void RestoreHealth(float amount)
    {
        if (currentHealth < currentMaxHp)
        {
            currentHealth += amount;

            if(currentHealth > currentMaxHp)
            {
                currentHealth = currentMaxHp;
            }
            hpBar.SetState(currentHealth, currentMaxHp);
        }
    }

    public void BoostSpeed(float amount)
    {  
        if(!speedIsBuffed)
        {
            currentMovespeed *= amount;
            // Debug.Log(this.gameObject.GetComponentInChildren<testWeaponController>().weaponData.CooldownDuration);
            this.gameObject.GetComponentInChildren<testWeaponController>().weaponCooldown = 0.2f;
            speedBuffTimer = speedBuffTimerDuration;
            speedIsBuffed = true;
        }
    }

    public void BoostCrit(float amount)
    {
        if(!critIsBuffed)
        {
            currentCritChance *= amount;

            critBuffTimer = critBuffTimerDuration;
            critIsBuffed = true;
        }
    }
    public void UpgradeHealth()
    {
        currentMaxHp += 50f;
        currentHealth = currentMaxHp;
        hpBar.SetState(currentHealth, currentMaxHp);
        Debug.Log("Upgrading MaxHP applied speed: " + currentMaxHp);
    }

    public void UpgradeSpeed()
    {
        currentMovespeed += 0.2f;
        Debug.Log("Upgrading Movement applied speed: " + currentMovespeed);
    }
}
