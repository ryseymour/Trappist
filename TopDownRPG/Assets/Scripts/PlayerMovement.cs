using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Camera cam;
    public bool hztOn;
    public float moveLimiter = .7f;

    /*public bool CheckFreeze()
    {
        bool isFrozen;
        if(DialogueManager_R.instance.inDialogue)
        {
            isFrozen = true;
        }
        else if(InventoryManager.instance.inInventory)
        {
            isFrozen = true;
        }
        //else if(InventoryManager.instance.itemPopUp.InPopUP)
       //{
           // isFrozen = true;
       // }
        else
        {
            isFrozen = false;
        }
        return isFrozen;
    }*/
    void Update()
    {
        //if (CheckFreeze()) return;
        movement.x = Input.GetAxisRaw("Horizontal");
            
        movement.y = Input.GetAxisRaw("Vertical");
        

    }

    private void FixedUpdate()
    {
        if (movement.y != 0 && movement.x != 0)
        {
          //diagonal slow down
           
            moveSpeed = 3f;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            

        }
        else
        {
            moveSpeed = 5f;
          
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
