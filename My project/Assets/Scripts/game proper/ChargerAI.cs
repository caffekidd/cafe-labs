
using UnityEngine;
using UnityEngine.AI;

public class ChargerAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask thePlayer;
    public Rigidbody rbagent;
    private PlayerStats playerHealth;
    private PlayerStats TotalScore;

    public float health = 2;
    public int damage = 3;
    public int enemyPointValue = 3;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float timeBetweenAttacks = 3;
    public float ResetTimer = 1;

    private Vector3 chargePoint;
 
    bool alreadyAttacked;

    private PlayerStats playerStats;

      private void Awake()
    {
        player = GameObject.Find("Capsule").transform;
        playerStats = player.GetComponent<PlayerStats>();

        agent = GetComponent<NavMeshAgent>();
        rbagent = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, thePlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, thePlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        chargePoint = transform.position - player.position;

        if (!alreadyAttacked)
        {
        rbagent.AddForce(-chargePoint * 1.5f, ForceMode.Impulse);
        Invoke(nameof(ResetSpeed), ResetTimer);
        

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetSpeed()
    {
        rbagent.velocity = Vector3.zero;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
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
