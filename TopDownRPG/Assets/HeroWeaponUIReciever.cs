using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWeaponUIReciever : MonoBehaviour
{
    public GameObject[] HeroEquippedWeapons;
    public Item item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HeroSelectorInt (Item item)
    {

        switch(HeroInventoryUIReciever.HeroInventoryswitch)
        {
            case 4:
                HeroEquippedWeapons[3].GetComponent<HeroWeaponUI>().UpdateInventoryAdd(item);
                break;

            case 3:
                HeroEquippedWeapons[2].GetComponent<HeroWeaponUI>().UpdateInventoryAdd(item);
                break;

            case 2:
                HeroEquippedWeapons[1].GetComponent<HeroWeaponUI>().UpdateInventoryAdd(item);
                break;

            case 1:
                HeroEquippedWeapons[1].GetComponent<HeroWeaponUI>().UpdateInventoryAdd(item);
                //Heroinventory1.Add(newItem);
                // if (onItemAddCallBack != null) onItemAddCallBack.Invoke(newItem);
                break;

            case 0:
                HeroEquippedWeapons[0].GetComponent<HeroWeaponUI>().UpdateInventoryAdd(item);
                Debug.Log("case 0");
                //Heroinventory1.Add(newItem);
                // if (onItemAddCallBack != null) onItemAddCallBack.Invoke(newItem);
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
