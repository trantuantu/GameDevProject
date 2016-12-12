/// <summary>
/// Enemy spawner. auto Re-Spawning an Enemy by Random index of Objectman[]
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	
	public bool Enabled = true;
	public GameObject[] Objectman; // object to spawn
	public float timeSpawn = 3;
	public int enemyCount = 10;
	public int radius = 10;
	public string Tag = "Enemy";
	public string Type = "Enemy";
	private float timetemp = 0;
	private int indexSpawn;
    public bool isBoss = false;
    public bool isStop = false;
    
    
	void Start ()
	{
		indexSpawn = Random.Range (0, Objectman.Length - 1); //Except Boss
		timetemp = Time.time;
	}

	void Update ()
	{
		
		if (!Enabled)
			return;
		
        if (isBoss == true && isStop == false)
        {
            GameObject obj = (GameObject)GameObject.Instantiate(Objectman[Objectman.Length - 1], transform.position + new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius)), Quaternion.identity);
            obj.tag = Tag;
            indexSpawn = Objectman.Length - 1;
            isStop = true;
        }
       
		var gos = GameObject.FindGameObjectsWithTag (Tag);
        var score = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));
       
        if (score != null)
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null && score.Killed < enemyCount + 1 && isBoss == true) isStop = false; //Check if boss interactive with Ground, re-create boss
            if (enemyCount - score.Killed > gos.Length && Time.time > timetemp + timeSpawn && isBoss == false)
            {
                // spawing an enemys by random index of Objectman[]
                timetemp = Time.time;
                GameObject obj = (GameObject)GameObject.Instantiate(Objectman[indexSpawn], transform.position + new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius)), Quaternion.identity);
                obj.tag = Tag;
                indexSpawn = Random.Range(0, Objectman.Length - 1);
            }
        }
	}
}
