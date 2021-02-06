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
    public bool targetEnemy;//if false then target is 

    public UnityEvent itemEvent;

    //item to instantiate for animation. 
    public GameObject animationSprite;

    public Move thisMove;

    //public bool Magic;
    //public int MoveCost;
    //animation?
    //level?

  

}
