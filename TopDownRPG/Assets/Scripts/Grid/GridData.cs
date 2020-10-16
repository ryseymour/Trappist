using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridData : MonoBehaviour
{

    public static GridData instance;
    public Tilemap Tilemap;

    public Dictionary<Vector3, GridTile> tiles;
    public bool firstTime = false;


    private void Awake(){
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }

        if(!firstTime){
            firstTime = true;
            GetWorldTiles();
            GridManager.tile_index = tiles;
            GridManager.test = "fuck";
        }else{
            print("probs gotta do something but you're back again");
        }
            

        
        
    }

    private void GetWorldTiles(){ //check for all the active tiles in the Tilemap 
        tiles = new Dictionary<Vector3, GridTile>();
        int count = 0;

    //TESTING THE DATA FILE
        textRW gridFile = new textRW();
        string [] lines = gridFile.SeparateLines("grid");

        //Debug.Log("Number of lines in data file " + lines.Length);

        
        List<string> locationData = new List<string>(); 

        foreach(string str in lines){
             string[] cell = gridFile.ParseLine(str); //returns an array
            locationData.Add(cell[0]); 
        }
    //END TESTING THE DATA FILE
        
        //clear the index file
         gridFile.ClearFile("index");
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
     
        //testing here to see if the grid.txt has the location (parsing the location too) 

            for(int i=0; i<locationData.Count; i++){
               if(gridFile.CellToVector(locationData[i]) == tile.WorldLocation){
                    string[] cell = gridFile.ParseLine(lines[i]);//the cell [] holds the comma separated cells
                    Debug.Log("matched world location " + cell[0]);
                    //check if the 3rd cell in the row matches a possible type for encounterType
                    if(System.Enum.TryParse<encounterType>(cell[1], out encounterType testEnum)){
                        Debug.Log("encounter check worked " + testEnum);
                        tile.myEncounter = testEnum;
                    }else{
                        Debug.Log("encounter match not found");
                    }
                }           
            }

            //testing out writing stuff for the index document           
            string coords = "" + tile.WorldLocation.x + " " + tile.WorldLocation.y;
            coords = coords + "," + tile.myTerrain + "," + tile.myEncounter;
            gridFile.WriteLine("index",  coords);            
        //End of all the writing shenanigans 


            count++;
            tiles.Add(tile.WorldLocation, tile);             
        }
    }





}
