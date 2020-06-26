﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class TestScript : MonoBehaviour
{
    public DialogueBase dialogue;
    public Item item;

    public void TriggerDialogue()
    {
        DialogueManager.instance.EnqueueDialogue(dialogue);
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
    }

}
