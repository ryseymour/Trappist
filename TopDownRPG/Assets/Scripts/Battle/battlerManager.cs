﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlerManager : MonoBehaviour
{
    public static battlerManager instance;

    public BattleManager Btman;

    public List<Battler> battlers;

    public bool battlerDelivery;

    
   

    private void Awake()
    {
         if (instance == null)
         {
           instance = this;
          }
       
        ActiveBattler();
    }

    public void ActiveBattler ()
    {
        //code to determine next battler
        Battler tempbat = battlers[0];
        //BattleM_UI_Update(tempbat);
    }


    public void BattleM_UI_Update(Battler tempbat)
    {
        //update this!!!
        
        //Ability tempabil = tempbat.myAbilities[];
       // Debug.Log(tempabil);

       Btman.AbilitiesUpdate(tempbat);
        //
        //BattleManager.instance.AbilitiesUpdate();
        //BattleManager.instance.AbilitiesUpdate(tempbat.myAbilities[0]);
    }

    public void LateUpdate()
    {
        if (BattleManager.instance.myturnState == BattleManager.turnSystem.battleStart) 
        {
            if (battlerDelivery == false)
            {
                BattleManager.instance.battlers = battlers;
                //if there is a character uploading problem it will probably be with this line. 
                //BattleManager.instance.SetupBattle();
                battlerDelivery = true;
            }
            else{
                return;
            }
        }
    }

}
