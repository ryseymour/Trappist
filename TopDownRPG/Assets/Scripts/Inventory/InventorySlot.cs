using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    [HideInInspector]public Item item;
    public TextMeshProUGUI amount;
    public TextMeshProUGUI EquipOrStore;

    public Button confirmButton;
    public GameObject confirmationWindow;
    public GameObject HeroReciever;

    public Image glow;

    public void AddItem(Item newItem)
    {
        icon.overrideSprite = newItem.myIcon;
        item = newItem;
        glow.gameObject.SetActive(true);
        //glow.color = GetQualityColor();
        glow.color= newItem.GetQualityColor();
    }

    public void RemoveItem()
    {
        icon.overrideSprite = null;
        item = null;
        glow.gameObject.SetActive(false);

    }

    public void SelectConfirmButton()
    {
        if (item == null) return;

        confirmationWindow.SetActive(true);
        confirmButton.Select();
    }

    public void SelectSameButton()
    {
        //aka cancel button
        GetComponent<Button>().Select();
    }

    public void UseItem()
    {
        if(item is Consumables)
        {
            HeroReciever.GetComponent<HeroInventoryUIReciever>().HeroSelectorInt(item);
            Debug.Log(item);
            // InventoryManager.instance.HeroUIPersonalInventory[i].GetComponent
            Debug.Log("useConsumables");
        }
        InventoryManager.instance.RemoveItem(item);
    }

    public Color GetQualityColor()
    {
        var myColor = new Color();

        switch (item.myQuality)
        {
            case Item.Quality.common:
                myColor = Color.grey;
                break;
            case Item.Quality.rare:
                myColor = Color.blue;
                break;
            case Item.Quality.epic:
                myColor = Color.magenta;
                break;
            case Item.Quality.legendary:
                myColor = Color.red;
                break;
        }

        return myColor;
    }
}
