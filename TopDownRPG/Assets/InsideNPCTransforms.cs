using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideNPCTransforms : MonoBehaviour
{
    public Transform[] insideNPCTransforms;
    public GameObject town;

    // Start is called before the first frame update
    void Start()
    {
        InsideManager.instance.npcTransforms = new Transform[insideNPCTransforms.Length];

        for (int i = 0; i < InsideManager.instance.npcTransforms.Length; i++)
        {
            InsideManager.instance.npcTransforms[i] = insideNPCTransforms[i];
        }
    }

    public void ClearthePeople()
    {
        gameObject.SetActive(false);
        town.SetActive(true);

        foreach(Transform child in transform)
        {
            var eraseRun = child.GetComponentInChildren<PersonClear>();
            eraseRun.DestroyPerson();
            
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
