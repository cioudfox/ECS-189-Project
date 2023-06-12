using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UpgradePanelManager : MonoBehaviour
    {
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    // [SerializeField] List<UpgradeScriptableObject> upgradeButtons;

    // Level level;

    PlayerStat playerStat;
    private GameObject upgradePanel;
    private Transform buttonDescription;

    private void Awake() 
    {
        pauseManager = GetComponent<PauseManager>();
        playerStat = FindObjectOfType<PlayerStat>();

        upgradePanel = GameObject.Find("UpgradePanel");    
        buttonDescription = upgradePanel.transform.Find("Description");
        Transform upgrade0 = upgradePanel.transform.Find("Upgrade0");
        Transform upgrade1 = upgradePanel.transform.Find("Upgrade1");
        Transform upgrade2 = upgradePanel.transform.Find("Upgrade2");
        Transform upgrade3 = upgradePanel.transform.Find("Upgrade3");

        AddMouseEnterEvent(upgrade0, "Increase attack damage.");
        AddMouseEnterEvent(upgrade1, "Increase attack speed.");
        AddMouseEnterEvent(upgrade2, "Increase maximum HP.");
        AddMouseEnterEvent(upgrade3, "Increase movement speed.");
        
        AddMouseExitEvent(upgrade0);
        AddMouseExitEvent(upgrade1);
        AddMouseExitEvent(upgrade2);
        AddMouseExitEvent(upgrade3);

        upgradePanel.SetActive(false);
    }

    private void AddMouseExitEvent(Transform upgradeButton)
    {
        upgradeButton.GetComponent<ButtonUI>().onMouseExit.AddListener( () => {
                buttonDescription.gameObject.SetActive(false);
            }
        );
    }

    private void AddMouseEnterEvent(Transform upgradeButton, string s)
    {
        upgradeButton.GetComponent<ButtonUI>().onMouseEnter.AddListener( () => {
                buttonDescription.gameObject.SetActive(true);
                TextMeshProUGUI infoDisplay = buttonDescription.GetComponent<TextMeshProUGUI>();
                infoDisplay.SetText(s);
            }
        );
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
        buttonDescription.gameObject.SetActive(false);

        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    public void UpgradeDamage()
    {
        // Debug.Log("Upgrading Damage");
        playerStat.UpgradeDamage();
        CloseMenu();
    }

    public void UpgradeAttackSpeed()
    {
        // Debug.Log("Upgrading AttackSpeed");
        playerStat.UpgradeAttackSpeed();
        CloseMenu();
    }
    public void UpgradeHealth()
    {
        // Debug.Log("Upgrading Health");
        playerStat.UpgradeHealth();
        CloseMenu();
    }
    public void UpgradeMovement()
    {
        // Debug.Log("Upgrading Movement");
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
