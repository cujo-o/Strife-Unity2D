using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{

    public Animator anim;
    public float elapsedtime; 
    public enemyspawner enemyspawner; 
    // Start is called before the first frame update
    void Start()
    {
      //  enemyspawner = GetComponent<enemyspawner>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemynumber = GameObject.FindGameObjectsWithTag("enemy"); 
      

        int enumb = enemynumber.Length;
        elapsedtime -= Time.deltaTime;
        if (elapsedtime<=0)
        {
            enemyspawner.canspawn=false;
        }
        if (enumb<=0)
        {
            StartCoroutine(finised());
        } 
    }
    
	

    IEnumerator finised()
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        anim.SetTrigger("start");
    }
        
}
