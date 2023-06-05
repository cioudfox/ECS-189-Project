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
    [SerializeField] UpgradePanelManager upgradePanel;
    public List<LevelRange> levelRanges;

    // [SerializeField] List<UpgradeScriptableObject> upgrades;
    // List<UpgradeScriptableObject> selectedUpgrades;
    // [SerializeField] List<UpgradeScriptableObject> acquiredUpgrades;

    void Start()
    {
        expBar.UpdateExperienceSlider(experience,experienceCap);
        expBar.SetLevelText(level);
        experienceCap = levelRanges[0].experienceCapIncrease;
    }
    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
        expBar.UpdateExperienceSlider(experience,experienceCap);
    }

    void LevelUpChecker()
    {
        if(experience >= experienceCap)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        // if (selectedUpgrades == null) { selectedUpgrades = new List<UpgradeScriptableObject>();}
        // selectedUpgrades.Clear();
        // selectedUpgrades.AddRange(GetUpgrade(3));

        upgradePanel.OpenMenu();
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

    // public List<UpgradeScriptableObject> GetUpgrade(int count)
    // {
    //     List<UpgradeScriptableObject> upgradeList = new List<UpgradeScriptableObject>();

    //     if(count > upgrades.Count)
    //     {
    //         count = upgrades.Count;
    //     }

    //     for (int i = 0; i < count; i++)
    //     {
    //         upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);

    //     }
        
    //     return upgradeList;
    // }

    // public void Upgrade(int selectedButtonID)
    // {
    //     if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeScriptableObject>();}
    //     UpgradeScriptableObject upgradeData = selectedUpgrades[selectedButtonID];
    //     acquiredUpgrades.Add(upgradeData);
    //     upgrades.Remove(upgradeData);
    // }
}
