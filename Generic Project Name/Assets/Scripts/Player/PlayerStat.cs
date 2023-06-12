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
    public float damageMultiplier;
    public float attackSpeedMultiplier;

    [Header("I-Frames")]
    float invincibilityDuration = 0.1f;
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
    float originalWeaponDamage;
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

        spawnedWeapon(characterData.StartingWeapon);
        originalWeaponAttackSpeed = this.gameObject.GetComponentInChildren<testWeaponController>().weaponData.CooldownDuration;
        originalWeaponDamage = this.gameObject.GetComponentInChildren<testWeaponController>().weaponData.Damage;
        damageMultiplier = 1.0f;
        attackSpeedMultiplier = 1.0f;
        this.gameObject.GetComponentInChildren<testWeaponController>().weaponData.setDamageMultiplier(damageMultiplier);
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
            // this.gameObject.GetComponentInChildren<testWeaponController>().weaponCooldown = originalWeaponAttackSpeed;
        }

        if (critBuffTimer > 0)
        {
            critBuffTimer -= Time.deltaTime;
        }
        else if (critIsBuffed)
        {
            critIsBuffed = false;
            currentCritChance = characterData.CriticalChance;
            this.gameObject.GetComponentInChildren<testWeaponController>().weaponCooldown = originalWeaponAttackSpeed / attackSpeedMultiplier;
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
            // this.gameObject.GetComponentInChildren<testWeaponController>().weaponCooldown = 0.2f;
            speedBuffTimer = speedBuffTimerDuration;
            speedIsBuffed = true;
        }
    }

    public void BoostCrit(float amount)
    {
        if(!critIsBuffed)
        {
            currentCritChance *= amount;
            this.gameObject.GetComponentInChildren<testWeaponController>().weaponCooldown = originalWeaponAttackSpeed / attackSpeedMultiplier/2;
            critBuffTimer = critBuffTimerDuration;
            critIsBuffed = true;
        }
    }
    public void UpgradeHealth()
    {
        float currentHPPercentage = currentHealth/currentMaxHp;
        currentMaxHp += 10f;
        currentRecovery += 0.5f;
        currentHealth = currentMaxHp*currentHPPercentage;
        hpBar.SetState(currentHealth, currentMaxHp);
        Debug.Log("Upgrading MaxHP applied speed: " + currentMaxHp);
    }

    public void UpgradeSpeed()
    {
        currentMovespeed += 0.2f;
        Debug.Log("Upgrading Movement applied speed: " + currentMovespeed);
    }

    public void UpgradeDamage()
    {
        damageMultiplier += 0.05f;
        this.gameObject.GetComponentInChildren<testWeaponController>().weaponData.setDamageMultiplier(damageMultiplier);
        Debug.Log("Upgrading Damage by 5%");
    }

    public void UpgradeAttackSpeed()
    {
        attackSpeedMultiplier += 0.10f;
        this.gameObject.GetComponentInChildren<testWeaponController>().weaponCooldown = originalWeaponAttackSpeed / attackSpeedMultiplier;
        Debug.Log("Upgrading AttackSpeed by 10%");
    }

    public void spawnedWeapon(GameObject weapon)
    {
        Debug.Log(weapon);
        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
    }
}
