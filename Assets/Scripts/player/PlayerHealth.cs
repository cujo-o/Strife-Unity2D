using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;
    private Slider PlayerHealthBar; //use it if you have a health bar. Just drag and drop it into this field in the editor.
                                   //// public AudioSource DeathSound; //Use it if you have a death sound. Just drag and drop it into this field in the editor.
    public float Health = 100.0f;  //Health of the player. Just for stating sake and easy modification in the editor
    public float CurrentHealth;  //This is the health code we will be using in the script
                                 // public AudioSource PlayerHit;  //use it if you have a player hit sound
    public float shakeIntensity;
    public float shakeTime;

    public float healthTimer = 5f;

    void Start()
    {
        PlayerHealthBar = GameObject.FindGameObjectWithTag("PHB").GetComponent<Slider>();
        //If you want to use a health bar, utilize this code, else just comment it out
        CurrentHealth = Health;
        PlayerHealthBar.value = CurrentHealth;
    }

    void Update()
    {
       
        if (CurrentHealth<Health)
        {
            healthTimer -= Time.deltaTime;
            if (healthTimer<=0)
            {
                CurrentHealth += 5f;
                healthTimer = 5f;
            }

        }

       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            TakeDamage(5f);
            Destroy(collision.gameObject); 
        }
    }

    //This function is for the player to detect damage
    public void TakeDamage(float damage)
    {
        //  PlayerHit.Play(); //If there's a Hit audio, play it. Else just comment this code out to prevent compile errors
        CurrentHealth -= damage; //Reduces the current health of the player
        anim.SetTrigger("damage");
        PlayerHealthBar.value = CurrentHealth;
        screenShake.instance.shakeCamera(shakeIntensity, shakeTime);//Sets the playerhealth bar to be the same value with the current health
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }




    //As the name implies, It handles the player's death, heck, it kills the player😢
    public void Death()
    {
        anim.SetTrigger("die");
        //If there's a ragdoll enabled for the player, enable it. Else just comment this code out to prevent compile errors
        //   DeathSound.Play(); //If we have a death audio, play it. Else just comment this code out to prevent compile errors.
    }

    public void Death2()
    {
        Destroy(gameObject);
    }
}