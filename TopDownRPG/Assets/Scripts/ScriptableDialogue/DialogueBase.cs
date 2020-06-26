using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName ="Dialogues")]

public class DialogueBase : ScriptableObject
{
    [System.Serializable]
    public class NPCInfo
    {
        public string myName;
        public Sprite portrait;
        [TextArea(4, 8)]
        public string myText;
        
    }
    [Header("Insert dialogue information below")]
    public NPCInfo[] dialogueInfo;
}
