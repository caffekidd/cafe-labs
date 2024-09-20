using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI hiscore;
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score :" + playerStats.TotalScore.ToString();
        hiscore.text = "Hi-Score :";
    }

    // Update is called once per frame
    void Update()
    {
       score.text = "Score :" + playerStats.TotalScore.ToString();
       hiscore.text = "Hi-Score :";
    }
}
