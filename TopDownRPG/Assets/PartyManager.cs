using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public static PartyManager instance;

    public List<Battler> Party;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
}
