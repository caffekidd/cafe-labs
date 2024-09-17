using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerHealth;
    public int maxPlayerHealth = 20;

    private void Start() 
    {
        playerHealth = maxPlayerHealth;
    }

    private void Update()
    {

    }

    public void HurtPlayer(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0) Invoke (nameof(DestroyPlayer), 0.5f);
        
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

}
