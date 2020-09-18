using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum terrainType {city, road}
public enum encounterType {empty, dialogue, combat, collect}

public class GridTile {

    public Vector3Int LocalPlace {get;set;}

    public Vector3 WorldLocation {get; set;}

    public TileBase TileBase {get; set;}

    public Tilemap TilemapMember {get;set; }

    public string Name {get; set; }

    public bool IsExplored {get; set; }

    public GridTile ExploredFrom {get; set; }

    public int Cost {get; set; }

    public terrainType myTerrain {get; set; }

    public encounterType myEncounter {get; set;}    


}
