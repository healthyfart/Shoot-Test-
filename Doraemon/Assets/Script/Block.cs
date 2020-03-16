using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public GameObject player;
	void Start ()
	{
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 3f;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -2f)
		{
			Destroy(gameObject);
		}
      /*  if(transform.position.y  < player.transform.position.y )
        {
            FindObjectOfType<AudioManager>().Play("Woosh");
        }
        */
	}

}
