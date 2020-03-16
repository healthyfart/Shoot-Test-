using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 15f;
	public float mapWidth = 5f;
    public Camera cam;
    Vector2 movement;
    Vector2 mousepos;
    private Rigidbody2D rb;
    
   // public Transform block;

	void Start ()
	{

		rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

	void FixedUpdate ()
	{
        if (FindObjectOfType<GameManager>().ifLOSE() == true)
        {
            
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {// key control
                if (Input.anyKey)
                {
                    float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

		            Vector2  newPosition = rb.position + Vector2.right * x;
        

                    newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

		            rb.MovePosition(newPosition);
                }
                else if(Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0)
                {
                    mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 newPosition2 = mousepos;
                    newPosition2.x = Mathf.Clamp(newPosition2.x, -mapWidth, mapWidth);
                    rb.MovePosition(newPosition2);
                } 

        }
        
        
      //  if (block.position.y < )
    }
    /*
    void OnCollisionEnter2D ()
	{
        
        FindObjectOfType<BlockSpawner>().gameObject.SetActive(false);
        FindObjectOfType<GameManager>().EndGame();


	}
    */
}
