using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
    private Rigidbody2D rb;
    private int jump_force;
    public float runSpeed = 40f;
    public AudioSource audioSource;

    public Text count;
    float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
    bool music_pause = false;
    private float slowness = 10f;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        // rb.constraints = RigidbodyConstraints2D.FreezePositionX;
       
    }
    // Update is called once per frame
    void Update () {

        if (FindObjectOfType<GameManager>().ifLOSE() == false) count.text = Time.timeSinceLevelLoad.ToString("0"); 
        
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
           // FindObjectOfType<AudioManager>().Play("jump");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && music_pause == false)
        {
            music_pause = true;
            audioSource.Pause();
            // FindObjectOfType<AudioManager>().Play("jump");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && music_pause == true)
        {
            music_pause = false;
            audioSource.UnPause();
            // FindObjectOfType<AudioManager>().Play("jump");
        }
        if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
        
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
      

        controller.SetJump_Force();
       
        controller.Move(horizontalMove * Time.deltaTime, crouch, jump);
		jump = false;
        
        if (rb.transform.position.y < 0)
        {
             FindObjectOfType<AudioManager>().Play("player_Explode"); 
             Destroy(gameObject);

             FindObjectOfType<GameManager>().EndGame();
 
        }

	}

   

}
