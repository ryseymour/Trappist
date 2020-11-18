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

    public void ClearFile(string _name){
        string path = SetPath(_name);

        if(File.Exists(path)){
            File.WriteAllText(path, string.Empty);
        }else{
            Debug.Log("no file found");
        }
    }
    public string SetPath(string _p){        
       return Application.dataPath + "/Data/" + _p + ".txt";
    }

    // Start is called before the first frame update
    void Start()
    {
          
    }

    public void CreateNewFile(string _name){
        CreateFile(_name);
    }

    public void WriteLine(string fileName, string line){
        string path = SetPath(fileName);
        int count = CountLines(fileName);
        line = line + "\n";
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
        return count;
    }



    //break the file into separate lines: Rows
    public string[] SeparateLines(string fileName){
        string text = File.ReadAllText(SetPath(fileName));
        string[] strValues = text.Split('\n');
        // print(strValues);
        // List<int> intValues = new List<int>();    
        return strValues;
    }

    //break the lines up by a commafeed a row get an array of cells
    public string[] ParseLine(string line){
        char[] separators = {','};        
        string[] strValues = line.Split(separators);
        return strValues;
    }

   public Vector3 CellToVector(string cell){
       Vector3 v3 = new Vector3(0,0,0);
        float[] values = {0,0};
        int count = 0;
       foreach(char c in cell){
           if(System.Char.IsDigit(c)){
               values[count] = (float)System.Char.GetNumericValue(c);
               count++;
           }
       }
        v3 = new Vector3(values[0], values[1], 0);
        return v3;
   }




}


