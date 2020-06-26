using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class NPCManger : MonoBehaviour
{

    public List<NPCclass> npcDB = new List<NPCclass>();
    public List<GameObject> npcs = new List<GameObject>();
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private bool buffer;
    private bool sentencePacer;
    public GameObject spker;
    
    
    //public Textme dialogueText;
    public Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        foreach (var n in npcDB)
        {
            //going into the dialogue trigger to assign the names of the npcs.
            //when activated the npcs will run a function in the game manager passing in the 
            //npcs name...hopefully.

            DialogueTrigger Dt =  n.spriteInWorld.GetComponent<DialogueTrigger>();
            Dt.dName = n.name;

            if(n.wanderUpDown == true)
            {
                n.wanderLeftRight = false;
                n.wanderAll = false;
                //Debug.Log(n.name);
                n.spriteInWorld.GetComponent<Move_updown>().enabled = true;
                
            }

            else if (n.wanderLeftRight == true)
                {
                n.wanderUpDown = false;
                    n.wanderAll = false;
                   // Debug.Log(n.name);
                n.spriteInWorld.GetComponent<Move_lftrgt>().enabled = true;
                //gameObject.GetComponent<VillagerMovementManger>().enabled = false;
            }

            else if (n.wanderAll == true)
            {
                n.wanderUpDown = false;
                n.wanderLeftRight = false;
               // Debug.Log(n.name);
                n.spriteInWorld.GetComponent<VillagerMovementManger>().enabled = true;
                //gameObject.GetComponent<VillagerMovementManger>().enabled = false;
            }
        }
    }
    //sentences
    public void StartDialogue(string dname, GameObject speaker)//might need to add a counter here
    {
        spker = speaker;
        
        animator.SetBool("IsOpen", true);
        foreach (var n in npcDB)
        {
            //n.sentences.Clear();
            if (dname == n.name)
                {
                var dialogue = n;
                Debug.Log(n);
                Debug.Log(dname);
                Debug.Log(n.name);
                //Debug.Log(n.setences);

                nameText.text = dialogue.name;
                //nameText.text = dialogue.name;

                //
                sentences.Clear();
                
                foreach (string sentence in dialogue.sentences)
                {
                    sentences.Enqueue(sentence);

                }
                

            }
            
        }
        
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
        if (sentences.Count==0)
        {
            EndDialogue();
            sentencePacer = false;
            return;
        }
        
        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        //Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        sentencePacer = true;
    }

   


    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        //n.spriteInWorld.GetComponent<Move_updown>().enabled = true;
        DialogueTrigger spk = spker.GetComponent<DialogueTrigger>();
        spk.inital = false;
            //spker.GetComponent<DialogueTrigger>();

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && sentencePacer == true )
            {
            DisplayNextSentence();
        }
    }

    
}
