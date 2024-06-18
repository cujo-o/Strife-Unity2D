using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove1 : MonoBehaviour
{ public float speed; 
    public float firerate = 1f;
    private Transform player;   public bool isflipped = false;
    public float lineofsight; public Transform here; 
    private PlayerHealth playerhealth;
    public float shootingrange;
    public Transform attackpont;
    public float attackrange; 
    public LayerMask enemy;
    public Animator anim;
    private float nextfiretime;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("player").transform;
        playerhealth = GetComponent<PlayerHealth>(); 
    }

    // Update is called once per frame
    void Update()
    {
      
       float distancefromplayer = Vector2.Distance(player.position, transform.position); 
        if (distancefromplayer<lineofsight && distancefromplayer > shootingrange)
        {
              transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distancefromplayer <= shootingrange && nextfiretime < Time.time)
        {
            anim.SetTrigger("attack");
            nextfiretime = Time.time + firerate;
        }

        flip();

    }
	public  void attack() {
        
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpont.position, attackrange, enemy);
        for (int i = 0; i <hitenemies.Length   ; i++)
        {

       
           hitenemies[i].GetComponent<PlayerHealth>().TakeDamage(5.0f);
        }
    }


    public void flip()
    {
         Vector3 Scale = transform.localScale;
        Scale.z *= -1f;
        if ( transform.position.x < player.position.x && isflipped)
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(here.position, lineofsight); 
        Gizmos.DrawWireSphere(here.position, attackrange);
    }
}
