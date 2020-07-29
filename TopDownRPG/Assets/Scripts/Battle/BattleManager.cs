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

    private Move abilityChoosen;



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
        ApplyHealth();

    }

    public void ApplyHealth()
    {
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
        Debug.Log("PreBattle");
        Debug.Log("Hit Space to Start Battle");

        if (newTurn == true)
        {
            Debug.Log("restart");
            myturnState = turnSystem.battleStart;
         
        }
        //SpeedTracker();
        //ArrowTurnOff();
    }

    

    public void ArrowTurnOff()
    {
        Debug.Log("ArrowTurnOff");
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
        Debug.Log("SpeedTracker");
        if (turnChange == true)
        {
            //This code is incredible!!!! It sorts everyones speed value.
            everybodysSpeed = everybodysSpeed.OrderByDescending(e => e.Speed).ToList();
            Debug.Log(everybodysSpeed);
            for (int i = 0; i < everybodysSpeed.Count; i++)
            {
                if (participantTracker >= 1)
                {                 
                    if (everybodysSpeed[i].hasAttacked == false)
                    {   
                        if (everybodysSpeed[i].Enemy == false)
                        {
                            //everybodysSpeed[i].Speed = -10000;
                            everybodysSpeed[i].hasAttacked = true;
                            //TurnCycle();
                            Debug.Log("hero turn");
                            turnChange = false;
                            var heroMove = everybodysSpeed[i];
                            HeroTurn(heroMove);
                            break;
                        }
                        if (everybodysSpeed[i].Enemy == true)
                        {
                            everybodysSpeed[i].hasAttacked = true;
                            //Debug.Log("enemy turn");
                            turnChange = false;
                            var enemyMove = everybodysSpeed[i];
                            EnemyTurn(enemyMove);
                            //TurnCycle();
                            break;
                        }
                    }
                }
                else
                {
                    Debug.Log("potential error");
                    TurnCycle();
                }
            }
            }        
        else
        {            
            return;
        }
    }

    public void HeroTurn(Battler Hm)
    {
        firstButton.Select();
        myturnState = turnSystem.heroTurn;
        SpriteRenderer arw = Hm.myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        arw.enabled = true;
        AbilitiesUpdate(Hm);
        participantTracker = participantTracker - 1;
    }

    public void EnemyTurn(Battler Em)
    {
        myturnState = turnSystem.enemyTurn;
        SpriteRenderer arw = Em.myBattletranform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        arw.enabled = true;
        participantTracker = participantTracker - 1;
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
            //StartCoroutine(BufferTimer());
            //break;
        }
        //yield return new WaitForSeconds(1f);
        //return;
        //buffer = true;
        //
        PreBattle();
    }

  

    public void AbilitiesUpdate(Battler bt)
    {//
       
        Debug.Log("abilities" + bt);

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
            Debug.Log(tempabil[i].itemEvent);
            var eventRy = abil.itemEvent;
            Debug.Log(eventRy);

            AbilitiesButtons[i].GetComponent<UnityItemEventHandler>().unityEvent = abil.itemEvent;

            //AbilitiesButtons[i].GetComponent<UnityItemEventHandler>().unityEvent = tempabil[i].itemEvent;


            // Debug.Log(i);
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
            

            //participantTracker -= participantTracker;
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
}
