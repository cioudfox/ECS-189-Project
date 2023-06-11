using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
    {
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    // [SerializeField] List<UpgradeScriptableObject> upgradeButtons;

    // Level level;

    PlayerStat playerStat;

    private void Awake() 
    {
        pauseManager = GetComponent<PauseManager>();
        playerStat = FindObjectOfType<PlayerStat>();
    }

    public void OpenMenu()
    {
        // Clean();
        pauseManager.PauseGame();
        panel.SetActive(true);
        // for(int i = 0; i < upgradeButtons.Count; i++)
        // {
        //     upgradeButtons[i].gameObject.SetActive(true);
        //     upgradeButtons[i].Set(upgradeButtons[i]);
        // }
    }

    public void CloseMenu()
    {
        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    public void UpgradeDamage()
    {
        Debug.Log("Upgrading Damage");
        playerStat.UpgradeDamage();
        CloseMenu();
    }

    public void UpgradeAttackSpeed()
    {
        Debug.Log("Upgrading AttackSpeed");
        playerStat.UpgradeAttackSpeed();
        CloseMenu();
    }
    public void UpgradeHealth()
    {
        Debug.Log("Upgrading Health");
        playerStat.UpgradeHealth();
        CloseMenu();
    }
    public void UpgradeMovement()
    {
        Debug.Log("Upgrading Movement");
        playerStat.UpgradeSpeed();
        CloseMenu();
    }

    // public void Upgrade(int pressedButtonID)
    // {
    //     level.Upgrade(pressedButtonID);
    // }

    // public void Clean()
    // {
    //     for(int i = 0; i < upgradeButtons.Count; i++)
    //     {
    //         upgradeButtons[i].Clean();
    //     }

    // }
    // public void HideButton()
    // {
    //     for(int i = 0; i < upgradeButtons.Count; i++)
    //     {
    //         upgradeButtons[i].gameObject.SetActive(false);
    //     }
    // }


}
