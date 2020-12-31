using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Collect Quest", menuName = "Quests/Collect Quest")]
public class QuestCollect : QuestBase
{
    [System.Serializable]
    public class Objectives
    {
        public Item requiredItem;
        public int requiredAmount;
    }

    public Objectives[] objectives;

    public override void InitializeQuest()
    {
        RequiredAmount = new int[objectives.Length];

        for (int i = 0; i < objectives.Length; i++)
        {
            RequiredAmount[i] = objectives[i].requiredAmount;
        }

        InventoryManager.instance.onItemAddCallBack += itemAdd;
        //BattleManager.instance.onEnemyDeathCallBack += EnemyDeath;
        //SceneManger.instance.onEnemyDeathCallBack += EnemyDeath;

        base.InitializeQuest();
    }

    private void itemAdd(Item item)
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            if(item == objectives[i].requiredItem)
            {
                CurrentAmount[i]++;
            }

        }

        Evaluate();
    }
}
