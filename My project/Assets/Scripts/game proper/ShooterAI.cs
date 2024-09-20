

using UnityEngine;
using UnityEngine.AI;
public class ShooterAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask thePlayer;


    public float health = 3;
    public int enemyPointValue = 2;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float timeBetweenAttacks = 2;
    bool alreadyAttacked;
    public GameObject projectile;
    private PlayerStats playerStats;


      private void Awake()
    {
        player = GameObject.Find("Capsule").transform;
        playerStats = player.GetComponent<PlayerStats>();

        agent = GetComponent<NavMeshAgent>();

        projectile = Resources.Load("prefabs/projectile") as GameObject;
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
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
        Rigidbody bulleto = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulleto.AddForce(transform.forward * 10f, ForceMode.Impulse);
        

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

       
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
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
