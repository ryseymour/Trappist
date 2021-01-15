using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public static SceneManger instance;
    public static bool worldScene;//determine which manager scripts are active
    public GameObject Battlefield;
    public GameObject BattlefieldUI;
    public GameObject PlayerGO;
    public GameObject Camera;
    public GameObject InventoryUI;

   // public GameObject TownCanvas;

    public GameObject overworldTobattle;
    public GameObject townTobattle;

    public int previousScene;
    public int currentScene;

    public delegate void OnEnemyDeathCallBack(EnemyProfile enemyProfile);
    public OnEnemyDeathCallBack onEnemyDeathCallBack; //have this run when the enemy dies


    public bool scenceChecker;

    public Town interactedTown;
    public Town overworldTown;
    public bool gettingTooverworld;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        
        
    }

    public void WorldScene()
    {
        BattleManager.instance.BattleReset();
        this.gameObject.GetComponent<battlerManager>().enabled = false;
        this.gameObject.GetComponent<enemyfighterManger>().enabled = false;

         InventoryManager.instance.SceneStart();
        //InventoryUI.GetComponent<ToggleInventory>().enabled = true;
        


       // this.gameObject.GetComponent<BattleManager>().enabled = false;
        this.gameObject.GetComponent<DialogueManager_R>().enabled = true;
        Camera.gameObject.GetComponent<CameraController>().enabled = true;
        PlayerGO.SetActive(true);
    Battlefield.SetActive(false);
        BattlefieldUI.SetActive(false);
        Debug.Log("WorldScene test ");
      //  TownCanvas.SetActive(true);

        //
    }

    public void OverworldScene()
    {
        BattleManager.instance.BattleReset();
        this.gameObject.GetComponent<battlerManager>().enabled = false;
        this.gameObject.GetComponent<enemyfighterManger>().enabled = false;

        InventoryManager.instance.SceneStart();
        //InventoryUI.GetComponent<ToggleInventory>().enabled = true;



        // this.gameObject.GetComponent<BattleManager>().enabled = false;
        this.gameObject.GetComponent<DialogueManager_R>().enabled = true;
        Camera.gameObject.GetComponent<CameraController>().enabled = true;
        PlayerGO.SetActive(true);
        Battlefield.SetActive(false);
        BattlefieldUI.SetActive(false);

    }

    public void BattleScene()
    {
       // TownCanvas.SetActive(false);
        this.gameObject.GetComponent<BattleManager>().enabled = true;
        
        this.gameObject.GetComponent<DialogueManager_R>().enabled = false;
        this.gameObject.GetComponent<enemyfighterManger>().enabled = true;
        this.gameObject.GetComponent<battlerManager>().enabled = true;
        
        Camera.gameObject.GetComponent<CameraController>().enabled = false;
        //this.gameObject.GetComponent<BattleManager>().enabled = true;
        PlayerGO.SetActive(false);
        Battlefield.SetActive(true);
        BattlefieldUI.SetActive(true);
        Camera.transform.position = new Vector3(0, 0, -10f);

        
        //InventoryUI.GetComponent<InstantiateToggle>().enabled = true;


    }

    public void LoadUpTown()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }

    public void LoadUpOver(int Int)
    {
        Debug.Log("Leaving Overworld SceneManger");
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadSceneAsync(Int, LoadSceneMode.Additive);
        return;
    }

    public void LoadUpOverworld()
    {
        if(gettingTooverworld == true)
        {
            SceneManager.LoadSceneAsync(6, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(1, UnloadSceneOptions.None);
            Debug.Log("left town");
            gettingTooverworld = false;
            return;
        }
        else
        {
            return;
        }

    }


    // Update is called once per frame
    void Update()
    {
        
        if (scenceChecker == false)
        {
            if (worldScene == false)
            {
                scenceChecker = true;
                BattleScene(); 
            }

            if(worldScene == true)
            {
                scenceChecker = true;
                WorldScene();
            }
        }
    }
}
