using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PathPoint", menuName = "PathPoint")]


public class PathDestination : ScriptableObject
{
    public Vector2 PointLocation;

    public int hLocation;
    public int vLocation;

    public Transform pointTransform;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
