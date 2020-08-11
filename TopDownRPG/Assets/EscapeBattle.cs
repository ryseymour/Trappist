using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeBattle : MonoBehaviour
{
   public bool loaded;
    public int scene;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EscapeBattlePress ()
   {    

        

        if (!loaded)
        {
            Debug.Log("escape button" + scene);
            scene = SceneManger.instance.currentScene;
            BattleManager.instance.BattleEnd();
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            loaded = true;
        }
    }
}
