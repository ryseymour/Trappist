using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Animator animator;
    public GameObject dialogueBox;
    public bool inDialogue;
    private bool buffer;
    private bool isDialogueOption;
    public GameObject dialogueOptionUI;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("fix this" + gameObject.name);
        }
        else
        {
            instance = this;
        }

        //dialogueBox.SetActive(false);
    }

    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image dialoguePortrait;

    public Queue<DialogueBase.NPCInfo> dialogueInfo = new Queue<DialogueBase.NPCInfo>();

    public void EnqueueDialogue(DialogueBase db)
    {
        if (inDialogue) return;

        dialogueBox.SetActive(true);
        buffer = true;
        inDialogue = true;
        dialogueInfo.Clear();
        animator.SetBool("IsOpen", true);
        StartCoroutine(BufferTimer());

        if(db is DialogueOptions)
        {
            isDialogueOption = true;
        }
        else
        {
            isDialogueOption = false;
        }

        foreach (DialogueBase.NPCInfo info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        //this is in a differnt spot in the tutorial.
        if (buffer == true) return;
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        Debug.Log(dialogueInfo.Count);
        if (dialogueInfo.Count == 0)
        {
            Debug.Log("close dialogue");
            EndDialogue();
           // sentencePacer = false;
            return;
        }

        DialogueBase.NPCInfo info = dialogueInfo.Dequeue();
       // dialogueName.text = info.myName;
        dialogueText.text = info.myText;
       // dialoguePortrait.sprite = info.portrait;
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(info));
        

    }
    IEnumerator TypeSentence(DialogueBase.NPCInfo info)
    {

        dialogueText.text = "";
        foreach (char letter in info.myText.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        //sentencePacer = true;
    }

    IEnumerator BufferTimer()
    {
        yield return new WaitForSeconds(0.1f);
        buffer = false;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        Debug.Log("end dialogue");
        animator.SetBool("IsOpen", false);
        inDialogue = false;
        if(isDialogueOption == true)
        {
            dialogueOptionUI.SetActive(true);
        }

        //return;
        //dialogueBox.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(inDialogue);
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(inDialogue)
            {
                DequeueDialogue();
            }
        }
    }


}
