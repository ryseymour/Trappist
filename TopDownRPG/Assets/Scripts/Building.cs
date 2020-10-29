using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Building", menuName = "Building")]
public class Building : ScriptableObject
{

    public string buildingName;
    public Sprite buildSprite;//if there are many costumes we could make this into an array
    public Image buildingBackground;
    public Room[] rooms;
    public GameObject buildingModel;




    public string descriptionText;

    public CharacterProfile[] inBuildingCharactersScene1;
    public CharacterProfile[] inBuildingCharactersScene2;
    public CharacterProfile[] inBuildingCharactersScene3;
    public CharacterProfile[] inBuildingCharactersScene4;
    public CharacterProfile[] inBuildingCharactersScene5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
