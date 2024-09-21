using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

    public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI score;
    public TextMeshProUGUI hiscore;
    public PlayerStats playerStats;
    

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       score.text = "Score : " + playerStats.TotalScore.ToString();
       hiscore.text = "Hi-Score : " + playerStats.hiscoreValue.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("game proper");
        Time.timeScale = 1f;
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
