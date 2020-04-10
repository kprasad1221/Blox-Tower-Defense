using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteExplosion : MonoBehaviour
{
    [SerializeField] float destroyDelay = 2f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
}
