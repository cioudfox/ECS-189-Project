using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    public GameObject winningPanel;

    [SerializeField] ScoreUI scoreUI;
    public void ShowWinning()
    {
        Debug.Log("Winning");
        winningPanel.SetActive(true);
        scoreUI.UpdateScore();
        // yield return new WaitForSeconds(1f);
        GetComponent<PlayerController>().enabled = false;
        weapon.SetActive(false);
        GetComponent<PlayerStat>().enabled = false;
        Time.timeScale = 0f;
    }
}

