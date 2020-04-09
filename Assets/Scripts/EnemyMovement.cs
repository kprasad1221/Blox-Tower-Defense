using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path;
    [SerializeField] float wayPointDelay = 1f;



    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(FollowPath());
    }

    /*
    IEnumerator FollowPath()
    {
        
        print("Starting patrol...");
        foreach (WayPoint waypoint in path)
        {
            print("Visiting block: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(wayPointDelay);
        }
        print("Ending patrol");
    }
    */
}
