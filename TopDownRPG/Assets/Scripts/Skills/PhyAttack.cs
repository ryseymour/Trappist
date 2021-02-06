using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PhyAttack", menuName = "Move/PhyAttack")]
public class PhyAttack : Move
{
    public int staminaCost;


    public void AttackAnim(GameObject target){    
        //Debug.Log(Damage + " damage done to " + target);
        Instantiate(animationSprite, target.transform.position, Quaternion.identity);
    }

    public void Attack(Battler target){
        target.mycurrentHealth -= Damage;
    }
}
