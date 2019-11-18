using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5;
    public float TurnSpeed = 5;
    public float MagnitudeMax = 1, MagnitudeMin = 0;
    public float ATKForce = 500;
    public float keysgot;
    public float timer;
    public float time;

    private Rigidbody2D rb;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        time = 2;
        timer = time;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        #region Movement
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector2.up);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector2.down);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, TurnSpeed);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -TurnSpeed);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        #endregion

        if (Input.GetKeyDown(KeyCode.Space) && time > 2)
        {
            rb.AddRelativeForce(Vector2.up * ATKForce);
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GoldKey")
        {
            keysgot += 1;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
