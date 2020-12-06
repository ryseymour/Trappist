using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownBuilding : MonoBehaviour
{


    public Town myAssociatedTown;
    public Building myAssociatedBuilding;
    // Start is called before the first frame update
    void Start()
    {
   
    }



    void OnMouseDown(){
        Debug.Log("clicked me");    
        GameObject tParent = GameObject.Find("TownParent");
        if(tParent != null){
           
        }
    }
}
