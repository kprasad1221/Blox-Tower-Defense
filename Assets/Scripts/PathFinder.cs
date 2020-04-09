using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    [SerializeField] WayPoint startPoint, endPoint;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        SetStartEndColors();
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

    // Update is called once per frame
    void Update()
    {

    }

    private void SetStartEndColors()
    {
        startPoint.SetTopColor(Color.cyan);
        endPoint.SetTopColor(Color.red);
    }
}
