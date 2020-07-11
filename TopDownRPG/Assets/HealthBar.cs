using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxHealth(int health)
    {
       // Debug.Log(health);
        slider.maxValue = health;
        slider.value = health;
       // Debug.Log("test health");
    }

    public void SetHealth(int health)
    {
        Debug.Log("isthisbeingcalled for health");
        slider.value = health;
    }

    
   
   
}
