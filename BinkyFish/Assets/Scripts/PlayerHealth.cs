using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 99;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1, 0, 0, 0.1f);

    
    Animator myAnimator;
    PlayerController playerController;
    AudioSource playerAudio;
    bool isDead;
   public bool damaged;


    private void Awake()
    {
        currentHealth = startingHealth;
        myAnimator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
       playerAudio = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {

        if (damaged)
        {
            damageImage.color = flashColor;
            

        }

        else
        {

                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);


        }

        damaged = false;

    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        playerAudio.Play();

        if (!(damaged = true))
        {
            myAnimator.ResetTrigger("isColliding");
            myAnimator.SetTrigger("isSwimming)");

        }

        else
        {
            myAnimator.SetTrigger("isColliding");
            myAnimator.ResetTrigger("isSwimming");
        }


        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }

    }


    void Death()
    {
        isDead = true;

        playerController.enabled = false;
        damageImage.color = flashColor;

    }

}
