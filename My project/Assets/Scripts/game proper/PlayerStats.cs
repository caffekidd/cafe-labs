using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerHealth;
    public int maxPlayerHealth = 20;
    public int TotalScore;

    private ChaseAI health;
    private ChargerAI health1;
    private ShooterAI health2;
    
    
    //test
    public int damage = 200;

    

    private void Start() 
    {
        playerHealth = maxPlayerHealth;
        TotalScore = 0;
    }


    public void HurtPlayer(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0) Invoke (nameof(DestroyPlayer), 0.5f);
        
    }

    public void addPoint(int enemyPointValue)
    {
        TotalScore += enemyPointValue;
    }
    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision testKill)
    {
        if (testKill.gameObject.tag == "Chase")
        {
            if (health == null)
            {
                health  = testKill.gameObject.GetComponent<ChaseAI>();  
            }

            health.TakeDamage(damage);
        }

        if (testKill.gameObject.tag == "Charger")
        {
            if (health1 == null)
            {
                health1  = testKill.gameObject.GetComponent<ChargerAI>();  
            }

            health1.TakeDamage(damage);
        }

        if (testKill.gameObject.tag == "Shooter")
        {
            if (health2== null)
            {
                health2 = testKill.gameObject.GetComponent<ShooterAI>();  
            }

            health2.TakeDamage(damage);
        }

        
    }


}
