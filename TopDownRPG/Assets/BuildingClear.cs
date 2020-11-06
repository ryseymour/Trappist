using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClear : MonoBehaviour
{
    public GameObject InsideNPC;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuildingClearz ()
    {
        this.gameObject.SetActive(false);
        InsideNPC.SetActive(true);


    }
}
