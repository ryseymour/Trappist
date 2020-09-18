using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager_R : MonoBehaviour
{
    public static DialogueManager_R instance;
    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image dialoguePortrait;
    public float delay = .0001f;
    public bool inDialogue;

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

        if (inDialogue) return;

        EndBool = false;
        buffer = true;
        inDialogue = true;
        StartCoroutine(BufferTimer());

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        

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

        dialogueName.text = info.myName;
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;

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

    

   

    public void EndofDialogue()
    {
        
        inDialogue = false;
        Debug.Log("InDialogue" + inDialogue);
        animator.SetBool("IsOpen", false);
        dialogueBox.SetActive(false);
        EndBool = true;
    }

    public void CloseOptions()
    {
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
