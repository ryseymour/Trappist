using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> inventory = new List<Item>();

    public delegate void OnItemAddCallBack(Item item);
    public OnItemAddCallBack onItemAddCallBack;

    public delegate void OnItemRemoveCallBack(Item item);
    public OnItemRemoveCallBack onItemRemoveCallBack;

    //references
    public GameObject inventoryUI;
    public Button firstButton;
    public TextMeshProUGUI itemNameTooltip;
    public TextMeshProUGUI itemDescriptionTooltip;
    public ItemPopUp itemPopUp;

    public bool InitialScreenPopup;

    [HideInInspector] public bool inInventory;

    public List<Battler> PartyUI;
    public List<GameObject> HeroUIPersonalInventory;
    public List<GameObject> HeroWeaponPersonalEquipped;
    public TextMeshProUGUI heroName;
    public Image heroPortrait;

    public int HeroSelector;

    public delegate void OnItemCollectCallBack(Item itemProfile);
    public OnItemCollectCallBack onItemCollectCallBack; //have this run when you collect an item

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void AddItem(Item newItem)
    {
        inventory.Add(newItem);

        if (onItemAddCallBack != null) onItemAddCallBack.Invoke(newItem);
    }

    public void RemoveItem(Item newItem)
    {
        inventory.Remove(newItem);
        if (onItemRemoveCallBack != null) onItemRemoveCallBack.Invoke(newItem);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if(inventoryUI.activeSelf == true)
            {
               
                firstButton.Select();
                ForceSelect(firstButton);//this forces a select box
                HeroSelector = 0;
                HeroUI();
                inInventory = true;
                
            }
            else
            {
                inInventory = false;
            }
        }
    }

    public void SceneStart()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);

        StartCoroutine (InventoryPopUp ());

        



    }

    public void StoreInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        if (inventoryUI.activeSelf == true)
        {

            firstButton.Select();
            ForceSelect(firstButton);//this forces a select box
            HeroSelector = 0;
            HeroUI();
            inInventory = true;

        }
        else
        {
            inInventory = false;
        }
    }

    public IEnumerator InventoryPopUp ()
    {
        yield return new WaitForSeconds(.001f);
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    private void ForceSelect (Button btn)
    {
        Debug.Log("test button1");
        if(EventSystem.current.currentSelectedGameObject == btn.gameObject)
        {
            EventSystem.current.SetSelectedGameObject(null);
            Debug.Log("test button 2");
        }
        EventSystem.current.SetSelectedGameObject(btn.gameObject);
    }

    public void HeroButtonInt(int buttonInt)
    {
        PartyUI = PartyManager.instance.Party;

        HeroSelector = HeroSelector + buttonInt;
        if(HeroSelector< 0)
        {
            HeroSelector = PartyUI.Count-1;
        }
        if(HeroSelector>PartyUI.Count-1)
        {
            HeroSelector = 0;
        }
        HeroUI();
    }

        

    public void HeroUI()//This probably needs to be reworked
    {
        PartyUI = PartyManager.instance.Party;

        for (int i = 0; i < HeroUIPersonalInventory.Count; i++)
        {
            HeroUIPersonalInventory[i].SetActive(false);
            HeroWeaponPersonalEquipped[i].SetActive(false);
        }

        for (int i = 0; i < PartyUI.Count; i++)
        {
            if (HeroSelector == i)
            {
                HeroUIPersonalInventory[i].SetActive(true);//This turns on the container objects. HeroInvtUI populates each hero inventory.
                HeroWeaponPersonalEquipped[i].SetActive(true);
                HeroInventoryUIReciever.HeroInventoryswitch = i;
                heroName.text = PartyUI[i].myName;
                heroPortrait.sprite = PartyUI[i].mySprite;
            }
        }

    }

    public void QuestItem(Item iQ)
    {
        Debug.Log("test item");
        if (iQ.QuestItem == true)
        {
            if (onItemAddCallBack != null) onItemAddCallBack.Invoke(iQ);
            return;
        }
    }
}
