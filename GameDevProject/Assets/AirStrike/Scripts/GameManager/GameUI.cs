using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class GameUI : MonoBehaviour
{

	public GUISkin skin;
	public Texture2D Logo;
	public int Mode;
	private GameManager game;
	private PlayerController play;
	private WeaponController weapon;
    public Texture2D background;
    public Texture2D btnUpgrade;
    public Texture2D level1;
    public Texture2D level2;
    public Texture2D level3;
    public Texture2D level4;
    public Texture2D level5;
    private GUIStyle labelStyle;
    public Texture2D warning;
    private int minigunLevel;
    private int rocketLevel;
    private int napalmLevel;
    private int rocketA2Level;
    public int money;
    

    void Start ()
	{
		game = (GameManager)GameObject.FindObjectOfType (typeof(GameManager));
		play = (PlayerController)GameObject.FindObjectOfType (typeof(PlayerController));
		weapon = play.GetComponent<WeaponController> ();
        minigunLevel = rocketLevel = napalmLevel = rocketA2Level = 2;
        money = -1;
		// define player
		
	}

    void drawLevel(float yPos, int level)
    {
        if (level == 1)
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 2 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 3 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
        }
        else if (level == 2)
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 2 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 3 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level2);
        }
        else if (level == 3)
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 2 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level3);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 3 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level2);
        }
        else if (level == 4)
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level4);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 2 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level3);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 3 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level2);
        }
        else
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level5);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level4);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 2 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level3);
            GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 3 * Screen.width / 2 / 20, yPos, Screen.width / 2 / 20, Screen.width / 2 / 20), level2);
        }
    }


    public void OnGUI ()
	{
		
		if (skin)
			GUI.skin = skin;
        drawWarning();

        switch (Mode) {
		case 0:
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Mode = 2;	
			}
			
			if (play) {
				
				play.Active = true;
			
				GUI.skin.label.alignment = TextAnchor.UpperLeft;
				GUI.skin.label.fontSize = 30;
				GUI.Label (new Rect (20, 20, 200, 50), "Kills " + game.Killed.ToString ());
				GUI.Label (new Rect (20, 60, 200, 50), "Score " + game.Score.ToString ());
				
				GUI.skin.label.alignment = TextAnchor.UpperRight;
				GUI.Label (new Rect (Screen.width - 220, 20, 200, 50), "ARMOR " + play.GetComponent<DamageManager> ().HP);
				GUI.skin.label.fontSize = 16;
				
				// Draw Weapon system
				//if (weapon != null && weapon.WeaponLists.Length > 0 && weapon.WeaponLists.Length < weapon.CurrentWeapon && weapon.WeaponLists [weapon.CurrentWeapon] != null) {
					if (weapon.WeaponLists [weapon.CurrentWeapon].Icon)
						GUI.DrawTexture (new Rect (Screen.width - 100, Screen.height - 100, 80, 80), weapon.WeaponLists [weapon.CurrentWeapon].Icon);
				
					GUI.skin.label.alignment = TextAnchor.UpperRight;
					if (weapon.WeaponLists [weapon.CurrentWeapon].Ammo <= 0 && weapon.WeaponLists [weapon.CurrentWeapon].ReloadingProcess > 0) {
						if (!weapon.WeaponLists [weapon.CurrentWeapon].InfinityAmmo)
							GUI.Label (new Rect (Screen.width - 230, Screen.height - 120, 200, 30), "Reloading " + Mathf.Floor ((1 - weapon.WeaponLists [weapon.CurrentWeapon].ReloadingProcess) * 100) + "%");
					} else {
						if (!weapon.WeaponLists [weapon.CurrentWeapon].InfinityAmmo)
							GUI.Label (new Rect (Screen.width - 230, Screen.height - 120, 200, 30), weapon.WeaponLists [weapon.CurrentWeapon].Ammo.ToString ());
					}
				//}else{
					//weapon = play.GetComponent<WeaponController> ();
				//}
				
				GUI.skin.label.alignment = TextAnchor.UpperLeft;
				GUI.Label (new Rect (20, Screen.height - 50, 250, 30), "R Mouse : Switch Guns C : Change Camera");
			
			}else{
				play = (PlayerController)GameObject.FindObjectOfType (typeof(PlayerController));
				weapon = play.GetComponent<WeaponController> ();
			}
			break;
		case 1:
			if (play)
				play.Active = false;
			
			Screen.lockCursor = false;
			
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect (0, Screen.height / 2 + 10, Screen.width, 30), "Game Over");
		
			GUI.DrawTexture (new Rect (Screen.width / 2 - Logo.width / 2, Screen.height / 2 - 150, Logo.width, Logo.height), Logo);
		
			if (GUI.Button (new Rect (Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 40), "Restart")) {
				Application.LoadLevel (Application.loadedLevelName);
			
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 40), "Main menu")) {
				Application.LoadLevel ("Mainmenu");
			}
			break;
		
		case 2:
			if (play)
				play.Active = false;
			
			Screen.lockCursor = false;
			Time.timeScale = 0;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect (0, Screen.height / 2 + 10, Screen.width, 30), "Pause");
		
			GUI.DrawTexture (new Rect (Screen.width / 2 - Logo.width / 2, Screen.height / 2 - 150, Logo.width, Logo.height), Logo);
		
			if (GUI.Button (new Rect (Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 40), "Resume")) {
				Mode = 0;
				Time.timeScale = 1;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 40), "Main menu")) {
				Time.timeScale = 1;
				Mode = 0;
				Application.LoadLevel ("Mainmenu");
			}
			break;
            case 3:
                GUI.skin.label.alignment = TextAnchor.UpperLeft;
                GUI.skin.button.alignment = TextAnchor.UpperLeft;
                labelStyle = new GUIStyle(GUI.skin.label);
                //labelStyle.label = TextAnchor.UpperLeft;
                //GUI.skin.label.fontSize = Screen.height / Screen.width;
              
                GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4, Screen.width / 2, Screen.height / 2), background);
                
                GUI.Label(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 3 * Screen.width / 2 / 21, Screen.height / 2 - Screen.height / 4 + (Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 - Screen.width / 2 / 130, 50, 30), "Minigun");
                GUI.Label(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 3 * Screen.width / 2 / 21, Screen.height / 2 - Screen.height / 4 + 2 * (Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + Screen.width / 2 / 15 - Screen.width / 2 / 130, 50, 30), "Rocket");
                GUI.Label(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 3 * Screen.width / 2 / 21, Screen.height / 2 - Screen.height / 4 + 3 * (Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + 2 * Screen.width / 2 / 15 - Screen.width / 2 / 130, 100, 50), "Napalm");
                GUI.Label(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 5 - 3 * Screen.width / 2 / 21, Screen.height / 2 - Screen.height / 4 + 4 * (Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + 3 * Screen.width / 2 / 15 - Screen.width / 2 / 130, 100, 50), "Rocket A2");
                
                if (File.Exists("weaponStat"))
                {
                    
                    StreamReader file = new StreamReader("weaponStat");
                    string weaponData = file.ReadLine();
                    if (weaponData != null)
                    {
                        string[] arr = weaponData.Split();
                        minigunLevel = Int32.Parse(arr[0]);
                        rocketLevel = Int32.Parse(arr[1]);
                        napalmLevel = Int32.Parse(arr[2]);
                        rocketA2Level = Int32.Parse(arr[3]);
                        file.Close();
                        if (money == -1)
                        {
                            money = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageManager>().HP + Int32.Parse(arr[4]);
                            writeWeaponStats("weaponStat");
                        }
                    }
                   
                }else
                {
                    if (money == -1) money = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageManager>().HP;
                    writeWeaponStats("weaponStat");

                }
                GUI.Label(new Rect(Screen.width / 2 - Screen.width / 4 + 20, Screen.height / 2 - Screen.height / 4 + 20, 100, 30), "Money " + money + " $");
                //------------
                drawLevel(Screen.height / 2 - Screen.height / 4 + (Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + Screen.width / 2 / 30, minigunLevel);
                //------------
                drawLevel(Screen.height / 2 - Screen.height / 4 + 2*(Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + Screen.width / 2 / 15 + Screen.width / 2 / 30, rocketLevel);
                //------------
                drawLevel(Screen.height / 2 - Screen.height / 4 + 3*(Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + 2*Screen.width / 2 / 15 + Screen.width / 2 / 30, napalmLevel);
                //------------
                drawLevel(Screen.height / 2 - Screen.height / 4 + 4*(Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + 3* Screen.width / 2 / 15 + Screen.width / 2 / 30, rocketA2Level);

                //GUI.Box(new Rect(0, 0, 50, 50),);
                if (GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 8, Screen.height / 2 - Screen.height / 4 + (Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5, Screen.width / 2 / 15, Screen.width / 2 / 15), btnUpgrade))
                {
                  
                    if (money >= 25)
                    {
                        if (minigunLevel < 5)
                        {
                            minigunLevel++;
                            money -= 25;
                            writeWeaponStats("weaponStat");
                        }
                    }
                   
                    //money = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageManager>().HP;
                   
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>().WeaponLists[0].NumBullet++;
                    


                }
                if (GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 8, Screen.height / 2 - Screen.height / 4 + 2 * (Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + Screen.width / 2 / 15, Screen.width / 2 / 15, Screen.width / 2 / 15), btnUpgrade))
                {
                   
                    if (money >= 25)
                    {
                        if (rocketLevel < 5)
                        {
                            rocketLevel++;

                            // GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>().WeaponLists[1].NumBullet++;
                           
                            money -= 25;
                            writeWeaponStats("weaponStat");
                        }
                    }
                }
                if (GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 8, Screen.height / 2 - Screen.height / 4 + 3 * (Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + 2 * Screen.width / 2 / 15, Screen.width / 2 / 15, Screen.width / 2 / 15), btnUpgrade))
                {
                   
                    if (money >= 25)
                    {
                        if (napalmLevel < 5)
                        {
                            napalmLevel++;
                            // GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>().WeaponLists[2].NumBullet++;
                           
                            money -= 25;
                            writeWeaponStats("weaponStat");
                        }
                    }
                }
                if (GUI.Button(new Rect(3 * Screen.width / 4 - Screen.width / 2 / 8, Screen.height / 2 - Screen.height / 4 + 4 * (Screen.height / 2 - 4 * Screen.width / 2 / 15) / 5 + 3 * Screen.width / 2 / 15, Screen.width / 2 / 15, Screen.width / 2 / 15), btnUpgrade))
                {
                   
                    if (money >= 25)
                    {
                        if (rocketA2Level < 5)
                        {
                            rocketA2Level++;
                           
                            money -= 25;
                            writeWeaponStats("weaponStat");
                        }
                    }
                    // GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>().WeaponLists[3].NumBullet++;
                }
                GUI.skin.button.alignment = TextAnchor.MiddleCenter;
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + Screen.height / 4 + Screen.height / 2 / 15, 200, 50), "Next Mission"))
                {

                    Application.LoadLevel("Modern");
                }

               
                break;
			
		}
        
	}
    private void writeWeaponStats(string fileName)
    {
        if (File.Exists(fileName))
        {
            //Debug.Log(fileName + " already exists.");
            StreamWriter file1 = new StreamWriter(fileName, false);
            file1.Write(minigunLevel + " " + rocketLevel + " " + napalmLevel + " " + rocketA2Level + " " + money);
            file1.Close();
            return;

        }
        var file = File.CreateText(fileName);
        file.Write(minigunLevel + " " + rocketLevel + " " + napalmLevel + " " + rocketA2Level + " " + money);
        file.Close();
    }
    public void drawWarning()
    {
        //Temporaty code
        if (GameObject.FindGameObjectWithTag("Spawner") != null && GameObject.FindGameObjectWithTag("Player") != null)
            if (GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>().isBoss == true && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWin>().isWin == false)
        GUI.DrawTexture(new Rect(0, 3 * Screen.height / 4 + Screen.height / 20, Logo.width / 2, Logo.height / 2), warning);
        //GUI.DrawTexture(new Rect(3 * Screen.height / 4, Screen.width / 2 - Screen.width / 20, Screen.height / 10, Screen.width / 10), warning);
    }

}
