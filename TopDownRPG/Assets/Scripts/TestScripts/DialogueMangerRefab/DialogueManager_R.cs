using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogueManager_R : MonoBehaviour
{
    public static DialogueManager_R instance;
    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image dialoguePortrait;
    public float delay = .0001f;
    public bool inDialogue;

    private bool isDialogueOption;
    public GameObject dialogueOptionUI;
    public GameObject[] optionButtons;
    private int optionsAmount;
    public TextMeshProUGUI questionText;
    private DialogueBase currentDialogue;

    public Queue<DialogueBase.NPCInfo> dialogueInfo = new Queue<DialogueBase.NPCInfo>();
    public GameObject dialogueBox;

    public Animator animator;
    private bool buffer;

    private bool isCurrentlyTyping;
    private string completeText;

    public bool EndBool;

    public delegate void OnDialogueLineCallBack(int dialogueLine);
    public OnDialogueLineCallBack onDialogueLineCallBack;
    private int totalLineCount;
    

    public void Awake()
    {
        if(instance != null)
        {

        }
        else
        {
            instance = this;
        }

        dialogueInfo = new Queue<DialogueBase.NPCInfo>();
    }

    public void EnqueueDialogue(DialogueBase db)
    {

        if (inDialogue || QuestManager.instance.InQuestUI) return;

        EndBool = false;
        buffer = true;
        inDialogue = true;
        StartCoroutine(BufferTimer());

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        currentDialogue = db;

        if (db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;
            questionText.text = dialogueOptions.questionText;
            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].SetActive(false);
            }


            for (int i = 0; i < optionsAmount; i++)
            {
                
                optionButtons[i].SetActive(true);
                optionButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogueOptions.optionsInfo[i].buttonName;
                UnityEventHandler myEventHandler =  optionButtons[i].GetComponent<UnityEventHandler>();
                myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
                if (dialogueOptions.optionsInfo[i].nextDialogue != null)
                {
                    myEventHandler.myDialogue = dialogueOptions.optionsInfo[i].nextDialogue;
                }
                else
                {
                    myEventHandler.myDialogue = null;
                }
            }
        }
        else
        {
            isDialogueOption = false;
        }

        foreach (DialogueBase.NPCInfo info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        totalLineCount = dialogueInfo.Count;

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        


        if (isCurrentlyTyping == true)
        {
            if (buffer == true) return;
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }

        if (dialogueInfo.Count == 0)
        {
            EndofDialogue();
            return;
        }

        
        dialogueBox.SetActive(true);
        animator.SetBool("IsOpen", true);

        DialogueBase.NPCInfo info = dialogueInfo.Dequeue();

        if(onDialogueLineCallBack != null)
        {
            onDialogueLineCallBack.Invoke(totalLineCount - dialogueInfo.Count);
        }
        completeText = info.myText;

        // dialogueName.text = info.myName;
        dialogueName.text = info.character.myName;
        dialogueText.text = info.myText;
       // dialoguePortrait.sprite = info.portrait;
        dialoguePortrait.sprite = info.character.myPortrait;

        //StopAllCoroutines();
        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.NPCInfo info)
    {
        isCurrentlyTyping = true;
        //dialogueText.text = "";
        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
           // yield return null;
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        
        dialogueText.text = completeText;
    }

    IEnumerator BufferTimer()
    {
        yield return new WaitForSeconds(.1f);
        buffer = false;
    }

    private void CheckIfDialogueQuest()
    {
        if(currentDialogue is DialogueQuest)
        {
            DialogueQuest DQ = currentDialogue as DialogueQuest;
            QuestManager.instance.SetQuestUI(DQ.Quest);
        }
    }

   

    public void EndofDialogue()
    {
        
        inDialogue = false;
        Debug.Log("InDialogue" + inDialogue);
        animator.SetBool("IsOpen", false);
        dialogueBox.SetActive(false);
        EndBool = true;

        OptionsLogic();
        CheckIfDialogueQuest();
        //Should do a switch statement here
        
    }

    private void OptionsLogic()
    {
        if (isDialogueOption == true)
        {
            dialogueOptionUI.SetActive(true);

        }
    }

    public void CloseOptions()
    {
        dialogueOptionUI.SetActive(false);
        animator.SetBool("IsOpen", false);
        dialogueBox.SetActive(false);
        inDialogue = false;
    }

    

    private void Update()
    {
        // Debug.Log(inDialogue);
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(EndBool == true)
            {
                EndBool = false;
                inDialogue = false;
                return;
            }

            if (inDialogue)
            {
                DequeueDialogue();
            }
            
        }
    }
}
