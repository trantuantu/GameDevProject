using UnityEngine;
using System.Collections;

public class FlightOnWin : MonoBehaviour
{
    public bool isWin;
    void Start()
    {
        isWin = false;
    }

    public virtual void OnWin()
    {
        isWin = true;
        
    }
}
