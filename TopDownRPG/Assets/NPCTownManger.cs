using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTownManger : MonoBehaviour
{
    public Button firstButton;
    public GameObject InsideUI;
    private bool InitialPop;


    // Start is called before the first frame update
    void Awake()
    {
        InitialPop = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (InsideUI.activeSelf == true)
        {
            if (InitialPop == true)
            {
                firstButton.Select();
                InitialPop = false;
            }

        }
        else
        {
            InitialPop = true;
        }

    }
}

