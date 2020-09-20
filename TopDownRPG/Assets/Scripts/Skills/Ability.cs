using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Move/Ability")]
public class Ability : Move
{
    public int mpCost;
    public healthBuff myHealthbuff;
    public statusEffects myStatuseffects;

    public enum healthBuff
    {
        health_zero,
        health_ten,
        health_twentyfive,
        health_fifty,
        health_100
    }

    public enum statusEffects
    {
        status_null,
        poison,
        freeze,
        burn,
        enrage
    }




    public void Pew(){
        Debug.Log("pew pew also grab the battle manager, can you do stuff there (participantTracker)? " );
        BattleManager.instance.turnChange = true;
        BattleManager.instance.targetSelect = true;     
        BattleManager.instance.abilityChoosen = this;
        BattleManager.instance.triggerTargetDelay(0.5f);
        BattleManager.instance.DisablePlayerButtons();
        // BattleManager.instance.ArrowTurnOff();
        
    }
}
