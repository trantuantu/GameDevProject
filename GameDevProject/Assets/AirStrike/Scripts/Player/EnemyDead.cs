using UnityEngine;
using System.Collections;

public class EnemyDead : FlightOnDead {
	// giving score.
	public int ScoreAdd = 250;
	
	void Start () {}
	
	// if Enemy on Dead
	public override void OnDead (GameObject killer)
	{
		if(killer){// check if killer is exist
			// check if PlayerManager are included.
			if(killer.gameObject.GetComponent<PlayerManager>()){
				// find gameMAnager and Add score
				GameManager score = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));
				score.AddScore(ScoreAdd);

                int totalEnemy = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>().enemyCount;
                //Debug.Log(totalEnemy);
                if (score.Killed == totalEnemy)
                {
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameUI>().drawWarning();
                    GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>().isBoss = true;
                    GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>()[1].Play(44100);
                   
                }
               
                if (this.gameObject.name.Contains("Boss"))
                {
                  
                    GameObject.FindGameObjectWithTag("Player").GetComponent<FlightOnWin>().OnWin();
                    GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>().isBoss = false;

                }
            }
          
        }
		base.OnDead (killer);
	}
}
