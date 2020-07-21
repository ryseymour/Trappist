using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroScrollButton : MonoBehaviour
{

    
    
    public int ButtonDirectionInt;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PartyChecker()
    {
        //PartyUI = PartyManager.instance.Party;//call when opening UI?
    }

    public void MenuChanger()
    {
        InventoryManager.instance.HeroButtonInt(ButtonDirectionInt);
    }


}
