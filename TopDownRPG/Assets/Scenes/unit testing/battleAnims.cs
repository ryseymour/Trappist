using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class battleAnims : MonoBehaviour
{

    public Battler myBattler;
    public List <Battler> party = new List<Battler>();
    public List <GameObject> partyObj = new List<GameObject>();

    public List <Battler> enemies = new List<Battler>();
    public List <GameObject> enemyObj = new List<GameObject>();
    // Start is called before the first frame update

    public GameObject floatText;

    public GameObject[] attackSprites;

    public int i_partySelect, i_enemySelect;
    bool b_selectParty, b_selectEnemy, b_selectMove;
    // public GameObject[] moveButtons;
    public Button[] moveButtons;
    void Start()
    {
        
        b_selectParty = true;
        i_partySelect = 0; //the int we use to track our position in the party list
        i_enemySelect = 0;//ditto
        SelectArrow(partyObj[0]);
        b_selectEnemy = false;
        b_selectMove = false;
        DisableMoves();

        moveButtons[0].onClick.AddListener(() => {BasicAttack(party[i_partySelect], enemies[i_enemySelect]); }); //basic attack needs multiple parameters and will 
    }

    // Update is called once per frame
    void Update()
    {
        

        if(b_selectParty){
            SelectParty();
        }else if(b_selectEnemy){
            SelectEnemy();
        }else if(b_selectMove){

        }
  
    }



    void SelectParty(){
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            UnselectArrow(partyObj[i_partySelect]);
            if(i_partySelect == 0){
                i_partySelect = partyObj.Count-1;
            }else{
                i_partySelect -= 1;
            }
            SelectArrow(partyObj[i_partySelect]);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            UnselectArrow(partyObj[i_partySelect]);
            if(i_partySelect == partyObj.Count-1){
                i_partySelect = 0;
            }else{
                i_partySelect += 1;
            }  
            SelectArrow(partyObj[i_partySelect]);   
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            b_selectEnemy = true;
            b_selectParty = false;
            print("end party select, begin enemy select");
            SelectArrow(enemyObj[i_enemySelect]);
        }
    }

    void SelectEnemy(){
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            UnselectArrow(enemyObj[i_enemySelect]);
            if(i_enemySelect == 0){
                i_enemySelect = enemyObj.Count-1;
            }else{
                i_enemySelect -= 1;
            }
            SelectArrow(enemyObj[i_enemySelect]);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            UnselectArrow(enemyObj[i_enemySelect]);
            if(i_enemySelect == enemyObj.Count-1){
                i_enemySelect = 0;
            }else{
                i_enemySelect += 1;
            }  
            SelectArrow(enemyObj[i_enemySelect]);   
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            b_selectEnemy = false;      
            b_selectMove = true;
            print("end enemy select, begin move select");
     
            PopulateMoves(party[i_partySelect]);
                     //testing the basic attack, remove 
                    //  BasicAttack(party[i_partySelect], enemies[i_enemySelect]);
        }
    }

    void SelectMove(){
        moveButtons[0].onClick.AddListener(() => {print("feck"); });
    }

    void DisableMoves(){
        foreach(Button btn in moveButtons){
            btn.interactable = false;
        }
        // foreach(GameObject obj in moveButtons){
        //     obj.GetComponent<Button>().interactable = false;
        // }
    }

    void EnableMoves(){
        foreach(Button btn in moveButtons){
            btn.interactable = true;
        }
        // foreach(GameObject obj in moveButtons){
        //     obj.GetComponent<Button>().interactable = true;
        // }
    }

    //basic attack should be locked in
    void PopulateMoves(Battler battler){   
        for(int i=1; i < battler.myAbilities.Count; i++){
            moveButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = battler.myAbilities[i].myName;
            moveButtons[i].onClick.AddListener(() => {
                RangeAttack(party[i_partySelect], enemies[i_enemySelect], battler.myAbilities[i]);
             });
        }
        EnableMoves();
    }


    void BasicAttack(Battler attacker, Battler target){
        if(attacker.myPhyattacks.Count > 0){ //make sure a basic attack move is assigned to the battler
            GameObject targObj = enemyObj[enemies.IndexOf(target)]; //get the in scene object of the enemy through the provided battler
            AddText(attacker.myPhyattacks[0].Damage.ToString(),  targObj);
            Instantiate(attackSprites[0], targObj.transform.position, Quaternion.identity);
            print("Character " + attacker.myName + " attacks " + target.myName + " for " + attacker.myPhyattacks[0].Damage + " damage");
        }else{
            print("no physical attacks available");
        }

        //UI elements and turn controls, copy/paste
        UnselectArrow(enemyObj[i_enemySelect]);    
        UnselectArrow(partyObj[i_partySelect]);    
        b_selectMove = false;
        b_selectParty = true;
        DisableMoves();
    }

    void RangeAttack(Battler attacker, Battler target, Ability _ability){
        GameObject targObj = enemyObj[enemies.IndexOf(target)];
        AddText(_ability.Damage.ToString(), targObj);
        print("Ability " + _ability.myName);
    }


    void UnselectArrow(GameObject obj){
        obj.transform.GetChild(0).gameObject.SetActive(false);
    }

    void SelectArrow(GameObject obj){
        obj.transform.GetChild(0).gameObject.SetActive(true);
    }


    void AddText(string txt, GameObject obj){
        floatText.GetComponent<TextMesh>().text = "" + txt;
        Instantiate(floatText, obj.transform.position, Quaternion.identity);        
    }
}
