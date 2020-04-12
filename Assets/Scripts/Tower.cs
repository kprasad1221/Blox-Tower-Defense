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
        float distanceFromEnemy = CheckEnemyDistance();

        if(distanceFromEnemy <= attackRange)
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

    private float CheckEnemyDistance()
    {
        print(Vector3.Distance(transform.position, targetEnemy.position));
        return Vector3.Distance(transform.position, targetEnemy.position);
    }

    public int getDamagePerHit()
    {
        return damagePerHit;
    }
}
