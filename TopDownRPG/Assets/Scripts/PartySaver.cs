using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PartySaver : MonoBehaviour
{
    [SerializeField] private PlayerParty myParty;

    private void OnEnable()
    {
        myParty.myParty.Clear();
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }

    public void ResetScriptables()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath +
            string.Format("/{0}.par", i)))
        {
            File.Delete(Application.persistentDataPath +
                string.Format("/{0}.par", i));
            i++;
        }

    }

    public void SaveScriptables()
    {
        ResetScriptables();
        for (int i = 0; i < myParty.myParty.Count; i++)
        {
            BinaryFormatter binary = new BinaryFormatter();
            string path = Application.persistentDataPath + "/{0}.par";
           // FileStream stream = new FileStream(path, FileMode.Create);

            //myParty.myParty part = new myParty(myParty.myParty)

            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.par", i));
            
            var json = JsonUtility.ToJson(myParty.myParty[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath +
            string.Format("/{0}.par", i)))
        {
          var temp = ScriptableObject.CreateInstance<Battler>();
            FileStream file = File.Open(Application.persistentDataPath +
                string.Format("/{0}.par", i), FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), myParty.myParty[i] );
            file.Close();
            myParty.myParty.Add(temp);
            i++;
        }

    }
}
