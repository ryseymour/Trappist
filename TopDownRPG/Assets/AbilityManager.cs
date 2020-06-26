using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

    public static AbilityManager instance;
    public int abilitySelected;
    public List<Move> abilityLibrary = new List<Move>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    // Update is called once per frame
    public void AbilitySwitch(int abilitySelected)
    {
        switch (abilitySelected)
        {
                //case 2:



                case 1:
                BattleManager.instance.AttackSelected(abilityLibrary[1]);
                Debug.Log("Freeze");
                break;

                default:
                Debug.Log("Incorrect");
                break;
        }
    }
}
