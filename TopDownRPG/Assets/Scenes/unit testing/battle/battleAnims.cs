using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class battleAnims : MonoBehaviour
{

    public Battler myBattler;
    public List <Battler> party = new List<Battler>();//these need to be loaded in from somewhere
    public List <GameObject> partyObj = new List<GameObject>(); //just the object in the scene, custom models per character eventually

    public List <Battler> enemies = new List<Battler>(); //these need to be loaded in from somewhere
    public List <GameObject> enemyObj = new List<GameObject>(); //just the object in the scene, custom models per character eventually


    public GameObject floatText;

    public GameObject[] attackSprites;

    public int i_partySelect, i_enemySelect, i_partySelect_2;
    //Bools to control the battle state
    public bool b_selectParty, b_selectEnemy, b_selectMove;

    //bool to check if using physical attacks or abilities
    public bool attackReady, abilityReady, itemReady, battleEnd;
   
    public Button[] moveButtons;
    public GameObject actionPanel;
    public GameObject battleInfo, endPanel;
    
    public Item[] loot;
    public GameObject[] lootUI; //preset UI elements, -text - image

    PhyAttack selectedAttack;
    Ability selectedAbility;

    void Awake()
    {
        BattleInit();     
    }

    void SetEnemyHealth(){
        foreach(Battler enemy in enemies){
            enemy.mycurrentHealth = enemy.myHealth;
        }
    }

    void BattleInit(){
        //need a function to load in rosters
            //need to create the appropriate number of enemies (maybe just activate them) 
        //need to load in loot list 
         b_selectParty = true;// this is what triggers the start of the battle loop

        i_partySelect = 0; //the int we use to track our position in the party list
        i_enemySelect = 0;//ditto
        i_partySelect_2 = 0;//ditto

        SelectArrow(partyObj[0]);
        b_selectEnemy = false;
        b_selectMove = false;

        DisableMoves();        
        DisableMoves(true);
        SetEnemyHealth();
        
        //UI
        actionPanel.SetActive(false); //UI
        battleInfo.GetComponent<BattleInfo>().SelectParty();
        battleInfo.GetComponent<BattleInfo>().ClearTargetInfo();
        battleEnd = false;      
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
        }else if(b_selectEnemy){         
            SelectEnemy();             
        }
      }


