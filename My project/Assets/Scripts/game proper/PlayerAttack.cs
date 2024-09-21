using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea;
    public float timeBetweenAttacks = 0.5f;
    bool alreadyAttacked;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Attack();
                Debug.Log("i click");
                
            }
        }
    }

    private void Attack()
    {
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            animator.SetBool("attack", true);
            attackArea.SetActive(alreadyAttacked);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        attackArea.SetActive(alreadyAttacked);
        animator.SetBool("attack", false);
    }   
}
