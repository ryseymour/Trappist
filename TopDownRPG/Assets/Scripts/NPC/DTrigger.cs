using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTrigger : Interactable
{
    public DialogueBase[] DB;
    [HideInInspector] public int index;
    public bool nextDialogueOnInteract;

    private void Start()
    {
        if(nextDialogueOnInteract)
        {
            index = -1;

        }
        else
        {
            index = 0;
        }
    }

    public override void Interact()
    {
        if(nextDialogueOnInteract && !DialogueManager.instance.inDialogue)
        {
            if(index < DB.Length -1)
            {
                index++;
            }
        }
        DialogueManager.instance.EnqueueDialogue(DB[index]);
    }

    public void SetIndex(int i)
    {
        index = i;
    }
}
