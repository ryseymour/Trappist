using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_updown : MonoBehaviour
{
    public float moveSpeed;

private Rigidbody2D NPCrigidbody;

public bool isWalking;

public float walkTime;
private float walkCounter;
public float waitTime;
private float waitCounter;

private int walkDirection;
private int walkChange;
private int ReturnWalk;
public bool returnWalk;

// Start is called before the first frame update
void Start()
{
    NPCrigidbody = GetComponent<Rigidbody2D>();

    waitCounter = waitTime;
    walkCounter = walkTime;
    returnWalk = false;
}

// Update is called once per frame
void Update()
{

}

private void LateUpdate()
{

    if (isWalking == true)
    {
        walkCounter -= Time.deltaTime;
        if (walkCounter < 0)
        {
            isWalking = false;
            waitCounter = waitTime;
        }

        switch (walkDirection)
        {
            case 0:
                NPCrigidbody.velocity = new Vector2(0, moveSpeed);
                walkChange = 1;
                break;



            case 1:
                NPCrigidbody.velocity = new Vector2(0, -moveSpeed);
                walkChange = 0;
                break;


        }


    }
    else
    {
        waitCounter -= Time.deltaTime;
        NPCrigidbody.velocity = Vector2.zero;
        if (waitCounter < 0)
        {
            ChooseDirection();


        }

    }
}

public void ChooseDirection()
{
    if (returnWalk == true)
    {
        walkDirection = walkChange;
        //Debug.Log("wD 2" + walkDirection);
        isWalking = true;
        walkCounter = walkTime;
        returnWalk = false;
    }
    else if (returnWalk == false)
    {
        walkDirection = Random.Range(0, 2);
        

        //Debug.Log("wD 1" + walkDirection);
        isWalking = true;
        walkCounter = walkTime;
        returnWalk = true;
        
    }

}

 
 


}
