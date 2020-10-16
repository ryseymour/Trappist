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

    public void EnterBuilding (int enter)
    {
        buildingInside = TownManager.instance.town.buildings[enter];
        Debug.Log("test enter");
        for (int i = 0; i < buildingInside.inBuildingCharactersScene1.Length; i++)      //need to update this
            {
            Debug.Log(buildingInside.inBuildingCharactersScene1[i]);
            
       
                Debug.Log("image person swap");
            var imageofPerson = buildingInside.inBuildingCharactersScene1[i].myPortrait;

             peopleInside[i].GetComponent<Image>().sprite = imageofPerson;
            peopleInside[i].GetComponent<DialogueTrigger_R>().targetNPC = buildingInside.inBuildingCharactersScene1[i];

            var DialogueChangeArray = buildingInside.inBuildingCharactersScene1[i].DB.Length;

            //var ChangeDialNumber = peopleInside[i].GetComponent<DialogueTrigger_R>().DB.Length;

            //var peopleDial = peopleInside[i].GetComponent<DialogueTrigger_R>().DB;

            peopleInside[i].GetComponent<DialogueTrigger_R>().DB = new DialogueBase[buildingInside.inBuildingCharactersScene1[i].DB.Length];//changes based on number of dialogue options that are in the character profile.


            for (int y = 0; y < buildingInside.inBuildingCharactersScene1[i].DB.Length; y++)
            {
                peopleInside[i].GetComponent<DialogueTrigger_R>().DB[y] = buildingInside.inBuildingCharactersScene1[i].DB[y];//update this

                peopleInside[i].GetComponent<DialogueTrigger_R>().nextDialogueOnInteract = buildingInside.inBuildingCharactersScene1[i].nextDialogueOnInteract;


            }
            


            //Sprite imageofPerson = buildingInside.inBuildingCharacters[i].myPortrait;
            // peopleInside[i].image.sprite = imageofPerson;
        }
            //var texter = LocationButtons[i].GetComponentInChildren<TextMeshProUGUI>();

           // texter.text = town.buildings[i].buildingName;

        }
    }

