using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Party", menuName = "Player Party")]
[System.Serializable]
public class PlayerParty : ScriptableObject
{
    public List<Battler> myParty = new List<Battler>();
}
