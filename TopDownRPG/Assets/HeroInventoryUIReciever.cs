using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInventoryUIReciever : MonoBehaviour
{
    public static int HeroInventoryswitch;
    public GameObject[] HeroInventories;
    public Item item;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void HeroSelectorInt (Item item)
    {
        Debug.Log(HeroInventoryswitch);
        switch (HeroInventoryswitch)
        {
            
            case 4:
                HeroInventories[3].GetComponent<HeroInventoryUI>().UpdateInventoryAdd(item);
                break;

            case 3:
                HeroInventories[2].GetComponent<HeroInventoryUI>().UpdateInventoryAdd(item);
                break;

            case 2:
                HeroInventories[1].GetComponent<HeroInventoryUI>().UpdateInventoryAdd(item);
                break;

            case 1:
                HeroInventories[1].GetComponent<HeroInventoryUI>().UpdateInventoryAdd(item);
                //Heroinventory1.Add(newItem);
                // if (onItemAddCallBack != null) onItemAddCallBack.Invoke(newItem);
                break;

            case 0:
                HeroInventories[0].GetComponent<HeroInventoryUI>().UpdateInventoryAdd(item);
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
