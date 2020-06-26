using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPopUp : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI itemDesc;
    public TextMeshProUGUI itemName;
    public Animator myAnim;
    public bool InPopUP { get; set; }

    private bool buffer;

    public void PopUpItem(Item newItem)
    {
        StartCoroutine(Buffer());

        myAnim.SetBool("FadeIn", true);

        itemName.text = newItem.myName;
        itemName.color = newItem.GetQualityColor();
        itemDesc.text = newItem.myDescription;
        itemIcon.sprite = newItem.myIcon;
        InventoryManager.instance.AddItem(newItem);
        InPopUP = true;
    }
    private void Update()
    {
        if (buffer == false) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (itemIcon.gameObject.activeSelf == true)
                {
                    myAnim.SetBool("FadeIn", false);
                    InPopUP = false;
                }
            }
        }
    }

    private IEnumerator Buffer()
    {
        buffer = true;
        yield return new WaitForSeconds(0.1f);
        buffer = false;
    }
}
