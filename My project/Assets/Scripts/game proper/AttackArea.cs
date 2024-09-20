using UnityEngine;

public class AttackArea : MonoBehaviour
{

    public int damage = 1000;

    private ChaseAI health;
    private ChargerAI health1;
    private ShooterAI health2;



    private void OnTriggerEnter(Collider testKill)
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
