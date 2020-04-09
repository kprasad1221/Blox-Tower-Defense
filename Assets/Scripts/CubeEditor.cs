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
            wayPoint.GetGridPos().x * gridSize, 
            0f, 
            wayPoint.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        string labelText = 
            wayPoint.GetGridPos().x 
            + " , " 
            + wayPoint.GetGridPos().y;

        gameObject.name = labelText;

        TextMeshPro textMesh = GetComponentInChildren<TextMeshPro>();
        textMesh.text = labelText;
    }
}
