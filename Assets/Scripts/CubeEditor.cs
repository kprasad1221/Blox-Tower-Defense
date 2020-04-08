using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
[SelectionBase]

public class CubeEditor : MonoBehaviour
{
    [Range(5f, 20f)] [SerializeField] float snapSize = 10f;

    TextMeshPro textMesh;

    private void Start()
    {
        textMesh = GetComponentInChildren<TextMeshPro>();
        print(textMesh);
        textMesh.text = "test";
    }

    void Update()
    {
        SnapBoxToGrid();
    }

    private void SnapBoxToGrid()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / snapSize) * snapSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / snapSize) * snapSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        string labelText = snapPos.x / snapSize + " , " + snapPos.z / snapSize;
        gameObject.name = labelText;
        textMesh.text = labelText;
    }
}
