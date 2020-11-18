using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class TestTile : MonoBehaviour
{
    private GridTile _tile;
    public InputField field;
    public Text cityText;
    private Dictionary<Vector3, GridTile> tiles;    
    public GameObject player;
    private Vector3 target;
    public bool moveComplete; 
    Vector3 worldPoint;

    GridTile currentTile;

    public Transform playerDestination;

    textRW gridFile;
    string [] rows;
    List<string[]> cells = new List<string []>();
    void Awake(){
        // field.onSubmit.AddListener((value) => fieldVal(value)); 
        field.onEndEdit.AddListener((value) => SearchTileName(value));//listens for the
        
    }

    void Start(){
        tiles = GridData.instance.tiles;        
        SetCities();
        moveComplete = false;
        target = player.transform.position;

//heads up this is a little fucky, since the pathing relies on proper camera placement I disable the camera in the 'NeverUnload' scene be sure it re-enables when needed
        if(GameObject.Find("Main Camera") != null){
            GameObject cam = GameObject.Find("Main Camera");
            cam.SetActive(false);
            Debug.Log("found main camera");
        }else{
            // Debug.Log("no main camera");
        }

        Vector3 wp = new Vector3(Mathf.FloorToInt(player.transform.position.x), Mathf.FloorToInt(player.transform.position.y), 0);
        currentTile = tiles[wp];
        

        SetData();

    }
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.M)){
            SceneManager.LoadScene("neverUnload");        
        }

        if(Input.GetMouseButtonDown(0)){
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint = new Vector3(Mathf.FloorToInt(point.x), Mathf.FloorToInt(point.y), 0);        
                  
            if(tiles.TryGetValue(worldPoint, out _tile)){              
                playerDestination.position = worldPoint + new Vector3(0.5f, 0.5f, 0);
                if(moveComplete){                    
                    _tile.TilemapMember.SetTileFlags(_tile.LocalPlace, TileFlags.None);
				    _tile.TilemapMember.SetColor(_tile.LocalPlace, Color.green);
                    StartCoroutine(resetTile(worldPoint));
                    target = worldPoint + new Vector3(0.5f, 0.5f, 0);
                    moveComplete=!moveComplete;
                }                 
            }            
        }     

        //Movement      
        if(Vector3.Distance(player.transform.position, target) > 0.0001f){
            // player.transform.position = Vector3.MoveTowards(player.transform.position, target, (2.25f*Time.deltaTime));
        }else{                          
            checkTerrain(worldPoint);
            moveComplete = true;                        
        }        

        getTile(player.transform.position);
        
    }


    void getTile(Vector3 wp){        
        wp = new Vector3(Mathf.FloorToInt(wp.x), Mathf.FloorToInt(wp.y), 0);  

        if(wp != currentTile.WorldLocation){
            // Debug.Log("change up, check the tile");
            // currentTile = wp;
            if(tiles.TryGetValue(wp, out currentTile)){
                encounterType eType = encounterType.empty;
                if(currentTile.myEncounter != eType){//only spit out debug if the tile isn't empty
                    Debug.Log("current tile encounter " + currentTile.myEncounter);
                }               
            }   
        }else{
            return;
            // Debug.Log("I'm at Tile " + currentTile);
        }
    }


    void SetData(){
        gridFile = new textRW();

        rows = gridFile.SeparateLines("index");

        for(int i=0; i<rows.Length;i++){
            // Debug.Log("" + rows[i]);
            cells.Add(gridFile.ParseLine(rows[i]));
            for(int y=0; y<cells[i].Length; y++){
                 Debug.Log(cells[y]);
            }
           
        }      
    }


    void checkTerrain(Vector3 wp){
        if(tiles.ContainsKey(wp)){           
            if(tiles[wp].myTerrain == terrainType.city){
                print("terrain contains a city " + tiles[wp].Name);
                cityText.text = tiles[wp].Name;
            }
        }else{
            // print("world point not found " + wp);
        }
    }


    void SetCities(){
        Vector3 [] cityLocations = {new Vector3(4,0,0), new Vector3(9,3,0), new Vector3(5,3,0), new Vector3(5,6,0)};

        Dictionary<Vector3, string> cityLabels = new Dictionary<Vector3, string>();
        cityLabels.Add(cityLocations[0], "Startersville");
        cityLabels.Add(cityLocations[1], "Side Forest Hills");
        cityLabels.Add(cityLocations[2], "Mediumsburough");
        cityLabels.Add(cityLocations[3], "Final City");

        for(int i=0; i<cityLocations.Length; i++){
            if(tiles.ContainsKey(cityLocations[i])){             
                tiles[cityLocations[i]].myTerrain = terrainType.city;
                tiles[cityLocations[i]].Name = cityLabels[cityLocations[i]];
            }else{
                print("City location not found in tilemap");
            }           
        }
    }


    void AvailableMovement(Vector3 wp){
        Vector3 up = wp + new Vector3(0,1,0);        
        if(tiles.ContainsKey(up)){
            print("you can move up");            
        }
  
    }


    IEnumerator resetTile(Vector3 wp){
        yield return new WaitForSeconds(1);
        tiles[wp].TilemapMember.SetColor(tiles[wp].LocalPlace, Color.white);
    }


    public void SearchTileName(string _name){        
        print("Look for name " + _name);      
    }
}