//party/target Selection
    void SelectParty(){
        if(Input.GetKeyDown(KeyCode.LeftArrow)){         
            UnselectArrow(partyObj[i_partySelect]);
            if(i_partySelect == 0){               
                i_partySelect = partyObj.Count-1;                
            }else{
                i_partySelect -= 1;
            }
            SelectArrow(partyObj[i_partySelect]);
            battleInfo.GetComponent<BattleInfo>().DisplayPartyCharacter(party[i_partySelect]);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){           
            UnselectArrow(partyObj[i_partySelect]);
            if(i_partySelect == partyObj.Count-1){
                i_partySelect = 0;
            }else{
                i_partySelect += 1;
            }  
            SelectArrow(partyObj[i_partySelect]);
            battleInfo.GetComponent<BattleInfo>().DisplayPartyCharacter(party[i_partySelect]);   
          
        }
        battleInfo.GetComponent<BattleInfo>().DisplayPartyCharacter(party[i_partySelect]);   
        if(Input.GetKeyDown(KeyCode.Return)){           
            print("end party select, begin action select");       
            SelectPartyPiece(partyObj[i_partySelect]);            
        }
    }

    public void ClickPiece(GameObject obj){
        if(b_selectParty){
            print(partyObj.IndexOf(obj));
        }
    }
    //this fires when you click on the player piece
    public void SelectPartyPiece(GameObject obj){
       if(b_selectParty){          
            UnselectArrow(partyObj[i_partySelect]);
            //setting the integer of the party select is important because the variable runs other stuff, maybe clean that up eventually 
            i_partySelect = partyObj.IndexOf(obj); //reset the integer holding the selected party member, this is used for later damage calculations
            SelectArrow(partyObj[i_partySelect]); //move the selected arrow to the object you clicked
            obj.transform.GetChild(0).gameObject.GetComponent<BattlePiece>().activeSelect = false; ///change the "active" selector for the arrow object
            battleInfo.GetComponent<BattleInfo>().action.text = "Select action";
            b_selectMove = true;
            b_selectParty = false;
        }else{
            print("else statement");
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

        battleInfo.GetComponent<BattleInfo>().DisplayTargetCharacter(party[i_partySelect_2]);
        
        if(Input.GetKeyDown(KeyCode.Return)){
            UnselectArrow(enemyObj[i_enemySelect]);
            UnselectArrow(partyObj[i_partySelect]);
            UnselectArrow(partyObj[i_partySelect_2]);
            DisableMoves(true);
            StartCoroutine(playerRearm());
            partyObj[i_partySelect].transform.GetChild(0).gameObject.GetComponent<BattlePiece>().activeSelect = false;
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
            //Show target info
            battleInfo.GetComponent<BattleInfo>().DisplayTargetCharacter(enemies[i_enemySelect]);

            if(Input.GetKeyDown(KeyCode.Return)){
                b_selectEnemy = false;      
         
                print("end enemy select, begin move select");
                UnselectArrow(enemyObj[i_enemySelect]);
                UnselectArrow(partyObj[i_partySelect]);
                DisableMoves(true);
                if(attackReady)
                    ExecuteAttack(selectedAttack);
                if(abilityReady)
                    ExecuteAbility(selectedAbility);
                //some kind of delay and then re-enable party select and the select arrow
                IEnumerator delay = playerRearm(2.0f);
                StartCoroutine(delay);            
            }
        }
    }

    public void SelectEnemyPiece(GameObject obj){
        if(b_selectEnemy){
            //i_partySelect = partyObj.IndexOf(obj);
            print("running enemy piece select");
            i_enemySelect = enemyObj.IndexOf(obj);

            UnselectArrow(enemyObj[i_enemySelect]);
            UnselectArrow(partyObj[i_partySelect]);
            DisableMoves(true);
            if(attackReady)
                ExecuteAttack(selectedAttack);
            if(abilityReady)
                ExecuteAbility(selectedAbility);
            //some kind of delay and then re-enable party select and the select arrow
            IEnumerator delay = playerRearm(2.0f);
            StartCoroutine(delay);         
        }
    }

    void UnselectArrow(GameObject obj){
        obj.transform.GetChild(0).gameObject.SetActive(false);
    }

    void SelectArrow(GameObject obj){
        obj.transform.GetChild(0).gameObject.SetActive(true);
    }

    void ClearEnemySelector(){
        for(int i=0; i<enemyObj.Count; i++){
            UnselectArrow(enemyObj[i]);
        }
    }
//end party/target selection


    //hide to disable button object, !hide if just disable
    void DisableMoves(bool hide = false){
        foreach(Button btn in moveButtons){
            btn.interactable = false;
            if(hide)
                btn.gameObject.SetActive(false);
        }
    
    }

    //handles the actual moment the button gets clicked, val is assigned on the button
    public void SelectMove(int val){
        if(abilityReady){            
            selectedAbility = party[i_partySelect].myAbilities[val];
            if(selectedAbility.targetEnemy)
                SelectArrow(enemyObj[i_enemySelect]);                
        }

        if(attackReady){            
            selectedAttack = party[i_partySelect].myPhyattacks[val];
            SelectArrow(enemyObj[i_enemySelect]);
        }
        battleInfo.GetComponent<BattleInfo>().action.text = "select target";
        DisableMoves(); 
        b_selectEnemy = true;
        b_selectMove = false;        
    }



//Combat Logic
    public void ExecuteAttack(PhyAttack t){
        print(t.myName + " attack does " + t.Damage + " damage");
        t.AttackAnim( enemyObj[i_enemySelect]);
        AddText(t.Damage.ToString(), enemyObj[i_enemySelect]);
        battleInfo.GetComponent<BattleInfo>().action.text = "";
        //actually do damage to target battler
        t.Attack(enemies[i_enemySelect]);
        battleInfo.GetComponent<BattleInfo>().DisplayTargetCharacter(enemies[i_enemySelect]);
        CheckTargetHealth(enemies[i_enemySelect]);
    }

    public void ExecuteAbility(Ability _a){
        if(!_a.targetEnemy){
            print("this should heal");
        }
    }

    void CheckTargetHealth(Battler target){
        if(target.mycurrentHealth <= 0){
            print("" + target.myName + " has died");
            enemies.Remove(target);
            enemyObj[i_enemySelect].SetActive(false);
            enemyObj.Remove(enemyObj[i_enemySelect]);
            i_enemySelect = 0;
        }
    }

    void CheckVictory(){
        if(enemies.Count == 0){
            print("you win my dude");
            battleEnd = true;
            endPanel.SetActive(true);
            endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Glorious Victory";
            PopulateLoot();
        }
    }

    void PopulateLoot(){
        for(int i=0; i<loot.Length; i++){
                print(loot[i]);
                lootUI[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = loot[i].myName;
                lootUI[i].transform.GetChild(1).GetComponent<Image>().sprite = loot[i].myIcon;
        }
        //need an exit function
    }


//animation

    void AddText(string txt, GameObject obj){
        floatText.GetComponent<TextMesh>().text = "" + txt;
        Instantiate(floatText, obj.transform.position, Quaternion.identity);        
    }



//Battle UI


    

    IEnumerator playerRearm(float t=2){    
        CheckVictory();
        yield return new WaitForSeconds(t);
        if(!battleEnd){
            battleInfo.GetComponent<BattleInfo>().ClearPlayerInfo();
            battleInfo.GetComponent<BattleInfo>().ClearTargetInfo();
            battleInfo.GetComponent<BattleInfo>().action.text = "Select party member";
            b_selectParty = true;
            i_partySelect = 0;
            SelectArrow(partyObj[i_partySelect]);
        }else{

        }

        attackReady = false;
        abilityReady = false;
        itemReady = false;
        selectedAbility = null;
        selectedAttack = null;
    }

    public void PopulatePhysAttacks(){
        battleInfo.GetComponent<BattleInfo>().action.text = "Select attack";
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
        battleInfo.GetComponent<BattleInfo>().action.text = "Select ability";
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
            battleInfo.GetComponent<BattleInfo>().action.text = "select party member";       
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
                battleInfo.GetComponent<BattleInfo>().action.text = "Select action";
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
