using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactRange;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, GameManager.instance.player.position) < interactRange)
        {
            Debug.Log("true");
            if (Input.GetKeyDown(KeyCode.Space))
            {


                Interact();


            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Test Speak");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}

