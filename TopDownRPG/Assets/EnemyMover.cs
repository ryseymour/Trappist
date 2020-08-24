using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    public int waypointIndex = 0;
    public List<Transform> wayPointsRecieved;

    // Start is called before the first frame update
    void Start()
    {
        target = wayPointsRecieved[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector2.Distance(transform.position, target.position) <= 0.2f )
        {
            StartCoroutine (PausetoLook());
            GetNextWaypoint();
        }

    }

     IEnumerator PausetoLook ()
    {
        speed = 0f;
        yield return new WaitForSeconds(3f);
        speed = 2f;
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= wayPointsRecieved.Count-1)
        {
            target = wayPointsRecieved[0];
            waypointIndex = 0;
            return;
        }

        waypointIndex++;
        target = wayPointsRecieved[waypointIndex];
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("FIGHT");
        var goTofight = GetComponent<BadGuyFight>();
        goTofight.FightStart();
    }
}
