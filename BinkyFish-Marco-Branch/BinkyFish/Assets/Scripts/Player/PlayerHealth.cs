using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    float maxHealth = 100;
    PlayerController playerController;
    Image healthBar;
    public float health;


    private void Start()
    {
        //UpdateHealth();


        healthBar = GetComponent<Image>();
        health = maxHealth;
        
    }


    private void Update()
    {

        healthBar.fillAmount = health / maxHealth;


    }


    //public void UpdateHealth()
    //{


    //    if (health <= 0)
    //        {
    //        Debug.Log("GAMEOVER");

    //        playerController.enabled = false;

    //        }


    //}



}
