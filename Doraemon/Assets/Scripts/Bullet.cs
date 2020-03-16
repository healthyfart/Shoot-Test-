using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		rb.velocity = -transform.right * speed;
    
	}
    /*
	void OnTriggerEnter2D (Collider2D hitInfo)
	{

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}
    */
    void OnCollisionEnter2D()
    {
        FindObjectOfType<AudioManager>().Play("player_gethit");
        Destroy(gameObject);

    }
    private void Update()
    {
        if(rb.transform.position.x < -13) Destroy(gameObject);
    }

}
