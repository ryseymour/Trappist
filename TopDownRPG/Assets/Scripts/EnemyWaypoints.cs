using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    public List <GameObject> enemyPath;

    public List<Transform> points;

    public EnemyMover anEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        /*   for (int i = 0; i < enemyPath.pathPoints.Count; i++)
           {
               points.Add(enemyPath.pathPoints[i].transform);
           }
           */

        for (int i = 0; i < enemyPath.Count; i++)
        {
            points.Add(enemyPath[i].transform);
            var enemyadd = anEnemy.GetComponent<EnemyMover>().wayPointsRecieved;
            enemyadd.Add(enemyPath[i].transform);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        //liacf mlnlf

    }
}
