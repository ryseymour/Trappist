using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointsManager : MonoBehaviour
{
    public int horizontalmove;
    public int verticalmove;
    public GameObject playerObj;
    public float speed = 5f;
    public List<PathDestination> pathPoints;
    private Vector2 targetLocation = new Vector2(0,0);
    
    private bool Targetpass = false;

    public static MovePointsManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        //target = null;
        targetLocation = new Vector2(0, 0);

        GameManager.instance.PlayerProof.transform.position = targetLocation;

        if (instance == null)
        {
            instance = this;
        }
        var sceneStart = GameManager.instance.playerPin;
        GameManager.instance.PlayerProof.transform.localScale = new Vector3(.5f, .5f, .5f);
        GameManager.instance.PlayerProof.transform.GetChild(0).gameObject.SetActive(false);


    }

    public void PlayerTransform()
    {
        for (int i = 0; i < pathPoints.Count; i++)
        {
            if(pathPoints[i].hLocation == horizontalmove)
            {
                if(pathPoints[i].vLocation == verticalmove)
                {
                    var playerMove = pathPoints[i].PointLocation;
                    Debug.Log(playerMove);
                    //Transform arriveAt = new Vector2(rotVec.x, rotVec.y);
                    //target = playerMove;
                   // Vector3 targetLocation = playerMove - transform.position;
                    //playerObj.transform.Translate(playerMove.normalized * speed * Time.deltaTime, Space.World);
                    targetLocation = playerMove;
                    //playerMove = new Vector2(0, 0);
                    //Targetpass = true;
                        
                }
            }
        }
    }
        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = 5f;
            horizontalmove = horizontalmove + 1;
            PlayerTransform();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = 5f;
            horizontalmove = horizontalmove - 1;
            PlayerTransform();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed = 5f;
            verticalmove = verticalmove + 1;
            PlayerTransform();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed = 5f;
            verticalmove = verticalmove - 1;
            PlayerTransform();
        }
        //if (Targetpass == true)
        // {

        // Vector2 dir =(Vector2)targetLocation - (Vector2)playerObj.transform.position;
        //Vector2 dir = (Vector2)targetLocation - (Vector3)playerObj.transform.position;
        Vector2 dir = (Vector2)targetLocation - (Vector2)GameManager.instance.PlayerProof.transform.position;
        // playerObj.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        GameManager.instance.PlayerProof.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(GameManager.instance.PlayerProof.transform.position, targetLocation) <= 0.2f)
        {
            speed = 0f;
        }
       // }
    }
    }

