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
    }

    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public Image dialoguePortrait;

    public Queue<DialogueBase.NPCInfo> dialogueInfo = new Queue<DialogueBase.NPCInfo>();

    public void EnqueueDialogue(DialogueBase db)
    {
        if (inDialogue) return;
        buffer = true;
        inDialogue = true;
        dialogueInfo.Clear();
        animator.SetBool("IsOpen", true);
        StartCoroutine(BufferTimer());

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
        
        if (dialogueInfo.Count == 0)
        {
            EndDialogue();
           // sentencePacer = false;
            return;
        }

        DialogueBase.NPCInfo info = dialogueInfo.Dequeue();
        dialogueName.text = info.myName;
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;
        
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
        animator.SetBool("IsOpen", false);
        inDialogue = false;
        //dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(inDialogue)
            {
                DequeueDialogue();
            }
        }
    }


}
