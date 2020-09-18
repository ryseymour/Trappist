using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class TownScript : MonoBehaviour
{
    public GameObject Inside;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SelectLocation()
    {
        Inside.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
