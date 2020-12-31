using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestDialogueTrigger : DialogueTrigger_R
{
    [Header("Quest Dialogue Info")]
    public bool hasActiveQuest;
    public DialogueQuest[] dialogueQuests;
    public int QuestIndex { get; set; }

    [Header("Target Info")]
    public bool hasActiveDialogueEvent;
    public int targetIndex;
    public int targetLine;

    public UnityEvent unityEvent;

    public override void Interact()
    {
     

        if(hasActiveQuest)
        {
            Debug.Log("has Active Quest");
            DialogueManager_R.instance.EnqueueDialogue(dialogueQuests[QuestIndex]);
            QuestManager.instance.CurrentQuestDialogueTrigger = this;
        }
        else
        {
            base.Interact();
        }


        if (unityEvent != null)
        {
            Debug.Log("event test");
            unityEvent.Invoke();
            base.Interact();
            //return;
        }
    }


}
