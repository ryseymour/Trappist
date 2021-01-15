using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllManager : MonoBehaviour
{
    public static AllManager allManager;
    public static bool initalStageBool;
    bool gameStart;

    public static bool sceneUnloaded;//This is used in the battlemanager to finsih the unload process before importing characters.

    // Start is called before the first frame update
    void Awake()
    {
       if(!gameStart)
        {
            allManager = this;
            SceneManager.LoadSceneAsync(6, LoadSceneMode.Additive);
            initalStageBool = true;
            gameStart = true;

        }
    }

    

    // Update is called once per frame
    public void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload (int scene)
    {
        yield return null;
        SceneManager.UnloadSceneAsync(6);
        //sceneUnloaded = true;
    }

    
}
