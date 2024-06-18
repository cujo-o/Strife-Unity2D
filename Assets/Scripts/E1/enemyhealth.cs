﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public Animator anim;
    public float Health = 100.0f;  
    public float CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = Health;
    }

   
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage; //Reduces the current health of the player
        anim.SetTrigger("damage");
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("playerbullet"))
        {
            TakeDamage(10f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("scythe"))
        {
            TakeDamage(20f);
        }
    }


    public void Death()
    {
        anim.SetTrigger("die");
     
    }

    public void Death2()
    {
        Destroy(gameObject);
    }
}
