using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public CharacterScriptableObject characterData;
    [SerializeField] HpBar hpBar;

    float currentHealth;
    float currentRecovery;
    float currentMovespeed;
    float currentMight;
    float currentProjectileSpeed;

    [Header("Experience/level")]
    public int experience;
    public int level;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;        
    }

    [Header("I-Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;
    public List<LevelRange> levelRanges;


    void Awake()
    {
        currentHealth = characterData.MaxHp;
        currentRecovery = characterData.Recovery;
        currentMovespeed = characterData.MovingSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
    }

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;
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
    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevleUpChecker();
    }

    void LevleUpChecker()
    {
        Debug.Log("Before Level: " + level + "Experience: " + experience + "Experience Cap: " + experienceCap);
        if(experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;
            Debug.Log("After Level: " + level + "Experience: " + experience + "Experience Cap: " + experienceCap);

            int experienceCapIncrease = 0;
            foreach(LevelRange range in levelRanges)
            {
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    public void TakeDamage(float damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
            
            bool isCriticalHit = Random.Range(0,100) < 30;

            DamgePopup.Create(this.gameObject.transform.position, (int)damage, isCriticalHit);
            
            // hpBar.SetState(currentHealth, characterData.MaxHp);
            
            if(currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Debug.Log("Player dead");
    }

    public void RestoreHealth(int amount)
    {
        if (currentHealth < characterData.MaxHp)
        {
            currentHealth += amount;

            if(currentHealth > characterData.MaxHp)
            {
                currentHealth = characterData.MaxHp;
            }
        }
    }
}
