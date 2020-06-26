using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : Interactable
{
    public DialogueBase dialogue;
   
    //public bool initial;

    // Start is called before the first frame update
    public override void Interact()
    {
        Debug.Log("we Got Called");
        //DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    public void TriggerDialogue()
    {
       // DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue();
        }

        if (Vector2.Distance(gameObject.transform.position, GameManager.instance.player.position) < interactRange)
        {
           


            if (Input.GetKeyDown(KeyCode.Space) && initial == false)
            {




                Debug.Log("speaking");
                TriggerDialogue();
                initial = true;





            }
        */}
    }

  

