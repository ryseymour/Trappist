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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pew(){
        Debug.Log("pew pew");
    }
}
