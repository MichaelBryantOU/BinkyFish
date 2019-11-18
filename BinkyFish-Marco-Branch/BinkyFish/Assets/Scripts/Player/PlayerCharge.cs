using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharge : MonoBehaviour
{
    private BoxCollider2D HitCollider;
    GameObject HitObject;
    public float time;
    public float timer;

    void Start()
    {
        time = 2;
        timer = time;
        HitCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space) && timer > 2)
        {
            HitCollider.enabled = true;
            timer = 0;

            //StartCoroutine(ChargeReload());
        }
        

        //IEnumerator ChargeReload()
        {
            //new WaitForSeconds(3);
            //HitCollider.enabled = false;
        }
    }

    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.CompareTag("Enemy"))
        {
            HitObject = collision.gameObject;
           
            HitCollider.enabled = false;
            Destroy(HitObject);

        }

        if (collision.collider.CompareTag("Untagged"))
        {
            HitCollider.enabled = false;

        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
}
