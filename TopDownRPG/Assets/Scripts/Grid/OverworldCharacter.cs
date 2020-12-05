using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCharacter : MonoBehaviour
{

    public GameObject destinationMarker;
    public bool interactingLocation;
    public GameObject CameraParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000)){
                // Debug.Log("ray hit " + hit.collider.gameObject.name);
                destinationMarker.transform.position = hit.collider.gameObject.transform.position;
                CameraParent.GetComponent<OWcamera>().PanToTarget(destinationMarker.transform.position);
                CameraParent.GetComponent<OWcamera>().flag = true;
            }             
        }
    }

    void OnTriggerEnter(Collider other){
        
        if(other.tag == "town"){
           if(other.gameObject.GetComponent<OWtown>().myTown != null){
                Debug.Log("hey hit a town called " + other.gameObject.GetComponent<OWtown>().myTown.myName);
                interactingLocation = true;

                if(interactingLocation == true)
                {
                    SceneManger.instance.interactedTown = other.gameObject.GetComponent<OWtown>().myTown;
                    SceneManger.instance.LoadUpTown();
                    interactingLocation = false;
                }           

           }else{
               Debug.Log("hit a town object but no town scriptable assigned");
           }
            
        }
    }

    



}
