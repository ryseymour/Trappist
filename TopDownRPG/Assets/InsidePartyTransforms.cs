using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsidePartyTransforms : MonoBehaviour
{

    public Transform[] insidePartyTransforms;
    // Start is called before the first frame update
    void Awake()
    {
        // InsideManager.instance.partyTransforms = new Transform[insidePartyTransforms.Length];

        // for (int i = 0; i < InsideManager.instance.partyTransforms.Length; i++)
        // {
        //     // InsideManager.instance.partyTransforms[i] = insidePartyTransforms[i];
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
