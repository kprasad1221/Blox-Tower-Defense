using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthControls : MonoBehaviour
{
    [SerializeField] int enemyHitPoints = 4;
    [SerializeField] int scorePerEnemy = 12;
    [SerializeField] ParticleSystem enemyHitFX;
    [SerializeField] GameObject explosionDeathFX;
    [SerializeField] Transform explosionDeathParent;

    [SerializeField] float destroyDelay = 1.5f;

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
        ProcessHit(other);
    }

    private void ProcessHit(GameObject other)
    {
        int damagePerHit = other.GetComponentInParent<Tower>().getDamagePerHit();
        enemyHitFX.Play();
        enemyHitPoints = enemyHitPoints - damagePerHit;
        if (enemyHitPoints <= 1)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        ParticleSystem deathFX = Instantiate(explosionDeathFX.GetComponent<ParticleSystem>(), transform.position, Quaternion.identity);
        deathFX.transform.parent = transform;
        deathFX.name = gameObject.name + "_Explosion";

        
        Destroy(gameObject);
    }
}
