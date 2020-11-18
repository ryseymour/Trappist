using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[System.Serializable]
public class Multi {
    public Vector3 location;
    public Town myTown;
}

public class ThreeDLevelGenerator : MonoBehaviour
{
    public Texture2D map;

    public ColorToPrefab[] colorMappings;

    GameObject[] towns;

    public Multi[] townLocation;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        AstarPath.active.Scan();
        towns = GameObject.FindGameObjectsWithTag("town");
        print("total # of towns " + towns.Length);
        print("first town located at " + towns[0].transform.position);
        AssignTownToObject();
    }


    void AssignTownToObject(){
        for(int i=0; i < townLocation.Length; i++){
            print("searching for " + townLocation[i].location);
            foreach(GameObject t in towns){
                if(townLocation[i].location == t.transform.position){
                    print("found a matching location " );
                    //assign the Town scriptable to the found object
                    t.GetComponent<OWtown>().testText = townLocation[i].myTown.myName;
                    t.GetComponent<OWtown>().myTown = townLocation[i].myTown;
                }
            }
        }
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
       Color pixelColor= map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            Debug.Log("blank");
            return;
        }

        // Debug.Log(pixelColor);
        
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
                return;
            }
        }     
    }

    
 
}
