using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester_R : MonoBehaviour
{

    public DialogueBase dialogue;

    public void TriggerDialogue()
    {
        DialogueManager_R.instance.EnqueueDialogue(dialogue);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue();
        }
    }
}

