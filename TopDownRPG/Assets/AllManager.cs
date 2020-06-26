using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllManager : MonoBehaviour
{
    public static AllManager allManager;
    bool gameStart;

    // Start is called before the first frame update
    void Awake()
    {
       if(!gameStart)
        {
            allManager = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStart = true;

        }
    }

    // Update is called once per frame
    void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload (int scene)
    {
        yield return null;
        SceneManager.UnloadScene(scene);
    }
}
