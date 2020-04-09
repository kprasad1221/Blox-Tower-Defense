using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    const int gridSize = 10;
    Vector2Int gridPos;
    [SerializeField] Color exploredColor, unexploredColor;
    [SerializeField] bool showIfExplored = false;
    public bool isExplored = false;
    public WayPoint exploredFrom;

    private void Update()
    {
        if (showIfExplored)
        {
            if (isExplored)
            {
                SetTopColor(exploredColor);
            }
            else
            {
                SetTopColor(unexploredColor);
            }
        }
    }
    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) ,
            Mathf.RoundToInt(transform.position.z / gridSize) 
            );
    }

    public void SetTopColor(Color color)
    {
       // print(transform.Find("Top"));
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
