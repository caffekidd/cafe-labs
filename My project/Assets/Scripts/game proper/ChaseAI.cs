
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
public class ChaseAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask thePlayer;
    private PlayerStats playerHealth;
    private PlayerStats playerStats;

    public int health = 5;
    public int damage = 1;

    public int enemyPointValue = 1;

    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("Capsule").transform;
        playerStats = player.GetComponent<PlayerStats>();

        agent = GetComponent<NavMeshAgent>();
       
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, thePlayer);

        if (playerInSightRange) ChasePlayer();
    }


    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player.position);
    }

    void OnCollisionEnter(Collision contactDamage) 
    {
        if (contactDamage.gameObject.tag == "Player")
        {
            if (playerHealth == null)
            {
            playerHealth = contactDamage.gameObject.GetComponent<PlayerStats>();            
            }
            
            playerHealth.HurtPlayer(damage);
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
        Destroy(gameObject);
        playerStats.addPoint(enemyPointValue);
        }
    }

   
}
