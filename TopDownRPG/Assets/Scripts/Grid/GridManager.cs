using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public static GridManager instance;

    public static Dictionary<Vector3, GridTile> tile_index;
    private GridTile _tile;

    public static string test;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {

        //Cole's keycodes to move between scenes
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log(test);
            Debug.Log("dictionary length " + tile_index.Count);
        }

        
    }
}
