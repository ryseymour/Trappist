using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[System.Serializable]
public class Multi {
    public Vector3 location;
    public Town myTown;
}

[System.Serializable]
public class Buildings
{
    public Vector3 location;
    public Building mybuilding;
}

public class ThreeDLevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public Texture2D rotationMap;
    public Texture2D buildingSpecialMap;

    public ColorToPrefab[] colorMappings;
    public Color[] rotationMapping;
    public ColorToPrefab[] colorToPrefab;

    public GameObject TempTransform;//used for helping with rotation of an object. 

    GameObject[] towns;

    public Multi[] townLocation;
    public Buildings[] buildLocation;
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
        map = SceneManger.instance.interactedTown.myTownSprite;
        rotationMap = SceneManger.instance.interactedTown.myTownRotationSprite;
        buildingSpecialMap = SceneManger.instance.interactedTown.myPrefabSprite;

        
        colorMappings = SceneManger.instance.interactedTown.scriptableColormappings;

        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    public void GenerateTile(int x, int y)
    {
       Color pixelColor= map.GetPixel(x, y);
        Color prefabColor = buildingSpecialMap.GetPixel(x, y);
       Color rotColor = rotationMap.GetPixel(x, y);

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
                //TempTransform.transform.Translate(position);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, TempTransform.transform);



                var rotObj = TempTransform.transform.GetChild(0);

                if (rotColor == Color.white)
                {
                    //var rotObj = TempTransform.transform.GetChild(0);
                    rotObj.transform.Rotate(0, 90, 0);
                    //return;
                }
                else if (rotColor == Color.blue)
                {
                    rotObj.transform.Rotate(0, 180, 0);
                }
                else if (rotColor == Color.red)
                {
                    rotObj.transform.Rotate(0, 270, 0);
                }


                rotObj.transform.parent = this.transform;
                //RotationUpdate();

                /*
                foreach (ColorToPrefab prefabmapping in colorToPrefab)
                {
                    if (prefabmapping.color.Equals(pixelColor))
                    {
                        Vector3 prefabposition = new Vector3(x, 0, y);
                        //TempTransform.transform.Translate(position);
                        Instantiate(prefabmapping.prefab, position, Quaternion.identity, TempTransform.transform);
                        Debug.Log("Prefab mapping");
                        return;
                    }
                }
                */

                return;
            }
        }  
        

    }
    public void RotationUpdate()
    {
        for (int z = 0; z < rotationMap.width; z++)
        {
            for (int t = 0; t < rotationMap.height; t++)
            {
                GenerateRotTile(z, t);
            }
        }
    }

    void GenerateRotTile(int z, int t)
    {
        Color pixelColor = map.GetPixel(z, t);

        if (pixelColor.a == 0)
        {
            Debug.Log("blank");
            return;
        }
        if (pixelColor == Color.blue)
        {
            var rotObj = TempTransform.transform.GetChild(0);
            rotObj.transform.Rotate(0, 0, 90);
            rotObj.transform.parent = this.transform;
            return;
        }

        GenerateLevel();
        
     

             
                
                return;
            }
        }
    //}



//}
