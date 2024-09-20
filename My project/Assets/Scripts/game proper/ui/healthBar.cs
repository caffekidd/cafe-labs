using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image green;

    public float healthAmount;

    private GameObject playerchr;

    public PlayerStats playerStats;



    // Start is called before the first frame update
    void Start()
    {
        playerchr = GameObject.Find("Capsule");
        playerStats = playerchr.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log(playerStats.playerHealth);
       healthAmount = playerStats.playerHealth;

       green.fillAmount = healthAmount / 20f;
    }
}
