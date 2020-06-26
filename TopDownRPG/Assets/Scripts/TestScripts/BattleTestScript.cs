﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTestScript : MonoBehaviour
{
    public bool controlBool = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(BattleManager.instance.participantTracker == 0)
            {
                BattleManager.instance.TurnCycle();
                return;
            }

            if (BattleManager.instance.myturnState == BattleManager.turnSystem.battleStart || BattleManager.instance.myturnState == BattleManager.turnSystem.turnEnd && controlBool == true)
            {
                controlBool = false;
                Debug.Log("State1");
                BattleManager.instance.turnChange = true;
                BattleManager.instance.ArrowTurnOff();
                StartCoroutine(BufferTime());
                return;
            }
            if (BattleManager.instance.myturnState == BattleManager.turnSystem.heroTurn && controlBool == true) 
            {
                controlBool = false;
                Debug.Log("State2");
                BattleManager.instance.turnChange = true;
                BattleManager.instance.ArrowTurnOff();
                StartCoroutine(BufferTime());
                return;
            }

            if (BattleManager.instance.myturnState == BattleManager.turnSystem.enemyTurn && controlBool == true)
            {
                controlBool = false;
                Debug.Log("State3");
                BattleManager.instance.turnChange = true;
                BattleManager.instance.ArrowTurnOff();//I think the problem with the order system is that this function gets called 
                StartCoroutine(BufferTime());
                return;
            }

            if ( BattleManager.instance.myturnState == BattleManager.turnSystem.turnEnd && controlBool == true)
            {
                controlBool = false;
                Debug.Log("State4");
                BattleManager.instance.turnChange = true;
                //BattleManager.instance.PreBattle();
                StartCoroutine(BufferTime());
                return;
            }



        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            BattleManager.instance.AttackReset();
        }
    }

    IEnumerator BufferTime()
    {
        Debug.Log(controlBool);
        yield return new WaitForSeconds(.5f);
        controlBool = true;
        Debug.Log(controlBool);
    }
}
