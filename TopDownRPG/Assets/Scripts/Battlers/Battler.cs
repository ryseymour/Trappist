using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battler", menuName = "Battler")]
public class Battler : ScriptableObject
{
    public string myName;
    public string myClass;
    public Sprite mySprite;
    public int Speed;
    public int myHealth;
    public int mycurrentHealth;
    public HealthBar myHealthBar;
    public bool Enemy;
    public bool hasAttacked;
    public Transform myBattletranform;

    public List<PhyAttack> myPhyattacks;

    public List<Ability> myAbilities;

    public List<Consumables> consumables;

    
}
