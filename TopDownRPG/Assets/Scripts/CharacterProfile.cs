using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

}




