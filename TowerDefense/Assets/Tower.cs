﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] float attackRange = 10f;
    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            lookAtEnemy();
            ShootEnemy();
        }
        else
        {
            Shoot(false);
        }
            
    }

    private void ShootEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
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
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
        
    }

    private void lookAtEnemy()
    {
      objectToPan.LookAt(targetEnemy);
    }
}
