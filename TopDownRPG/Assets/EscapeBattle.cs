using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeBattle : MonoBehaviour
{
   public bool loaded;
    public int scene = 1;

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
            BattleManager.instance.BattleEnd();
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            loaded = true;
        }
    }
}
