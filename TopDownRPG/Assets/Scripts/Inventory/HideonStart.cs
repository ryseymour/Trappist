using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideonStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InventoryManager.instance.inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
