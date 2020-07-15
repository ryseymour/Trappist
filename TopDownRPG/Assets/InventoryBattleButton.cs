using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryBattleButton : MonoBehaviour, ISelectHandler
{
    public GameObject personalInventorypanel;
    public Button firstPersonalInventoryButton;
    public Button inventoryButtonSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SelectPersonalInventory()
    {
       // if(inventoryButtonSelect.Select == true)

        if (personalInventorypanel.activeSelf == false)
        {
            personalInventorypanel.SetActive(true);
            firstPersonalInventoryButton.Select();
        }
        else
        {
            personalInventorypanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        personalInventorypanel.SetActive(false);
    }
}
