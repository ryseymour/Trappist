using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogueTrigger : DialogueTrigger_R
{
    [Header("Quest Dialogue Info")]
    public bool hasActiveQuest;
    public DialogueQuest[] dialogueQuests;
    public int QuestIndex { get; set; }

    public override void Interact()
    {
        if(hasActiveQuest)
        {
            DialogueManager_R.instance.EnqueueDialogue(dialogueQuests[QuestIndex]);
            QuestManager.instance.CurrentQuestDialogueTrigger = this;
        }
        else
        {
            base.Interact();
        }
    }
}
