using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem gun;
    [SerializeField] float attackRange = 30f;
    [SerializeField] int damagePerHit;

    public WayPoint baseWaypoint;

    Transform targetEnemy;

    void Update()
    {
        TargetNearestEnemy();
        if (targetEnemy)
        {
            AimAtEnemies();
            ShootEnemies();
        }
        else
        {
            Shoot(false);
        }
    }

    private void TargetNearestEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyHealthControls>();
        if(sceneEnemies.Length == 0) { return; }
        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(EnemyHealthControls testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if(distToA < distToB)
        {
            return transformA;
        }
        else
        {
            return transformB;
        }

    }

    private void AimAtEnemies()
    {
        objectToPan.LookAt(targetEnemy);
    }

    private void ShootEnemies()
    {
        float distanceFromEnemy = Vector3.Distance(transform.position, targetEnemy.position);

        if (distanceFromEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var gunFire = gun.emission;
        gunFire.enabled = isActive;
    }

    public int getDamagePerHit()
    {
        return damagePerHit;
    }
}
