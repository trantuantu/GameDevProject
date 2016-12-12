using UnityEngine;
using System.Collections;

public class PlayerWin : FlightOnWin
{
   
    void Start() {
        isWin = false;
    }

    // if player dead 
    public override void OnWin()
    {
        // if player dead call GameOver in GameManager
        GameManager gamemanger = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));
        gamemanger.Win();
        base.OnWin();
       
    }
}
