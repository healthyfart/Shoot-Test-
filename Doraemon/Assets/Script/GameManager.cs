using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    
    public float slowness = 10f;
    //public GameObject replay;
    public GameObject GameEndUI;
    public GameObject ScoreUI;
    //public GameObject StopVideo;
    public Rigidbody2D rb;
    public Transform[] spawnPoints;
    public Text wave_Cur;
    public Text wave_End;
    public AudioSource audioSource;

    public bool lose = false;

    private void Start()
    {
        
        // rb = GetComponent<Rigidbody2D>();
    }
   
    public bool ifLOSE()
    {
        if (lose) return true;
        else return false;

    }

    public void EndGame ()
	{

        lose = true;
        STARTslow();
        audioSource.Pause();

        wave_End.text = wave_Cur.text;
        //stop controll
       
        //close ui
        ScoreUI.SetActive(false);
        //pop ui
        GameEndUI.SetActive(true);
        
        
    }

    
    public void gotoMenu()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void STARTslow()
    {
        FindObjectOfType<AudioManager>().Play("TimeSlow");
        StartCoroutine(slow());
    }

    IEnumerator slow()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        
        yield return new WaitForSeconds(1f / slowness);

    }
	public void  RestartLevel ()
	{
        
	    Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
