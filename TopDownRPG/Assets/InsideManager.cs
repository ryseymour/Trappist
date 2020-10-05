using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsideManager : MonoBehaviour
{
    public static InsideManager instance;
    public Transform[] peopleInside;
    public Building buildingInside;


    // Start is called before the first frame update
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterBuilding ()
    {
        for (int i = 0; i < buildingInside.inBuildingCharacters.Length; i++)      
            {
            if(peopleInside[i] == buildingInside.inBuildingCharacters[i])
            {
                Debug.Log("image person swap");
                var imageofPerson = buildingInside.inBuildingCharacters[i].myPortrait;
                peopleInside[i].GetComponent<Button>().image.sprite = imageofPerson;
            }
            //var texter = LocationButtons[i].GetComponentInChildren<TextMeshProUGUI>();

           // texter.text = town.buildings[i].buildingName;

        }
    }
}
