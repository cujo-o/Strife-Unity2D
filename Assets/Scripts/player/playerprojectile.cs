using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerprojectile : MonoBehaviour
{
    Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("playerbullettarget").transform;
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
