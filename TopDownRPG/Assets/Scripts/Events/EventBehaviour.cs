using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventBehaviour : ScriptableObject
{

    

   public void TestEvent()
    {
        Debug.Log(this.name);
        Debug.Log("Test event successful");
    }

    public void Frze()
    {
        AbilityManager.instance.AbilitySwitch(1);
    }


}
