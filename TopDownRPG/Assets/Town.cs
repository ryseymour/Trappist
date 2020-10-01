﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Town", menuName = "Town")]
public class Town : ScriptableObject
{

    public string myName;
    public string townDescriptionText;
    public Sprite myBackgroundSprite;
    

    public BuildingLocation B1;
    public BuildingLocation B2;
    public BuildingLocation B3;
    public BuildingLocation B4;
    public BuildingLocation B5;
    public BuildingLocation B6;

    public enum BuildingLocation
    {
        none,
        upperCenter,
        center,
        left,
        right,
        lowerCenter
    }

    public Building[] buildings;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}