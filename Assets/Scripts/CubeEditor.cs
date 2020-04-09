using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]

public class CubeEditor : MonoBehaviour
{
    WayPoint wayPoint;

    private void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
    }

    private void Start()
    {

    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = wayPoint.GetGridSize();
        
        transform.position = new Vector3(
            wayPoint.GetGridPos().x, 
            0f, 
            wayPoint.GetGridPos().y);
    }

    private void UpdateLabel()
    {
        int gridSize = wayPoint.GetGridSize();

        string labelText = 
            wayPoint.GetGridPos().x / gridSize
            + " , " 
            + wayPoint.GetGridPos().y / gridSize;

        gameObject.name = labelText;

        TextMeshPro textMesh = GetComponentInChildren<TextMeshPro>();
        textMesh.text = labelText;
    }
}
