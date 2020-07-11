using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadGuyFight : MonoBehaviour
{

    public int scene;
    bool loaded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FightStart()
    {
        {
            if (!loaded)
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);


                loaded = true;
            }
        }


    }
}
