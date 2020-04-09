using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint startPoint, endPoint;
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    [SerializeField] bool isRunning = true;
    Vector2Int[] directions = {

        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.right,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        SetStartEndColors();
        //ExploreNeighbors();
        FindPath();
    }

    private void LoadBlocks()
    {
        var wayPoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint wayPoint in wayPoints)
        {
            var gridPos = wayPoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping block: " + wayPoint);
            }
            else
            {
                grid.Add(gridPos, wayPoint);
            }     
        }
        print(grid.Count);
    }

    private void SetStartEndColors()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

    /*
    private void ExploreNeighbors()
    {
        foreach( Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startPoint.GetGridPos() + direction;
            print(explorationCoordinates);
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.cyan);
            }
            catch
            {
                Debug.LogWarning("did not find entry" + explorationCoordinates);
            }           
        }
    }*/

    private void FindPath()
    {
        queue.Enqueue(startPoint);

        while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from " + searchCenter);
            EndPath(searchCenter);
        }
    }

    private void EndPath(WayPoint searchCenter)
    {
        if(searchCenter == endPoint)
        {
            print("Searching from end node, therefore stopping");
            isRunning = false;
        }
    }
}
