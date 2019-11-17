using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 1;
    public CircleCollider2D range;

    Animator myAnimator;
    GameObject player;
    PlayerHealth playerHealth;
    //EnemyController enemyHealth;
    bool playerInRange;
    float timer;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerHealth.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
         myAnimator = GetComponent < Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
            myAnimator.SetTrigger("isAttacking");
            myAnimator.ResetTrigger("isSwimming");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange  /*&& enemyHealth.currentHealth > 0*/ )
        {
            Attack();
        }

        //if (playerHealth.currentHealth <= 0)
        //{ }
    }

    void Attack()
    {
        timer = 0f;

        


        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
