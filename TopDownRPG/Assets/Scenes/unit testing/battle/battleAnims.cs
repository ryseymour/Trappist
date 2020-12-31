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

    public int i_partySelect, i_enemySelect, i_partySelect_2;
    //Bools to control the battle state
    public bool b_selectParty, b_selectEnemy, b_selectMove;

    //bool to check if using physical attacks or abilities
    public bool attackReady, abilityReady, itemReady;
   
    public Button[] moveButtons;
    public GameObject actionPanel;
    public GameObject battleInfo;

    PhyAttack selectedAttack;
    Ability selectedAbility;

    void Start()
    {
        battleInfo.GetComponent<BattleInfo>().SelectParty();
        b_selectParty = true;
        i_partySelect = 0; //the int we use to track our position in the party list
        i_enemySelect = 0;//ditto
        i_partySelect_2 = 0;
        SelectArrow(partyObj[0]);
        b_selectEnemy = false;
        b_selectMove = false;
        DisableMoves();
        actionPanel.SetActive(false);
        //moveButtons[0].onClick.AddListener(() => {BasicAttack(party[i_partySelect], enemies[i_enemySelect]); }); //basic attack needs multiple parameters and will 
    }

    // Update is called once per frame
    void Update()
    {     
    
        if(b_selectParty){
            SelectParty();
        }else if(b_selectMove){
            if(!attackReady && !abilityReady && !itemReady){
                 actionPanel.SetActive(true);
            }               
           // PopulateMoves(party[i_partySelect]);
        }else if(b_selectEnemy){         
                SelectEnemy();             
        }
      }



    void SelectParty(){
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            print("left arrow " + i_partySelect );
            UnselectArrow(partyObj[i_partySelect]);
            if(i_partySelect == 0){
                print("Left arrow detects 0");
                i_partySelect = partyObj.Count-1;
            }else{
                i_partySelect -= 1;
            }
            SelectArrow(partyObj[i_partySelect]);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            print("right arrow");
            UnselectArrow(partyObj[i_partySelect]);
            if(i_partySelect == partyObj.Count-1){
                i_partySelect = 0;
            }else{
                i_partySelect += 1;
            }  
            SelectArrow(partyObj[i_partySelect]);   
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            b_selectMove = true;
            b_selectParty = false;
            print("end party select, begin enemy select");         
        }
    }

    void SelectPartyTarget(){
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            UnselectArrow(partyObj[i_partySelect_2]);
            if(i_partySelect_2 == 0){
        
                i_partySelect_2 = partyObj.Count-1;
            }else{
                i_partySelect_2 -= 1;
            }
            SelectArrow(partyObj[i_partySelect_2]);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
           
            UnselectArrow(partyObj[i_partySelect_2]);
            if(i_partySelect_2 == partyObj.Count-1){
                i_partySelect_2 = 0;
            }else{
                i_partySelect_2 += 1;
            }  
            SelectArrow(partyObj[i_partySelect_2]);   
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            UnselectArrow(enemyObj[i_enemySelect]);
            UnselectArrow(partyObj[i_partySelect]);
             UnselectArrow(partyObj[i_partySelect_2]);
            DisableMoves(true);
            StartCoroutine(playerRearm());
            print("party target selected, applying effect");         
        }
    }

    void SelectEnemy(){        

        if(selectedAbility != null && !selectedAbility.targetEnemy){           
            SelectPartyTarget();
        }else{
            //manual control
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
                
                if(attackReady)
                    ExecuteAttack(selectedAttack);
                if(abilityReady)
                    ExecuteAbility(selectedAbility);
                //if(abilityReady)                    
                print("end enemy select, begin move select");
                UnselectArrow(enemyObj[i_enemySelect]);
                UnselectArrow(partyObj[i_partySelect]);
                DisableMoves(true);
                //some kind of delay and then re-enable party select and the select arrow
                IEnumerator delay = playerRearm(2.0f);
                StartCoroutine(delay);
            
            }
        }

    }



    void DisableMoves(bool hide = false){
        foreach(Button btn in moveButtons){
            btn.interactable = false;
            if(hide)
                btn.gameObject.SetActive(false);
        }
    
    }

    void EnableMoves(){
        foreach(Button btn in moveButtons){
            btn.interactable = true;
            btn.gameObject.SetActive(true);
        }      
    }

    //basic attack should be locked in
    void PopulateMoves(Battler battler){   
        for(int i=1; i < battler.myAbilities.Count; i++){
            moveButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = battler.myAbilities[i-1].myName;          
        }
        EnableMoves();
    }


    //handles the actual moment the button gets clicked
    public void SelectMove(int val){
        if(abilityReady){
            print(party[i_partySelect].myAbilities[val]);
            selectedAbility = party[i_partySelect].myAbilities[val];
            if(selectedAbility.targetEnemy)
                SelectArrow(enemyObj[i_enemySelect]);                
        }

        if(attackReady){
            print(party[i_partySelect].myPhyattacks[val]);
            selectedAttack = party[i_partySelect].myPhyattacks[val];
            SelectArrow(enemyObj[i_enemySelect]);
        }
       
        DisableMoves();
        b_selectEnemy = true;
        b_selectMove = false;        
    }


    public void ExecuteAttack(PhyAttack t){
        print(t.myName + " attack does " + t.Damage + " damage");
        t.AttackAnim( enemyObj[i_enemySelect]);
        AddText(t.Damage.ToString(), enemyObj[i_enemySelect]);
    }

    public void ExecuteAbility(Ability _a){
        if(!_a.targetEnemy){
            print("this should heal");
        }
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


    void ClearEnemySelector(){
        for(int i=0; i<enemyObj.Count; i++){
            UnselectArrow(enemyObj[i]);
        }
    }

    IEnumerator playerRearm(float t=2){
        yield return new WaitForSeconds(t);
        b_selectParty = true;
        i_partySelect = 0;
        SelectArrow(partyObj[i_partySelect]);
        attackReady = false;
        abilityReady = false;
        itemReady = false;
        selectedAbility = null;
        selectedAttack = null;
    }

    public void PopulatePhysAttacks(){
        attackReady = true;
        abilityReady = false;
        itemReady = false;
        actionPanel.SetActive(false);
        for(int i=0; i < party[i_partySelect].myPhyattacks.Count; i++){
            print("Physical attacks " + party[i_partySelect].myPhyattacks[i]);      
            moveButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = party[i_partySelect].myPhyattacks[i].myName; 
            moveButtons[i].gameObject.SetActive(true);
            moveButtons[i].interactable = true;          
        }        
    }

    public void PopulateAbilities(){
        abilityReady = true;
        attackReady = false;
        itemReady = false;
        actionPanel.SetActive(false);
        for(int i=0; i < party[i_partySelect].myAbilities.Count; i++){
            moveButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = party[i_partySelect].myAbilities[i].myName;
            moveButtons[i].gameObject.SetActive(true);
            moveButtons[i].interactable = true; 
        }
    }

    public void BackButton(){
        if(b_selectMove && !attackReady && !abilityReady){
            b_selectParty = true;
            b_selectMove = false;
        }else if(abilityReady){
            if(selectedAbility != null){
                ClearEnemySelector();
                b_selectEnemy = false;
                b_selectMove = true;
                PopulateAbilities();
                selectedAbility = null;
                selectedAttack = null;
            }else{
                abilityReady = false;
                DisableMoves(true);
            }          
        }else if(attackReady){
            if(selectedAttack != null){
                ClearEnemySelector();               
                b_selectEnemy = false;
                b_selectMove = true;
                PopulatePhysAttacks();
                selectedAbility = null;
                selectedAttack = null;
            }else{
                DisableMoves(true);
                attackReady = false;
            }              
        }else if(itemReady){
            itemReady = false;
            DisableMoves(true);
        }else{
            print("nothing assigned to go back from");
        }
            
    }

}
