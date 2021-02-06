using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleInfo : MonoBehaviour
{


    public TextMeshProUGUI action, playerName, playerClass, playerHealth;
    public TextMeshProUGUI targetName, targetClass, targetHealth; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SelectParty(){
        action.text = "Select Party Member";
    }



    public void DisplayPartyCharacter(Battler b){
        playerName.text = b.myName;
        playerClass.text = b.myClass;
        playerHealth.text = "hp: " + b.mycurrentHealth + "/" + b.myHealth;
        
    }


    public void DisplayTargetCharacter(Battler b){
        targetName.text = b.myName;
        targetClass.text = b.myClass;
        targetHealth.text = "hp: " + b.mycurrentHealth + "/" + b.myHealth;
    }

    public void ClearPlayerInfo(){
        playerName.text = "";
        playerClass.text = "";
        playerHealth.text = "";
    }

    public void ClearTargetInfo(){
        targetName.text = "";
        targetClass.text = "";
        targetHealth.text = "";
    }

    public void SelectAction(){

    }



}
