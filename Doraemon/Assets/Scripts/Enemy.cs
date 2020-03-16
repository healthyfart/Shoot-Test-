using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 2500;
    public healthbar healthbar;
    public GameObject deathEffect;
    private bool up = true;
    public GameObject WinUI;
    public GameObject stopSpawn;
    public GameObject stopScore;
    void Start()
    {
        healthbar.SetMaxHealth(health);
        
    }



    public void TakeDamage (int damage)
	{
        FindObjectOfType<AudioManager>().Play("Enemy_gethit");
        health -= damage;
        healthbar.SetHealth(health);
		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("player_Explode");
		Destroy(gameObject);
        stopSpawn.SetActive(false);
        WinUI.SetActive(true);
        stopScore.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Win");
    }
    void Update()
    {
        if(transform.position.y < 3.5 && up)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime;
            up = false;
        }
        if (transform.position.y < 2.19 && !up)
        {
            transform.position += Vector3.up * Time.deltaTime;
            up = true;
        }
            
       
    }
}
