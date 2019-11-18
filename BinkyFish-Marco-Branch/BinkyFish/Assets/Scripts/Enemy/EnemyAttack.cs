using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public CircleCollider2D trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth.health -= 10f;
    }



}
