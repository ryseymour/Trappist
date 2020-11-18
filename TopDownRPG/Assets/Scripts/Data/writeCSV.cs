using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;



public class writeCSV : MonoBehaviour
{

    void CreateText(){
        string path = Application.dataPath + "/Data/index.txt";

        if(!File.Exists(path)){
            Debug.Log("dont exist bro");        
            File.WriteAllText(path, "Test Line0 \n\nTest Line1");
        }

        string content = "Login date: " + System.DateTime.Now + "\n";

        File.AppendAllText(path, content);

    }

    void Start(){
        CreateText();
    }


    public void ReadFile(TextAsset textFile){
        Debug.Log(textFile.text);
    }
}
