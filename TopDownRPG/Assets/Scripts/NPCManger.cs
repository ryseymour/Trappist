using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class NPCManger : MonoBehaviour
{
    public static NPCManger instance;
    public DialogueTrigger_R[] allDialogueTrigger;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DialogueTriggerV()
    {
        allDialogueTrigger = FindObjectsOfType<DialogueTrigger_R>();
    }

}
