using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridData : MonoBehaviour
{

    public static GridData instance;
    public Tilemap Tilemap;

    public Dictionary<Vector3, GridTile> tiles;

    private void Awake(){
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }

        GetWorldTiles();
    }

    private void GetWorldTiles(){ //check for all the active tiles in the Tilemap 
        tiles = new Dictionary<Vector3, GridTile>();
        int count = 0;

        textRW gridFile = new textRW();
        string [] lines = gridFile.ParseLines("grid");

        print(lines);   
        foreach(string str in lines){
            print(str);
        }
     

        

        foreach(Vector3Int pos in Tilemap.cellBounds.allPositionsWithin){
            var localPlace = new Vector3Int(pos.x, pos.y, pos.z);

            if(!Tilemap.HasTile(localPlace)) continue;

            var tile = new GridTile{
                LocalPlace = localPlace,
                WorldLocation = Tilemap.CellToWorld(localPlace),
                TileBase = Tilemap.GetTile(localPlace),
                TilemapMember = Tilemap,
                Name = localPlace.x + "," + localPlace.y,
                Cost = count,
                myTerrain = terrainType.road,                
                myEncounter = encounterType.empty
            };
           //testing out writing stuff for the grid document
            // string coords = "" + pos.x + " " + pos.y;
            // coords = coords + ", " + tile.myTerrain;
            // gridFile.WriteLine("grid",  coords);

            

            count++;
            tiles.Add(tile.WorldLocation, tile); 
            
        }
    }





}
