using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class AbilityAnimation : MonoBehaviour
{

    public enum AbilityType {sword, electricBolt, fireball, heal, freeze}

    public AbilityType myAbility;
    // public AbilityType myAbility;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + offset;
   
    }

    // Update is called once per frame
    void Update()
    {
        Sword();
    }

    void Sword(){
        // transform.Translate(Vector3.left* (Time.deltaTime));
    }

    public void _Destroy(){
        Destroy(gameObject);
    }


}
