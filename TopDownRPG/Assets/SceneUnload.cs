using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnload : MonoBehaviour
{
    public int unloadScene;
    //public int unloadSceneTwo;
    public int currentScene;

   public bool unloaded;
    


    // int sceneNumber = SceneManager.sceneCountInBuildSettings;





    //this variable skips if there was no previous scene
    private void Awake()
    {
        GameManager.instance.DialogueTriggerV();
        unloadScene = SceneManger.instance.previousScene;

        if (AllManager.initalStageBool == true)
        {
            this.gameObject.SetActive(false);
            AllManager.initalStageBool = false;
            SceneManger.instance.scenceChecker = false;
        }
        // sceneArray = new int[sceneNumber];
        if (currentScene == 1)//will need to make this more dynamic
        {
            SceneManger.instance.scenceChecker = false;
            SceneManger.worldScene = true;
            SceneManger.instance.previousScene = 1;
            SceneManger.instance.currentScene = 1;




        }
        else if(currentScene == 3){
            SceneManger.instance.scenceChecker = false;
            SceneManger.worldScene = true;
            SceneManger.instance.previousScene = 3;
            SceneManger.instance.currentScene = 3;
        }
        else
        {
            SceneManger.instance.scenceChecker = false;
            SceneManger.worldScene = false;
            SceneManger.instance.previousScene = 2;
        }
        //AllManager.sceneUnloaded = true;

    }


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
            if (!unloaded)
            {
                unloaded = true;
            //unloadScene = SceneManger.instance.previousScene;


                    AllManager.allManager.UnloadScene(unloadScene);
                
                


            }
              
                //AllManager.allManager.UnloadScene(unloadScene);
            }
                
            
        


    }

