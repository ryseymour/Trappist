using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfighterManger : MonoBehaviour
{
    public static enemyfighterManger instance;
    public List<Enemy_Battler> en_battlers;
    public bool en_battlersDelivery;

    public BattleManager bttlemng;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        bttlemng = GetComponent<BattleManager>();
    }

    public void LateUpdate()
    {
        if (bttlemng.myturnState == BattleManager.turnSystem.battleStart) 
        {
            if (en_battlersDelivery == false)
            {
                bttlemng.enemybattlers = en_battlers;
                //BattleManager.instance.SetupBattle();
                //bttlemng.EnemyEnter();
                en_battlersDelivery = true;
            }
            else
            {
                return;
            }
        }
    }

}
