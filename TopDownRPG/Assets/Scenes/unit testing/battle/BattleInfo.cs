using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleInfo : MonoBehaviour
{


    public TextMeshProUGUI action;
    // Start is called before the first frame update
    void Start()
    {
        action.text = "test";
    }

    public void SelectParty(){
        action.text = "Select Party Member";
    }

    public void DisplayPartyCharacter(){
        
    }

    public void SelectAction(){

    }

}
