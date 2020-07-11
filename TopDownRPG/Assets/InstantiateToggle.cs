using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
