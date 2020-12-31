using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsideManager : MonoBehaviour
{
    public static InsideManager instance;
    public Button[] peopleInside;
    public Building buildingInside;
    public Image dialoguePortrait;
    public int ZeroDialogue;

    public Transform[] partyTransforms;
    public Transform[] npcTransforms;

    public bool imInside;



    // Start is called before the first frame update
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterBuilding ()
    {
        //buildingInside = TownManager.instance.town.buildings[enter];
        Debug.Log("test enter");
        for (int i = 0; i < buildingInside.inBuildingCharactersScene1.Length; i++)      //need to update this
            {
            Debug.Log(buildingInside.inBuildingCharactersScene1[i]);
            
       
                Debug.Log("image person swap");
           // var imageofPerson = buildingInside.inBuildingCharactersScene1[i].myPortrait;

            // peopleInside[i].GetComponent<Image>().sprite = imageofPerson;
            peopleInside[i].GetComponent<DialogueTrigger_R>().targetNPC = buildingInside.inBuildingCharactersScene1[i];
           //peopleInside[i].GetComponent<QuestDialogueTrigger>().targetNPC = buildingInside.inBuildingCharactersScene1[i];

            var modelof = buildingInside.inBuildingCharactersScene1[i].myCharacterModel;
            Instantiate(modelof, npcTransforms[i]);

            var DialogueChangeArray = buildingInside.inBuildingCharactersScene1[i].DB.Length;

            //var ChangeDialNumber = peopleInside[i].GetComponent<DialogueTrigger_R>().DB.Length;

            //var peopleDial = peopleInside[i].GetComponent<DialogueTrigger_R>().DB;
            //*
            peopleInside[i].GetComponent<DialogueTrigger_R>().DB = new DialogueBase[buildingInside.inBuildingCharactersScene1[i].DB.Length];//changes based on number of dialogue options that are in the character profile.
            npcTransforms[i].GetComponent<DialogueTrigger_R>().DB = new DialogueBase[buildingInside.inBuildingCharactersScene1[i].DB.Length];

           // peopleInside[i].GetComponent<QuestDialogueTrigger>().DB = new DialogueBase[buildingInside.inBuildingCharactersScene1[i].DB.Length];//changes based on number of dialogue options that are in the character profile.
            npcTransforms[i].GetComponent<QuestDialogueTrigger>().DB = new DialogueBase[buildingInside.inBuildingCharactersScene1[i].DB.Length];
            npcTransforms[i].GetComponent<QuestDialogueTrigger>().dialogueQuests = new DialogueQuest[buildingInside.inBuildingCharactersScene1[i].dialogueQuests.Length];

            for (int y = 0; y < buildingInside.inBuildingCharactersScene1[i].DB.Length; y++)
            {
                //*
                //peopleInside[i].GetComponent<DialogueTrigger_R>().DB[y] = buildingInside.inBuildingCharactersScene1[i].DB[y];//update this
                //npcTransforms[i].GetComponent<DialogueTrigger_R>().DB[y] = buildingInside.inBuildingCharactersScene1[i].DB[y];

                //peopleInside[i].GetComponent<QuestDialogueTrigger>().DB[y] = buildingInside.inBuildingCharactersScene1[i].DB[y];
                npcTransforms[i].GetComponent<QuestDialogueTrigger>().DB[y] = buildingInside.inBuildingCharactersScene1[i].DB[y];


                //(doublecheck)peopleInside[i].GetComponent<DialogueTrigger_R>().nextDialogueOnInteract = buildingInside.inBuildingCharactersScene1[i].nextDialogueOnInteract;
                //npcTransforms[i].GetComponent<DialogueTrigger_R>().nextDialogueOnInteract = buildingInside.inBuildingCharactersScene1[i].nextDialogueOnInteract;

                //peopleInside[i].GetComponent<QuestDialogueTrigger>().nextDialogueOnInteract = buildingInside.inBuildingCharactersScene1[i].nextDialogueOnInteract;
                npcTransforms[i].GetComponent<QuestDialogueTrigger>().nextDialogueOnInteract = buildingInside.inBuildingCharactersScene1[i].nextDialogueOnInteract;

                npcTransforms[i].GetComponent<QuestDialogueTrigger>().hasActiveQuest = buildingInside.inBuildingCharactersScene1[i].hasActiveQuest;
                npcTransforms[i].GetComponent<QuestDialogueTrigger>().HasCompletedQuest = buildingInside.inBuildingCharactersScene1[i].HasCompletedQuest;

                if(buildingInside.inBuildingCharactersScene1[i].HasCompletedQuest == true)
                {
                    npcTransforms[i].GetComponent<QuestDialogueTrigger>().CompletedQuestDialogue = buildingInside.inBuildingCharactersScene1[i].CompletedQuestDialogue;
                    break;
                }

                if (buildingInside.inBuildingCharactersScene1[i].hasActiveQuest == true)
                {
                    npcTransforms[i].GetComponent<QuestDialogueTrigger>().dialogueQuests[y] = buildingInside.inBuildingCharactersScene1[i].dialogueQuests[y];
                    Debug.Log("test this quest line");
                    break;
                }

                if(buildingInside.inBuildingCharactersScene1[i].hasActiveDialogueEvent == true)
                {
                    npcTransforms[i].GetComponent<QuestDialogueTrigger>().hasActiveDialogueEvent = buildingInside.inBuildingCharactersScene1[i].hasActiveDialogueEvent;
                    npcTransforms[i].GetComponent<QuestDialogueTrigger>().unityEvent = buildingInside.inBuildingCharactersScene1[i].unityEvent;
                    npcTransforms[i].GetComponent<QuestDialogueTrigger>().targetLine = buildingInside.inBuildingCharactersScene1[i].targetLine;
                    break;
                }
                
            }
            


            //Sprite imageofPerson = buildingInside.inBuildingCharacters[i].myPortrait;
            // peopleInside[i].image.sprite = imageofPerson;
        }
            //var texter = LocationButtons[i].GetComponentInChildren<TextMeshProUGUI>();

           // texter.text = town.buildings[i].buildingName;

        }
    }

