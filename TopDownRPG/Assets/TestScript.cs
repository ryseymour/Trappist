using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    public DialogueBase dialogue;
    public Item item;
    public int scene;
    bool loaded;

   // public QuestBase quest;

    private void Start()
    {
        //quest.InitializeQuest();
    }


    public void TriggerDialogue()
    {
        //DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            TriggerDialogue();
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryManager.instance.AddItem(item);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            InventoryManager.instance.RemoveItem(item);
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            if(!loaded)
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
               

                loaded = true;
            }
        }
    }

}
