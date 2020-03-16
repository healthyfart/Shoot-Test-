using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
    public GameObject blockPrefab;
    
    public float timeBetweenWaves = 1f;

	private float timeToSpawn = 2f;
  
   
    void Update () {
        
        if (Time.timeSinceLevelLoad >= timeToSpawn && FindObjectOfType<GameManager>().ifLOSE() == false)
		{
            if (Time.timeSinceLevelLoad < 27f)
                timeToSpawn = Time.timeSinceLevelLoad + timeBetweenWaves / (Time.timeSinceLevelLoad / 10f);
            else
                timeToSpawn = Time.timeSinceLevelLoad + timeBetweenWaves / 2.6f;
            SpawnBlocks();
        }

	}

	void SpawnBlocks ()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);
       // FindObjectOfType<AudioManager>().Play("Woosh");
        for (int i = 0; i < spawnPoints.Length; i++)
		{
			if (randomIndex != i)
			{
				Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
			}
		}
        
        /*
        wave_count++;
        count.text = wave_count.ToString();
        */
	}
 
}
