using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textAnimation : MonoBehaviour
{


    public Vector3 Offset = new Vector3(0, 11, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){        
        Destroy(gameObject, 3.0f);
        Vector3 randOffset = Offset + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);

        transform.localPosition += randOffset;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator activeDelay(float t){
        yield return new WaitForSeconds(t);
        print(gameObject);
    }
}
