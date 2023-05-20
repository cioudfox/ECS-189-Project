using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public CharacterScriptableObject characterData;
    [SerializeField] public HpBar hpBar;
    public float currentHealth;
    float currentRecovery;
    public float currentMovespeed;
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

    public List<LevelRange> levelRanges;

    float speedBuffTimer;

    float speedBuffTimerDuration = 5.0f;

    bool speedIsBuffed;

//  ###################################################################################################3
    public float currentCritChance;
//  ###################################################################################################3

    float critBuffTimer;

    float critBuffTimerDuration = 5.0f;

    bool critIsBuffed;

    void Awake()
    {
        currentHealth = characterData.MaxHp;
        currentRecovery = characterData.Recovery;
        currentMovespeed = characterData.MovingSpeed;
        currentCritChance = characterData.CriticalChance;
    }

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    void Update()
    {
        if (speedBuffTimer > 0)
        {
            speedBuffTimer -= Time.deltaTime;
        }
        else if (speedIsBuffed)
        {
            speedIsBuffed = false;
            currentMovespeed = characterData.MovingSpeed;
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

    public void Kill()
    {
        Debug.Log("Player dead");
    }

    public void RestoreHealth(float amount)
    {
        if (currentHealth < characterData.MaxHp)
        {
            currentHealth += amount;

            if(currentHealth > characterData.MaxHp)
            {
                currentHealth = characterData.MaxHp;
            }
            hpBar.SetState(currentHealth, characterData.MaxHp);
        }
    }

    public void BoostSpeed(float amount)
    {  
        if(!speedIsBuffed)
        {
            currentMovespeed *= amount;

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

}
