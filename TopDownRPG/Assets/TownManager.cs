using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TownManager : MonoBehaviour
{
    public static TownManager instance;
    public Button firstButton;
    public GameObject TownUI;
    private bool InitialPop;

    public Button[] LocationButtons;

    public Transform[] BuildingTransforms;



    public Town town;

    public Building[] BuildingsInside;


    // Start is called before the first frame update
    private void Awake()
    {
        LoadTown();
        if (instance == null)
        {
            instance = this;
        }
        InitialPop = true;

       // LoadTown();
    }

    // Update is called once per frame
    void Update()
    {


      //Cole stuff
      if(Input.GetKeyDown(KeyCode.Space)){
          print("spacebar");
          SceneManager.LoadScene("grid-live", LoadSceneMode.Additive);
      }

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


    public void LoadTown()
    {
        Debug.Log("test");
        /*
        for (int i = 0; i < LocationButtons.Length; i++)
        {
            var texter = LocationButtons[i].GetComponentInChildren<TextMeshProUGUI>();

            texter.text = town.buildings[i].buildingName;
            BuildingsInside[i] = town.buildings[i];
        }

    */

        for (int i = 0; i < BuildingTransforms.Length; i++)
        {
            var buildingModel =town.buildings[i].buildingModel;
            Instantiate(buildingModel, BuildingTransforms[i]);
        }
    }
}
