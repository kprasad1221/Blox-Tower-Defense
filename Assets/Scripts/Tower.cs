using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan, targetEnemy;
    [SerializeField] ParticleSystem gun;
    [SerializeField] float attackRange = 30f;
    [SerializeField] int damagePerHit;

    void Update()
    {
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
