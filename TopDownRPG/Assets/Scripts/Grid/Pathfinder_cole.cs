using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder_cole : MonoBehaviour
{

    private GridTile _tile;
    private Dictionary<Vector3, GridTile> tiles;

    public bool activePathfind;
    Vector3 target;
    public GameObject player;
    
    


    // Start is called before the first frame update
    void Start()
    {
        tiles = GridData.instance.tiles;
        activePathfind = false;
        AlignPlayer();
    }


    void AlignPlayer(){
        Vector3 worldPoint = new Vector3(Mathf.FloorToInt(player.transform.position.x), Mathf.FloorToInt(player.transform.position.y), 0);

        GridTile pTile = FindTile(worldPoint);

        if(pTile != null){
            player.transform.position = pTile.WorldLocation + new Vector3(0.5f, 0.5f, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)){
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 worldPoint = new Vector3(Mathf.FloorToInt(point.x), Mathf.FloorToInt(point.y), 0);
            Debug.Log(player.transform.position);

            GridTile clickTile = FindTile(worldPoint);
        }        
    }

    public GridTile FindTile(Vector3 _wp){
        if(tiles.TryGetValue(_wp, out _tile)){
            Debug.Log("tile found " + _tile.WorldLocation);
            calcH(_tile.WorldLocation);
            return _tile;
        }else{
            Debug.Log("no tile found");
            return null;
        }

    }


    void calcH(Vector3 _dest){
        Vector3 pPos = player.transform.position - new Vector3(0.5f, 0.5f, 0);
        GridTile hTile;
        if(_dest.x > pPos.x){
            hTile = FindTile(pPos + Vector3.right);
            Debug.Log("found a tile to my right");
        }
        
        // Debug.Log("player x " + Mathf.FloorToInt(player.transform.position.x) + " dest x " + _dest.x);
        // float xdiff = Mathf.FloorToInt(player.transform.position.x) - _dest.x;
        // xdiff = Mathf.Abs(xdiff);
        // float ydiff = Mathf.FloorToInt(player.transform.position.y) - _dest.y;
        // ydiff = Mathf.Abs(ydiff);
        // Debug.Log("difference " + xdiff + " , " + ydiff);
        // int hScore = Mathf.FloorToInt(xdiff + ydiff);
        // Debug.Log("H Score " + hScore);
        // return hScore;
    }
}
