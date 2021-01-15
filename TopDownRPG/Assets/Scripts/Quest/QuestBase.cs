using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBase : ScriptableObject
{
    public string questName;
    [TextArea(3, 10)]
    public string questionDescription;

    public int[] CurrentAmount { get; set; }
    public int[] RequiredAmount { get; set; }

    public bool IsCompleted { get; set; }

    public CharacterProfile NPCTurnIn;
    public DialogueBase completedQuestDialogue;

    public virtual void InitializeQuest()
    {
        CurrentAmount = new int[RequiredAmount.Length];
    }

    public void Evaluate()
    {
        for(int i= 0; i <RequiredAmount.Length; i++)
        {
            if(CurrentAmount[i] < RequiredAmount[i])
            {
                return;
            }
        }

        Debug.Log("Quest is Completed");
        for(int i = 0; i<InsideManager.instance.buildingInside.inBuildingCharactersScene1.Length; i++)
        {
            if(InsideManager.instance.buildingInside.inBuildingCharactersScene1[i] == NPCTurnIn)
            {
                InsideManager.instance.buildingInside.inBuildingCharactersScene1[i].HasCompletedQuest = true;
                Debug.Log("We Found" + NPCTurnIn);
                InsideManager.instance.EnterBuilding();
                break;
            }
        }

        
        for (int i = 0; i < GameManager.instance.allDialogueTrigger.Length; i++)
        {
            if(GameManager.instance.allDialogueTrigger[i].targetNPC == NPCTurnIn)
            {
                NPCTurnIn.HasCompletedQuest = true;
                //InsideManager.instance.buildingInside.inBuildingCharactersScene1[i].HasCompletedQuest = true;
                //GameManager.instance.allDialogueTrigger[i].HasCompletedQuest = true;
                //GameManager.instance.allDialogueTrigger[i].CompletedQuestDialogue = completedQuestDialogue;
                Debug.Log("We Found" + NPCTurnIn);
                break;
            }
        }
        
        
    }
}
