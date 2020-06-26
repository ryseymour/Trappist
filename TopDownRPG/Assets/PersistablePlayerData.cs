using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PersistablePlayerData : MonoBehaviour
{
    public string persisterName;
    public List<ScriptableObject> partyofPlayer;
    // Start is called before the first frame update
    private void OnEnable()
    {
        for (int i = 0; i < partyofPlayer.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i)))
                {
                BinaryFormatter bf = new BinaryFormatter();
                string path = Application.persistentDataPath + "/party.collection";
                FileStream stream = new FileStream(path, FileMode.Create);
                //FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i), FileMode.Open);
                //JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), partyofPlayer[i]); 
                
                stream.Close();

            }
            else
            {
                //do nothing
            }
        }
    }

    // Update is called once per frame
    private void onDisable()
    {
        for (int i = 0; i < partyofPlayer.Count; i++)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i));
                var json = JsonUtility.ToJson(partyofPlayer[i]);
            bf.Serialize(file, json);
            file.Close();
        }

    }
}
