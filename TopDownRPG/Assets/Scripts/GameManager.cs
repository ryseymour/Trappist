using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Initialize");
            quest.InitializeQuest();
        }
    }

    public Transform player;
    public Transform playerPin;

    public GameObject PlayerProof;

    public QuestBase quest;//get rid of this

}
