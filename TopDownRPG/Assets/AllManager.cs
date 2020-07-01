using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllManager : MonoBehaviour
{
    public static AllManager allManager;
    public static bool initalStageBool;
    bool gameStart;

    // Start is called before the first frame update
    void Awake()
    {
       if(!gameStart)
        {
            allManager = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
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
        SceneManager.UnloadSceneAsync(scene);
    }

    public void UnloadScenes()
    {

    }
}
