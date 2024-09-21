using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    public int playerHealth;
    public int maxPlayerHealth = 20;
    public int TotalScore;
    public int hiscoreValue;
    public GameOver gameOver;

    private string elaspedTime;

    private void Start() 
    {
        playerHealth = maxPlayerHealth;
        TotalScore = 0;
        hiscoreValue = PlayerPrefs.GetInt("hiscoreValue", 0);
    }

    public void Update()
    {
        float minutes = Mathf.Round(Time.time / 60);
        float seconds = Mathf.Round(Time.time % 60);

        elaspedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        Debug.Log(elaspedTime);
    }


    public void HurtPlayer(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0) Invoke (nameof(DestroyPlayer), 0.5f);
        
    }

    public void addPoint(int enemyPointValue)
    {
        TotalScore += enemyPointValue;

        if (hiscoreValue < TotalScore)
        {
            PlayerPrefs.SetInt("hiscoreValue", TotalScore);
        }
    }
    private void DestroyPlayer()
    {
        Destroy(gameObject);
        gameOver.gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

   


}
