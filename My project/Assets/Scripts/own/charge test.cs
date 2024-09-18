using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chargetest : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask thePlayer;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    bool alreadyAttacked;
    public Rigidbody rbagent;

    public int timeBetweenAttacks = 1;

    private void Awake() 
    {
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
        transform.LookAt(player);
        Debug.Log(rbagent.velocity.magnitude);

        if (!alreadyAttacked)
        {
        rbagent.AddForce(player.position - transform.position, ForceMode.Impulse);

        Debug.Log("charge");

        alreadyAttacked = true;
        
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        rbagent.velocity = Vector3.zero;
    }
}
