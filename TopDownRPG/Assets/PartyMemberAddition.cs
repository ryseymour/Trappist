using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMemberAddition : MonoBehaviour
{
    public Battler Sidekick;

    public void PartyMemberAdd()
    {
        PartyManager.instance.PartyAdder(Sidekick);
        this.gameObject.SetActive(false);

    }
}
