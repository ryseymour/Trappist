using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DialogueTrigger_R))]
public class DialogueEvent : Interactable
{
    [Header("Target Info")]
    public int targetIndex;
    public int targetLine;
    

    public UnityEvent unityEvent;

    private DialogueTrigger_R dialogueTrigger;

    private bool hasAdded;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger_R>();
        //interactRange = dialogueTrigger.interactRange;
    }

    public override void Interact()
    {
        if (hasAdded || DialogueManager_R.instance.inDialogue) return;

        if(dialogueTrigger.index == targetIndex)
        {
            DialogueManager_R.instance.onDialogueLineCallBack += GenericEvent;
            hasAdded = true;
        }
        base.Interact();
    }

    public void GenericEvent(int line)
    {
        if(line == targetLine)
        {
            unityEvent.Invoke();
            DialogueManager_R.instance.onDialogueLineCallBack -= GenericEvent;
        }
    }
}
