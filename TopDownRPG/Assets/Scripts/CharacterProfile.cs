using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "New Profile", menuName = "Character Profile")]
public class CharacterProfile : ScriptableObject
{
    public string myName;
    public Sprite myPortrait;

    public GameObject myCharacterModel;

    //public DialogueTrigger_R Dtrigger;
    [Header("Basic Dialogues Info")]
    public DialogueBase[] DB;
    [HideInInspector] public int index;
    public bool nextDialogueOnInteract;


    public bool HasCompletedQuest; // { get; set; }
    public DialogueBase CompletedQuestDialogue;// { get; set; }

    [Header("Quest Dialogue Info")]
    public bool hasActiveQuest;
    public DialogueQuest[] dialogueQuests;
    public int QuestIndex { get; set; }

    [Header("Target Info")]
    public bool hasActiveDialogueEvent;
    public int targetIndex;
    public int targetLine;

    public UnityEvent unityEvent;
}




