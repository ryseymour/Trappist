using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class textRW : MonoBehaviour
{

     

    public void CreateFile(string _p){
        
        if(!File.Exists(SetPath(_p))){
            Debug.Log("doesn't exist");
            File.WriteAllText(SetPath(_p), "Created: " + System.DateTime.Now + "\n");
        }else{
            Debug.Log("already exists");
        }

    }


    public string SetPath(string _p){        
       return Application.dataPath + "/Data/" + _p + ".txt";
    }



    // Start is called before the first frame update
    void Start()
    {
        CreateNewFile("trash");
        WriteLine("trash", "this is total trash");       
    }

    public void CreateNewFile(string _name){
        CreateFile(_name);
    }

    public void WriteLine(string fileName, string line){
        string path = SetPath(fileName);
        int count = CountLines(fileName);
        line = count-1 + ", " + line + "\n";
        File.AppendAllText(path, line);
    }


    public int CountLines(string fileName){
        string path = SetPath(fileName);
        string text = File.ReadAllText(path);
        int count = 0;
        string[] strValues = text.Split('\n');
        foreach(string str in strValues){
            count++;
        }
        Debug.Log(count);
        return count;
    }




    public string[] ParseLines(string fileName){
        string text = File.ReadAllText(SetPath(fileName));
        char[] separators = {',', ';', '|', ':'};
        string[] strValues = text.Split('\n');
        // print(strValues);
        // List<int> intValues = new List<int>();    
        return strValues;
    }



}


