using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEventTrigger : Interactable
{
    public DTrigger DT;

    public override void Interact()
    {
        DT.index = 1;
        base.Interact();
    }
}
