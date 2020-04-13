using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthControls : MonoBehaviour
{
    [SerializeField] int enemyHitPoints = 4;
    [SerializeField] int scorePerEnemy = 12;
    [SerializeField] GameObject enemyHitFX;
    [SerializeField] GameObject explosionDeathFX;
    [SerializeField] Transform explosionDeathParent;

    //ScoreBoard scoreBoard;  TODO - create a scoreboard

    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider col = gameObject.AddComponent<BoxCollider>();
        col.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        print("collided with " + gameObject.name);
        ProcessHit(other);
    }

    private void ProcessHit(GameObject other)
    {
        int damagePerHit = other.GetComponentInParent<Tower>().getDamagePerHit();
        enemyHitPoints = enemyHitPoints - damagePerHit;
        if (enemyHitPoints <= 1)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        GameObject deathFX = Instantiate(explosionDeathFX, transform.position, Quaternion.identity);
        deathFX.SetActive(true);
        deathFX.transform.parent = explosionDeathParent;
        deathFX.name = gameObject.name + "_Explosion";
        Destroy(gameObject);
    }
}
