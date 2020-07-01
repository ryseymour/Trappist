using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_R : Interactable
{
    public DialogueBase[] DB;
    [HideInInspector] public int index;
    public bool nextDialogueOnInteract;


   

    public override void Interact()
    {
        // DialogueManager_R.instance.CloseOptions();

        if (DialogueManager_R.instance.EndBool == true)
        {
            DialogueManager_R.instance.inDialogue = false;
            DialogueManager_R.instance.EndBool = true;
            Debug.Log("Debug inDialogue");
            return;
        }


        if (nextDialogueOnInteract && !DialogueManager_R.instance.inDialogue)
        {
            Debug.Log("Trigger1");
            DialogueManager_R.instance.EnqueueDialogue(DB[index]);
            if (index < DB.Length - 1)
            {
                index++;
            }
        }
        else
        {
            Debug.Log("Trigger2");
            DialogueManager_R.instance.EnqueueDialogue(DB[index]);
        }
       

        

        

        
    }

    public void SetIndex(int i)
    {
        index = i;
    }
}
