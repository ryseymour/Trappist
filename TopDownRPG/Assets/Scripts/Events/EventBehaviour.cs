using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Debug.Log("frze");
        AbilityManager.instance.AbilitySwitch(1);
    }

    public void StoreScreenBuyOpen()
    {
        Debug.Log("buy open");

        InventoryManager.instance.StoreInventory();
    }

    public void StoreScreenSellOpen()
    {
        Debug.Log("sell open");
        InventoryManager.instance.StoreInventory();
    }


}
