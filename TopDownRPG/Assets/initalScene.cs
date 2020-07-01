using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initalScene : MonoBehaviour
{
    public bool initialScene;
    public GameObject Unloader;

    public bool GateCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GateCheck == false)
        {
            if (initialScene == true)
            {
                initialScene = false;
                GateCheck = true;
               // SceneUnload.Get.SetActive(true);
            }
        }

    }
}
