using UnityEngine;
using System.Collections;

public class UpgradeMenu : MonoBehaviour
{

    public GUISkin skin;
    public Texture2D background;
    public Texture2D btnUpgrade;
    public Texture2D level1;
    public Texture2D level2;
    public Texture2D level3;
    public Texture2D level4;
    public Texture2D level5;
    private GUIStyle labelStyle;
    private int rocketLevel;
    private int bombLevel;
    private int machineGunLevel;
    private int frontGunLevel;

    void Start()
    {
        rocketLevel = bombLevel = machineGunLevel = frontGunLevel = 1;
       
    }

    void Update()
    {

    }
    void drawLevel(float yPos, int level)
    {
        if (level == 1)
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 300, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 260, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 220, yPos, 50, 20), level1);
        }
        else if (level == 2)
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level2);
            GUI.Button(new Rect(3 * Screen.width / 4 - 300, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 260, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 220, yPos, 50, 20), level1);
        }
        else if (level == 3)
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level2);
            GUI.Button(new Rect(3 * Screen.width / 4 - 300, yPos, 50, 20), level3);
            GUI.Button(new Rect(3 * Screen.width / 4 - 260, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 220, yPos, 50, 20), level1);
        }
        else if (level == 4)
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level2);
            GUI.Button(new Rect(3 * Screen.width / 4 - 300, yPos, 50, 20), level3);
            GUI.Button(new Rect(3 * Screen.width / 4 - 260, yPos, 50, 20), level4);
            GUI.Button(new Rect(3 * Screen.width / 4 - 220, yPos, 50, 20), level1);
        }
        else
        {
            //GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level1);
            GUI.Button(new Rect(3 * Screen.width / 4 - 340, yPos, 50, 20), level2);
            GUI.Button(new Rect(3 * Screen.width / 4 - 300, yPos, 50, 20), level3);
            GUI.Button(new Rect(3 * Screen.width / 4 - 260, yPos, 50, 20), level4);
            GUI.Button(new Rect(3 * Screen.width / 4 - 220, yPos, 50, 20), level5);
        }
    }

    public void OnGUI()
    {
        if (skin)
            GUI.skin = skin;
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        labelStyle = new GUIStyle(GUI.skin.label);
        //labelStyle.label = TextAnchor.UpperLeft;

        GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4, Screen.width / 2, Screen.height / 2), background);
        GUI.Label(new Rect(Screen.width / 2 - Screen.width / 4 + 20, Screen.height / 2 - Screen.height / 4 + 20, 100, 30), "Money 250$", labelStyle);
        GUI.Label(new Rect(3 * Screen.width / 4 - 330, Screen.height / 2 - Screen.height / 4 + 20, 50, 30), "Rocket", labelStyle);
        GUI.Label(new Rect(3 * Screen.width / 4 - 330, Screen.height / 2 - Screen.height / 4 + 90, 50, 50), "Bomb", labelStyle);
        GUI.Label(new Rect(3 * Screen.width / 4 - 330, Screen.height / 2 - Screen.height / 4 + 170, 100, 50), "Machine Gun", labelStyle);
        GUI.Label(new Rect(3 * Screen.width / 4 - 330, Screen.height / 2 - Screen.height / 4 + 250, 100, 50), "Front Gun", labelStyle);
        //------------
        drawLevel(Screen.height / 2 - Screen.height / 4 + 45, rocketLevel);
        //------------
        drawLevel(Screen.height / 2 - Screen.height / 4 + 115, bombLevel);
        //------------
        drawLevel(Screen.height / 2 - Screen.height / 4 + 195, machineGunLevel);
        //------------
        drawLevel(Screen.height / 2 - Screen.height / 4 + 275, frontGunLevel);

        //GUI.Box(new Rect(0, 0, 50, 50),);
        if (GUI.Button(new Rect(3 * Screen.width / 4 - 100, Screen.height / 2 - Screen.height / 4 + 20, 50, 50), btnUpgrade))
        {
            rocketLevel++;
        }
        if (GUI.Button(new Rect(3 * Screen.width / 4 - 100, Screen.height / 2 - Screen.height / 4 + 100, 50, 50), btnUpgrade))
        {
            bombLevel++;
        }
        if (GUI.Button(new Rect(3 * Screen.width / 4 - 100, Screen.height / 2 - Screen.height / 4 + 180, 50, 50), btnUpgrade))
        {
            machineGunLevel++;
        }
        if (GUI.Button(new Rect(3 * Screen.width / 4 - 100, Screen.height / 2 - Screen.height / 4 + 260, 50, 50), btnUpgrade))
        {
            frontGunLevel++;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - Screen.height / 4 + 360, 200, 50), "Next Mission"))
        {
            Application.LoadLevel("Invasion");
        }

        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect(0, Screen.height - 90, Screen.width, 50), "Air strike starter kit. by Rachan Neamprasert\n www.hardworkerstudio.com");
    }
}
