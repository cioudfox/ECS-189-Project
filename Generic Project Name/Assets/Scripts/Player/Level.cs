using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Experience/level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;        
    }
    [SerializeField] ExpBar expBar;

    public List<LevelRange> levelRanges;

    void Start()
    {
        expBar.UpdateExperienceSlider(experience,experienceCap);
        expBar.SetLevelText(level);
        experienceCap = levelRanges[0].experienceCapIncrease;
    }
    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevleUpChecker();
        expBar.UpdateExperienceSlider(experience,experienceCap);
    }

    void LevleUpChecker()
    {
        if(experience >= experienceCap)
        {
            level++;
            expBar.SetLevelText(level);
            experience -= experienceCap;

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
}
