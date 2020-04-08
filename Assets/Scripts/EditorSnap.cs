using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [Range(5f, 20f)] [SerializeField] float snapSize = 10f;

    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / snapSize) * snapSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / snapSize) * snapSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
