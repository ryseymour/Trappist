using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class NPCclass 
{
    public string name;
    public int villagerID;
    public Sprite icon;
    public GameObject spriteInWorld;

    public bool wanderUpDown;
    public bool wanderLeftRight;
    public bool wanderAll;
    public bool speaker;

    //public string[] setences;

  
    [TextArea(3,10)]
    public string[] sentences;
    public string[] sentences_two;
    public string[] sentences_three;
    

}
