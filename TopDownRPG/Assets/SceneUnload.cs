using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnload : MonoBehaviour
{
    public int unloadScene;
    public int currentScene;

   public bool unloaded;

    

   // int sceneNumber = SceneManager.sceneCountInBuildSettings;
   




    //this variable skips if there was no previous scene
    private void Awake()
    {
        if(AllManager.initalStageBool == true)
        {
            this.gameObject.SetActive(false);
            AllManager.initalStageBool = false;
        }
       // sceneArray = new int[sceneNumber];
    }


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
            if (!unloaded)
            {
                unloaded = true;

            
                    AllManager.allManager.UnloadScene(unloadScene);
                
                


            }
              
                //AllManager.allManager.UnloadScene(unloadScene);
            }
                
            
        


    }

