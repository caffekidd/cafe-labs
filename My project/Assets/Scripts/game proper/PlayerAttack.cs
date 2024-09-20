using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea;
    public float timeBetweenAttacks = 0.5f;
    bool alreadyAttacked;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
            Debug.Log("i click");
        }
    }

    private void Attack()
    {
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            attackArea.SetActive(alreadyAttacked);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        attackArea.SetActive(alreadyAttacked);
    }   
}
