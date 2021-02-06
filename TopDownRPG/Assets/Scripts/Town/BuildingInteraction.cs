using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum BuildingType {castle, guardTower, house, huntersLodge, tavern, store}


public class BuildingInteraction : MonoBehaviour
{


    public BuildingType myType;
    bool mouse_Over = false;
    public Building myBuilding;
    public bool leavingTown;


    public void FindBuilding(){
        myBuilding = TownManager.instance.town.buildings[0];
        
        

        switch (myType)

        {
            case BuildingType.castle:
                {
                    myBuilding = TownManager.instance.town.buildings[0];
                    Debug.Log(myBuilding);
                    break;
                }

            case BuildingType.huntersLodge:
                {
                    myBuilding = TownManager.instance.town.buildings[3];
                    Debug.Log(myBuilding);
                    break;
                }

            case BuildingType.store:
                {
                    myBuilding = TownManager.instance.town.buildings[5];
                    Debug.Log(myBuilding);
                    break;
                }

        }

    }

    void OnMouseDown(){
        print("Clicked " + gameObject.name);
        TownManager.instance.SwitchCamera(1);
    }

    void OnMouseOver(){

        if(!mouse_Over){                             
            TownManager.instance.toolTipBox.transform.position = Input.mousePosition;
            TownManager.instance.toolTipBox.SetActive(true);
            mouse_Over = true;
            FindBuilding();
            LoadBuildingData(myBuilding);
        }        
    }

    void OnMouseExit(){
        if(mouse_Over){
            Debug.Log("Mouse exit");
            TownManager.instance.toolTipBox.SetActive(false);
            mouse_Over = false;
        }
    }


    public void LoadBuildingData(Building _building){
      /*  Debug.Log("Loaded: " + _building.buildingName + "\nCharacter 1: " + _building.inBuildingCharactersScene1[0] +
         "\nCharacter 2: " + _building.inBuildingCharactersScene1[1] +
         "\nCharacter 3: " + _building.inBuildingCharactersScene1[2] +
         "\nCharacter 4: " + _building.inBuildingCharactersScene1[3]);*/

        if(InsideManager.instance.imInside == false)
        {
            InsideManager.instance.buildingInside = _building;
            InsideManager.instance.imInside = true;
            InsideManager.instance.EnterBuilding();
        }


    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && InsideManager.instance.imInside == true)
        {
            TownManager.instance.SwitchCamera(0);
            InsideManager.instance.imInside = false;
            //InsideNPCTransforms.instance.ClearthePeople();

        }
  

        }
    }


