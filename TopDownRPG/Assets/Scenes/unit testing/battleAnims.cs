using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleAnims : MonoBehaviour
{

    public Battler myBattler;
    public List <Battler> party = new List<Battler>();
    public List <GameObject> partyObj = new List<GameObject>();

    public List <Battler> enemies = new List<Battler>();
    public List <GameObject> enemyObj = new List<GameObject>();
    // Start is called before the first frame update

    public GameObject floatText;

    public int partySelect, enemySelect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1)){
          
            string dmg = "" + party[partySelect].myAbilities[0].Damage.ToString();            

            AddText(dmg);
            // print(party[partySelect].myAbilities[0].myName);

            // partyObj[partySelect].transform.GetChild(0).gameObject.SetActive(true);
            // partyObj[partySelect].transform.GetChild(0).GetComponent<TextMesh>().text = party[partySelect].myAbilities[0].myName;
        }
    }


    void AddText(string txt){
        floatText.GetComponent<TextMesh>().text = "" + txt;
        Instantiate(floatText, partyObj[partySelect].transform.position, Quaternion.identity);
        
    }
}
