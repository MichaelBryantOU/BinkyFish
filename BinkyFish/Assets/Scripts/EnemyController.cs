using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed = .5f;
    public int startingHealth = 3;
    public int currentHealth;
    public int enemyHealth;
    public int amount = 1;


    bool damaged;

    private Transform Player;
   

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, Player.position) > .6)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
            transform.LookAt(Player);
        }
    }

    void onTriggetEnter2D(Collider2D col)
    {
        if (damaged) 
        {
            damaged = true;
            enemyHealth -= amount;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }

        }

    }

  
}
