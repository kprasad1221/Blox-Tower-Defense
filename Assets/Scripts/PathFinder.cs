using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint startPoint, endPoint;
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    List<WayPoint> path = new List<WayPoint>();
    bool isRunning = true;
    WayPoint searchCenter;
    Vector2Int[] directions = {

        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.right,
        Vector2Int.left
    };

    public List<WayPoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }    
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        SetStartEndColors();
        BreadthFirstSearch();
        FormPath();
    }

    private void LoadBlocks()
    {
        WayPoint[] wayPoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint wayPoint in wayPoints)
        {
            Vector2Int gridPos = wayPoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping block: " + wayPoint);
            }
            else
            {
                grid.Add(gridPos, wayPoint);
            }     
        }
        //print(grid.Count);
    }

    private void SetStartEndColors()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if(searchCenter == endPoint)
        {
            print("Searching from end node, therefore stopping");
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;

            if(grid.ContainsKey(explorationCoordinates))
            {
                QueueNewNeighbor(explorationCoordinates);
            }
        }
    }

    private void QueueNewNeighbor(Vector2Int explorationCoordinates)
    {
        WayPoint neighbor = grid[explorationCoordinates];
        if (neighbor.isExplored || queue.Contains(neighbor))
        {
            //do nothing
        }
        else
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
    }

    private void FormPath()
    {
        SetAsPath(endPoint);
        WayPoint previous = endPoint.exploredFrom;
        while (previous != startPoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }
        SetAsPath(startPoint);
        path.Reverse();
    }

    private void SetAsPath(WayPoint wayPoint)
    {
        path.Add(wayPoint);
        wayPoint.isPlaceable = false;
    }
}
