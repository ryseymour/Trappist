using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Move : ScriptableObject
{
    public string myName;
    public string myDescription;
    public Sprite myIcon;
    public int Damage;
    public int CritD;
    public bool Multiple;
    public bool teamBuff;

    public UnityEvent itemEvent;

    public Move thisMove;

    //public bool Magic;
    //public int MoveCost;
    //animation?
    //level?

}
