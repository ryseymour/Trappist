﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public  static class LoadBattle 
{


    private static Dictionary<string, string> parameters;
 
    public static void Load(string sceneName, Dictionary<string, string> parameters = null) {
        LoadBattle.parameters = parameters;
        SceneManager.LoadScene(sceneName);
    }
 
    public static void Load(string sceneName, string paramKey, string paramValue) {
        LoadBattle.parameters = new Dictionary<string, string>();
        LoadBattle.parameters.Add(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }
 
    public static Dictionary<string, string> getSceneParameters() {
        return parameters;
    }
 
    public static string getParam(string paramKey) {
        if (parameters == null) return "";
        return parameters[paramKey];
    }
 
    public static void setParam(string paramKey, string paramValue) {
        if (parameters == null)
            LoadBattle.parameters = new Dictionary<string, string>();
        LoadBattle.parameters.Add(paramKey, paramValue);
    }


}
