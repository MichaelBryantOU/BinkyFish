using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5;
    public float TurnSpeed = 5;
    public float MagnitudeMax = 1, MagnitudeMin = 0;


    private Rigidbody2D rb;
    private bool isMoving;
    private bool isAttacking;
    private bool isSwimming;
    private Animator myAnimator;
    


    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        isAttacking = false;

    }

    // Update is called once per frame
    void Update()
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


        Attack();
        


        void Attack()
        {

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                isAttacking = true;
                myAnimator.SetTrigger("isAttacking");
                myAnimator.ResetTrigger("isSwimming");


            }
            else
            {
                isAttacking = false;
                myAnimator.ResetTrigger("isAttacking");
                myAnimator.SetTrigger("isSwimming");

            }

        }

        


        /* private void Update()
         {
             Debug.Log(isMoving);

         }*/
    }
}
