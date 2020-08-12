using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Linq;


public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    //public List<Move> battlerMoves = new List<Move>();
    //public List<GameObject> battlers = new List<GameObject>();

    //Reference to UI
    public GameObject BattleUI;
    public Button firstButton;
   // public Button inventoryButton;

    public Button[] AbilitiesButtons;

    public turnSystem myturnState;

    public bool turnChange;
    public bool newTurn;
    public int turnRecord;

    public enum turnSystem
    {
        battleStart,
        heroTurn,
        enemyTurn,
        turnEnd,
        collectLoot,
        battleEnd
    }
    public List<Battler> battlers;
    public List<Transform> battlerTransforms = new List<Transform>();
    public List<Enemy_Battler> enemybattlers;
    public List<Transform> enemyTransforms = new List<Transform>();
    public List<Battler> everybodysSpeed = new List<Battler>();
   public int participantTracker;
    public int participantTrackerTemp;

    public Sprite Transparent;//this is to add into transforms after scene ends
    public GameObject EscapeBtn;//We need to reset the bool check in order to leave each battle

    public Move abilityChoosen;


    public int actor_counter; //keep track of how many have already gone this round

    public bool targetSelect, targetReady; //should you be listening for target selection targetReady is a delay so we don't fire the damage when we select
    public int targetSelect_int;//placeholder for the selected target

    private void Awake()
    {
        Debug.Log("awake");
        if(instance == null)
        {
            instance = this;
        }

        firstButton.Select();

        myturnState = turnSystem.battleStart;
        turnRecord = 1;
       // SetupBattle();
    }

    public void EnemyEnter()
    {

    }


    public void SetupBattle()
    {
        Debug.Log("Setup Battle");
        actor_counter = 0;
        targetSelect = false;
        targetReady = false;
        for (int i = 0; i < battlers.Count; i++)
        {
            Debug.Log("battlers added");
            var spryChange = battlerTransforms[i].GetChild(0);
            var spryChange_two = spryChange.GetComponent<SpriteRenderer>();
            spryChange_two.sprite = battlers[i].mySprite;
            //assigning the transform to the battler so they can have an arrow turn on overhead
            battlers[i].myBattletranform = battlerTransforms[i];
            battlers[i].hasAttacked = false;
            everybodysSpeed.Add(battlers[i]);            
        }

        for (int i = 0; i < enemybattlers.Count; i++)
       {            
            Debug.Log("enemy zoom");
            var spryChangeM = enemyTransforms[i].GetChild(0);
            var spryChange_twoM = spryChangeM.GetComponent<SpriteRenderer>();
            spryChange_twoM.sprite = enemybattlers[i].mySprite;
            enemybattlers[i].myBattletranform = enemyTransforms[i];
            enemybattlers[i].hasAttacked = false;
            everybodysSpeed.Add(enemybattlers[i]);
            //var speeders = everybodysSpeed[i].Speed;      
        }
        //turnChange = true;
        //keeping track of each player taking a turn 
        participantTracker = everybodysSpeed.Count;
        participantTrackerTemp = participantTracker;

        //SpeedTracker();
        //ArrowTurnOff();
       turnChange = true;
        ApplyHealth();
        
    }

    public void ApplyHealth()
    {
        Debug.Log("apply health");
        for (int i = 0; i < everybodysSpeed.Count; i++)
        {
            int myHealth = everybodysSpeed[i].myHealth;
            everybodysSpeed[i].mycurrentHealth = everybodysSpeed[i].myHealth;
            //make sure the transform is after a GetChild component canvas
            everybodysSpeed[i].myHealthBar = everybodysSpeed[i].myBattletranform.GetChild(1).transform.GetChild(0).GetComponent<HealthBar>() ;
            everybodysSpeed[i].myHealthBar.SetMaxHealth(myHealth);                      


            PreBattle();
        }
    }

    public void PreBattle()
    {
        // Debug.Log("PreBattle");

        if (newTurn == true)
        {
            Debug.Log("restart");
            myturnState = turnSystem.battleStart;         
        }
       if(participantTracker == 0){
           Debug.Log("participant tracker 0");
       }
        SpeedTracker();
        // ArrowTurnOff();
    }

    

    public void ArrowTurnOff()
    {
        // Debug.Log("ArrowTurnOff");
        for (int i = 0; i < everybodysSpeed.Count; i++)
        {       
            SpriteRenderer arw = everybodysSpeed[i].myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
            arw.enabled = false;
            //participantTracker -= participantTracker;
        }        
        SpeedTracker();
    }

   

    public void SpeedTracker()
    {

        if(actor_counter >= (battlers.Count + enemybattlers.Count)){
            actor_counter = 0;
        }    
       
        if (turnChange == true)
        {
            //This code is incredible!!!! It sorts everyones speed value.
            everybodysSpeed = everybodysSpeed.OrderByDescending(e => e.Speed).ToList();


            if(!everybodysSpeed[actor_counter].Enemy){
                Debug.Log("actor counter found the player " + actor_counter);
                 for(int i=0; i < AbilitiesButtons.Length; i++){
                    AbilitiesButtons[i].interactable = true;
                }        
                HeroTurn(everybodysSpeed[actor_counter]);
                turnChange = false;
            }else{
                Debug.Log("actor counter did not find player " + actor_counter);
                DisablePlayerButtons();
                EnemyTurn(everybodysSpeed[actor_counter]);
                turnChange = false;
            }

            // for (int i = 0; i < everybodysSpeed.Count; i++)
            // {                
            //     if (participantTracker >= 1)//cole add 8-10-20 why participant tracker? 
            //     {                             
            //         if (everybodysSpeed[i].hasAttacked == false)
            //         {   
            //             Debug.Log(everybodysSpeed[i].myName + " has not attacked");
            //             //Original code
            //             if (everybodysSpeed[i].Enemy == false)
            //             {
            //                 everybodysSpeed[i].hasAttacked = true;                     
            //                 turnChange = false;                       
            //                 HeroTurn(everybodysSpeed[i]);                             
            //             }else{
            //                 Debug.Log("Enemy turn " + everybodysSpeed[i].myName);
            //             }  
            //             // if (everybodysSpeed[i].Enemy == true)//so this happens even after the player turn, here is the problem
            //             // {
            //             //      //8-10-20 Something in here is toggling the "has attacked" but only for enemy2, who currently has highest speed
            //             //     // everybodysSpeed[i].hasAttacked = true;
            //             //     Debug.Log("Enemy turn " + everybodysSpeed[i].myName);
            //             //     // turnChange = false;
            //             //     // var enemyMove = everybodysSpeed[i];
            //             //     // EnemyTurn(everybodysSpeed[i]);
            //             //     //TurnCycle();                            
            //             // }                        
            //             //end of original                       
            //         }
            //     }
            //     else
            //     {
            //         Debug.Log("potential error");
            //         TurnCycle();
            //     }
            // }
        }        
        else
        {            
            return;
        }
    }


    public void DisablePlayerButtons(){
        Debug.Log("player buttons disabled");
        for(int i=0; i < AbilitiesButtons.Length; i++){
            AbilitiesButtons[i].interactable = false;
        }      
    }

    public void HeroTurn(Battler Hm)
    {
        Debug.Log("hero turn");
        firstButton.Select();
        myturnState = turnSystem.heroTurn;
        SpriteRenderer arw = Hm.myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        arw.enabled = true;
        actor_counter++;
        AbilitiesUpdate(Hm);
        participantTracker = participantTracker - 1;
        // ArrowTurnOff();
    }

    public void EnemyTurn(Battler Em)
    {
        Debug.Log("Enemy Turn method ran: " + Em.myName);
        myturnState = turnSystem.enemyTurn;
        SpriteRenderer arw = Em.myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        arw.enabled = true;
        participantTracker = participantTracker - 1;        
        StartCoroutine(enemyDelay(Em));
        
    }


    IEnumerator enemyDelay(Battler Em){
        yield return new WaitForSeconds(2);
        Debug.Log(Em.myName + " casts " + Em.myAbilities[0].myName);
        Em.hasAttacked = true;
        turnChange = true;
        actor_counter++;
        ArrowTurnOff();
    }

    public void AttackSelected(Move mve)
    {
        //this is coming from ability manager library which originates in the event selection of the ability bar.
        var abilitySelected = mve;
        Debug.Log("this ability" + mve);
        abilityChoosen = abilitySelected;
        ChooseTarget();
    }

    public void ChooseTarget()
    {
        //this is just a test now
        //if buff companion select
        //if attack enemy select
        ApplyDamage();        
    }

    public void ApplyDamage()
    {
        //again this needs updates
        var dmge = abilityChoosen.Damage;
        for(int i = 0; i < everybodysSpeed.Count; i++)
        {
            if (everybodysSpeed[i].Enemy == true)
            {
                everybodysSpeed[i].mycurrentHealth = everybodysSpeed[i].mycurrentHealth - dmge;
                everybodysSpeed[i].myHealthBar.SetHealth(everybodysSpeed[i].mycurrentHealth);
            }

        }
    }

    public void TurnCycle()
    {
        Debug.Log("endofTurn");
        participantTracker = participantTrackerTemp;
        turnRecord = turnRecord + 1;
        Debug.Log("the turn number is" + turnRecord);
        myturnState = turnSystem.turnEnd;
        AttackReset();
       //SetupBattle();
        //
        //SpeedTracker();
    }

    public void AttackReset()
    {
        newTurn = true;
        //This just resets the Attack bool on each battler
        for (int i = 0; i < everybodysSpeed.Count; i++)
        {
            everybodysSpeed[i].hasAttacked = false;
            Debug.Log("attack reset for " + everybodysSpeed[i].myName + " has attacked " + everybodysSpeed[i].hasAttacked);         
        }
     
        PreBattle();
    }

  

    public void AbilitiesUpdate(Battler bt)
    {//
       
     

         List<Ability> tempabil = bt.myAbilities;
        
       // temp.text = bt.myName;
       // Debug.Log(temp);
        //List<> tempabil = bt.myAbilities.Count;

        for (int i = 0; i < AbilitiesButtons.Length; i++)
        {
            var temp = AbilitiesButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            
                //= tempabil[i].itemEvent;

            Ability abil = tempabil[i];
            temp.text = abil.myName;

            var temp2 = AbilitiesButtons[i].GetComponent<UnityItemEventHandler>().unityEvent;
            temp2 = abil.itemEvent;

        //cole work 
            // AbilitiesButtons[i].GetComponent<AbilityButtonSlot>().myAbil = tempabil[i];
            // Debug.Log(AbilitiesButtons[i].GetComponent<AbilityButtonSlot>().myAbil);
        //end cole work
            
            //Event tester = abil.itemEvent;            
            var eventRy = abil.itemEvent;           

            AbilitiesButtons[i].GetComponent<UnityItemEventHandler>().unityEvent = abil.itemEvent;

        }


        
    }

    public void BattleEnd()
    {
        for (int i = 0; i < everybodysSpeed.Count; i++)
        {
            SpriteRenderer arw = everybodysSpeed[i].myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
            arw.enabled = false;

            SpriteRenderer spryte = everybodysSpeed[i].myBattletranform.GetChild(0).GetComponent<SpriteRenderer>();
            spryte.sprite = Transparent;
     
        }

        myturnState = turnSystem.battleEnd;
        Debug.Log("Battle End");
//var deliveryReset = GetComponent<battlerManager>().battlerDelivery;
        //deliveryReset = false;
       // Debug.Log("delivery reset"+ deliveryReset);
        newTurn = false;
        turnRecord = 1;
        
       // battlers.Clear();
       // enemybattlers.Clear();
        everybodysSpeed.Clear();
        participantTracker = 0;
        participantTrackerTemp = 0;
       


    }

    public void BattleReset()
    {
        //called by scene manager
        myturnState = turnSystem.battleStart;
        var reEscape = EscapeBtn.GetComponent<EscapeBattle>();
        reEscape.loaded = false;

    }


    public void triggerTargetDelay(float _t){
        StartCoroutine(TargetDelay(_t));
    }
    IEnumerator TargetDelay(float _t){
        yield return new WaitForSeconds(_t);
        targetReady = true;
    }

    void Update(){
        if(targetSelect){
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                Debug.Log("target select true and left arrow");
                enemybattlers[targetSelect_int].myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                if(targetSelect_int > 0){
                    targetSelect_int--;
                    Debug.Log("target select "  + enemybattlers[targetSelect_int].myName);
                }else{
                    targetSelect_int = enemybattlers.Count-1;
                    Debug.Log("target select "  + enemybattlers[targetSelect_int].myName);
                }
                enemybattlers[targetSelect_int].myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                // SpriteRenderer arw = everybodysSpeed[i].myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
                // arw.enabled = false;
            }

            if(Input.GetKeyDown(KeyCode.RightArrow)){
                enemybattlers[targetSelect_int].myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                if(targetSelect_int < enemybattlers.Count-1){
                    targetSelect_int++;
                     Debug.Log("target select "  + enemybattlers[targetSelect_int].myName);
                }else{
                    targetSelect_int = 0;
                     Debug.Log("target select "  + enemybattlers[targetSelect_int].myName);
                }
                enemybattlers[targetSelect_int].myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }  
            if(Input.GetKeyDown(KeyCode.Return)){            
                if(!targetReady){
                    Debug.Log("not ready yet");
                }else{
                    enemybattlers[targetSelect_int].mycurrentHealth = enemybattlers[targetSelect_int].mycurrentHealth-abilityChoosen.Damage;
                    enemybattlers[targetSelect_int].myHealthBar.SetHealth(enemybattlers[targetSelect_int].mycurrentHealth);
                    Debug.Log("should attack with " + abilityChoosen.myName);
                    // targetSelect = false;
                    //targetReady = false;
                    // ApplyHealth();                         
                }
                                       
            }          
        }
    }

}
