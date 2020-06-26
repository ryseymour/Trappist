using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Consumables", menuName = "Items/Consumables")]
public class Consumables : Item
{
    public UnityEvent itemEvent;
}
