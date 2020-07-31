using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeroWeaponUI : MonoBehaviour
{
    public InventorySlot[] Wslots;

    

    // Start is called before the first frame update
    void Start()
    {
        Wslots = GetComponentsInChildren<InventorySlot>();
    }

    private int? GetNextEmptySlot()
    {
        for (int i = 0; i < Wslots.Length; i++)
        {
            if (Wslots[i].item == null) return i;
        }

        return null;
    }

    private int? GetSameSlot(Item newItem)
    {
        for (int i = Wslots.Length - 1; i >= 0; i--)
        {
            if (Wslots[i].item != null)
            {
                if (Wslots[i].item == newItem) return i;
            }
        }
        return null;
    }

    public void UpdateInventoryAdd(Item newItem)
    {
        Debug.Log(newItem);

        var remainder = GetRemainder(newItem);

        if (remainder == 0)
        {
            remainder = newItem.maxStackSize;//recalibrate
        }

        if (remainder >= 1)
        {
            Wslots[(int)GetNextEmptySlot()].AddItem(newItem);//Add new stack
                                                             //optional to have one object with a 1
            
            if (newItem is Weapons)
            {
                Weapons weapons = newItem as Weapons;
                // Hslots[(int)GetSameSlot(newItem)].GetComponent<UnityItemEventHandler>().unityEvent = consumable.itemEvent;
                // Hslots[(int)GetSameSlot(newItem)].EquipOrStore.text = "Store";
            }

        }
        else
        {
            // Hslots[(int)GetSameSlot(newItem)].amount.text = remainder.ToString();//update stack amount
        }
    }

    private int GetRemainder(Item newItem)
    {
        var itemCount = InventoryManager.instance.inventory.Count(x => x == newItem);
        return itemCount % newItem.maxStackSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
