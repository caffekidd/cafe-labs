using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ShooterAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask theGround, thePlayer;

    public float health;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;


      private void Awake()
    {
        player = GameObject.Find("Capsule").transform;
        agent = GetComponent<NavMeshAgent>();
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
        bulleto.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulleto.AddForce(transform.up * 8f, ForceMode.Impulse);

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

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

   
}
