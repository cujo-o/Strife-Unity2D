using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingenemymove : MonoBehaviour
{
    public float speed; 
   
    private Transform player;
    public Animator Anim;
    public bool isflipped = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
         gameObject.GetComponent<enemyhealth2>().Death(); 
        }

        flip();
    }

    public void flip()
    {
        Vector3 Scale = transform.localScale;
        Scale.z *= -1f;
        if (transform.position.x < player.position.x && isflipped)
        {
            transform.localScale = Scale;
            transform.Rotate(0, 180f, 0);
            isflipped = false;
        }
        else if (transform.position.x > player.position.x && !isflipped)
        {
            transform.localScale = Scale;
            transform.Rotate(0, 180f, 0);
            isflipped = true;
        }
        transform.localScale = Scale;

    }

}
