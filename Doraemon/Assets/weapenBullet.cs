using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapenBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //FindObjectOfType<AudioManager>().Play("Enemy_gethit");
        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
 
   
}
