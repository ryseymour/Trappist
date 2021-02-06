using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PieceType { enemy, party, arrow};
public class BattlePiece : MonoBehaviour
{


    public PieceType myPiece;
    public Vector3 arrow_From;
    public Vector3 arrow_Dest;
    public Vector3 v_Rotation;
    public float ping_pong_speed;
    public bool activeSelect; //do you bounce or lock the selection arrow
    public GameObject Gaffer;


    // Start is called before the first frame update
    void Start()
    {
        if(myPiece == PieceType.arrow){
            // from = Quaternion.identity;
            // dest = Vector3(0,360,0);
            arrow_From = transform.position;
            arrow_Dest = arrow_Dest+transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(myPiece == PieceType.arrow){
            transform.Rotate(v_Rotation *5* Time.deltaTime);
            if(activeSelect){
                PingPong();
            }else{
                
            }            
        }
    }

    
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            if(myPiece == PieceType.party){
                print("party piece " + this);
                //Gaffer.transform.GetComponent<battleAnims>().ClickPiece(gameObject);
                Gaffer.transform.GetComponent<battleAnims>().SelectPartyPiece(gameObject);
            }

            if(myPiece == PieceType.enemy){
               print("click enemy piece " + this);
               GameObject tempGaffer = GameObject.Find("Gaffer");               
               tempGaffer.transform.GetComponent<battleAnims>().SelectEnemyPiece(gameObject);
              
            }
        }
    }

   


    void PingPong(){
        float t = Mathf.PingPong(Time.time, ping_pong_speed);
        transform.position = Vector3.Lerp(arrow_From, arrow_Dest, t);     
    }
}
