using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan, targetEnemy;
    [SerializeField] GameObject gun;
    [SerializeField] float targetingDistance = 25f;

    void Update()
    {
        AimAtEnemies();
        ShootEnemies();
    }

    private void AimAtEnemies()
    {
        objectToPan.LookAt(targetEnemy);
    }

    private void ShootEnemies()
    {
        float distanceFromEnemy = CheckEnemyDistance();

        if(distanceFromEnemy <= targetingDistance)
        {
            FireGun();
        }
        else
        {
            DisableGun();
        }
    }

    private float CheckEnemyDistance()
    {
        print(Vector3.Distance(transform.position, targetEnemy.position));
        return Vector3.Distance(transform.position, targetEnemy.position);
    }

    private void FireGun()
    {
        gun.SetActive(true);
    }

    private void DisableGun()
    {
        gun.SetActive(false);
    }
}
