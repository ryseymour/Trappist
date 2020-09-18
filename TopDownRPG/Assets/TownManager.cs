using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownManager : MonoBehaviour
{
    public static TownManager instance;
    public Button firstButton;
    public GameObject TownUI;
    private bool InitialPop;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        InitialPop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TownUI.activeSelf == true)
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
