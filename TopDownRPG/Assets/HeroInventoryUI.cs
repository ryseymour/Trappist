using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeroInventoryUI : MonoBehaviour
{
    /* public List<Item> Heroinventory1 = new List<Item>();
     public List<Item> Heroinventory2 = new List<Item>();
     public List<Item> Heroinventory3 = new List<Item>();
     public List<Item> Heroinventory4 = new List<Item>();

     */

    public InventorySlot[] Hslots;

    public delegate void OnItemAddCallBack(Item item);
    public OnItemAddCallBack onItemAddCallBack;
   // InventoryManager.instance.onItemAddCallBack += UpdateInventoryAdd;
       // InventoryManager.instance.onItemRemoveCallBack += UpdateInventoryRemove;


   // public static int HeroInventoryswitch;

    // Start is called before the first frame update
    void Start()
    {
        Hslots = GetComponentsInChildren<InventorySlot>();

    }

    private int? GetNextEmptySlot()
    {
        for (int i = 0; i < Hslots.Length; i++)
        {
            if (Hslots[i].item == null) return i;
        }

        return null;
    }

    private int? GetSameSlot(Item newItem)
    {
        for (int i = Hslots.Length - 1; i >= 0; i--)
        {
            if (Hslots[i].item != null)
            {
                if (Hslots[i].item == newItem) return i;
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
            Hslots[(int)GetNextEmptySlot()].AddItem(newItem);//Add new stack
                                                            //optional to have one object with a 1

            if (newItem is Consumables)
            {
                Consumables consumable = newItem as Consumables;
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
