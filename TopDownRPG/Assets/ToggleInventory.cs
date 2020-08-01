using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        Debug.Log("Inventory toggle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
