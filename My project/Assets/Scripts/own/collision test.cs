using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public int health = 5;
    public int maxHealth = 5;

    void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Hurt")
        {
            health -= 1 ;
            Debug.Log("hurt !");
        }
    }
}