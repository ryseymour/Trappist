using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string dName;
    public int dialogueTree;
    public int dialoguePart = 2;
    private int dialoguePartCheck;
    public bool inital;
    public GameObject speaker;

    public float interactRange = 4f;

    /// <summary>
    /// updated  dialogue method
    /// </summary>

    public DialogueBase dialogue;

    public void Start()
    {
        dialoguePartCheck = dialoguePart;
        speaker = this.gameObject;
    }
    
    public void TriggerDialogue()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //FindObjectOfType<NPCManger>().StartDialogue(dName);
        }
        
    }

    public void Update()
    {

        if (Vector2.Distance(gameObject.transform.position, GameManager.instance.player.position) < interactRange)
        {
            /*
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Interact();
            }
            */


            if (Input.GetKeyDown(KeyCode.Space)&& inital == false)
            {




                Debug.Log("speaking");
                FindObjectOfType<NPCManger>().StartDialogue(dName, speaker);
                inital = true;





            }
        }
    }

    public virtual void Interact()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

}
