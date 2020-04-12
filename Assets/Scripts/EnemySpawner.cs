﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        yield return new WaitForSeconds(secondsBetweenSpawns);
        var spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemyPrefab = spawnedEnemy;
        StartCoroutine(spawnEnemies());
    }
}
