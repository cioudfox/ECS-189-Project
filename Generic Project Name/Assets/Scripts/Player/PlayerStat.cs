using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public CharacterScriptableObject characterData;
    [SerializeField] HpBar hpBar;
    public float currentHealth;
    float currentRecovery;
    public float currentMovespeed;
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

    public List<LevelRange> levelRanges;

    float buffTimer;

    float buffTimerDuration = 5.0f;

    bool isBuffed;

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
        if (buffTimer > 0)
        {
            buffTimer -= Time.deltaTime;
        }
        else if (isBuffed)
        {
            isBuffed = false;
            currentMovespeed = characterData.MovingSpeed;
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
        if(!isBuffed)
        {
            currentMovespeed *= amount;

            buffTimer = buffTimerDuration;
            isBuffed = true;
        }
    }

}
