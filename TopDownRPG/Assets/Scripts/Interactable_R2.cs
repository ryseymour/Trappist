using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_R2 : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Test Speak");
    }
}
