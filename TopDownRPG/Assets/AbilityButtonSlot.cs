using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButtonSlot : MonoBehaviour
{
    public Button abilityButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectabilityButton()
    {
        abilityButton.Select();
    }

    public void CancelButton()
    {
        GetComponent<Button>().Select();
    }

    public void MyAbility()
    {
        Debug.Log("this is an attack");
    }

}
