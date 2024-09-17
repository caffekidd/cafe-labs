using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damage = 3;
    private PlayerStats playerHealth;

    private void OnCollisionEnter(Collision ProjectileDamage) 
    {
        if (ProjectileDamage.gameObject.tag == "Player")
        {
            if (playerHealth == null)
            {
            playerHealth = ProjectileDamage.gameObject.GetComponent<PlayerStats>();
            }

            playerHealth.HurtPlayer(damage);

            Destroy(gameObject);
        }
    }

    private void Update() 
    {
        Destroy(gameObject, 5);
    }
}
