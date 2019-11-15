using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed = 5;

    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Player.position) > .6)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }
    }
}
