using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWcamera : MonoBehaviour
{

    //11-21 note: update all this to change local position? 
    //11-25 note: give the right click PanToTarget the direction character moves toward so it can "cheat" forward. 
        //Ok that's made, make it scale to how far you click from the player


    public float speed = 2.0f;

    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    float z = 0.0f;
    [Tooltip("This cannot be all zeroes")]
    public Vector3 directionMultiplier;

    public bool flag = false;
    Vector3 target_position;



    // Start is called before the first frame update
    void Start()
    {
        print("OWcamera init");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            hit_position = Input.mousePosition;
            camera_position = transform.position; //gets position of camera at the click            
        }

        if(Input.GetMouseButton(0)){
            current_position = Input.mousePosition; 
            LeftMouseDrag(); //updates the target position
            flag = true;
        }
        
        if(flag){
            transform.position = Vector3.MoveTowards(transform.position, target_position, Time.deltaTime * speed);
            if(transform.position == target_position){
                flag = false;                
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0f){//up            
            MiddleScroll(-1);
            flag = true;
        }else if(Input.GetAxis("Mouse ScrollWheel") < 0f){//down           
           MiddleScroll(1);
           flag = true;
        }

    }

    void LeftMouseDrag(){
    
       // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
        // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
        current_position.z = hit_position.z = camera_position.z;
    

        // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
        // anyways.  
        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

        // Invert direction to that terrain appears to move with the mouse.
        direction = direction * -1;
     
        // Vector3 directionMultiplier = new Vector3(1.0f, 0.5f, 1.5f);
        direction = Vector3.Scale(direction, directionMultiplier); //multiply the vector
        target_position = camera_position + direction;
    }

    public void PanToTarget(Vector3 targ){
        Vector3 newTarg = targ;
        newTarg = new Vector3(targ.x, 3.5f, targ.z);
        Debug.Log("Right target " + newTarg);
        target_position = newTarg;
        
    }

    void MiddleScroll(float m){
        // target_position = camera_position + Vector3.up*m;
        Camera.main.fieldOfView += 1*m;
    }

}
