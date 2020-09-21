using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        lookAtEnemy();
        ShootEnemy();
            
    }

    private void ShootEnemy()
    {
       // objectToPan.transform
    }

    private void lookAtEnemy()
    {
      objectToPan.LookAt(targetEnemy);
    }
}
