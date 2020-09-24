using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] ParticleSystem bulletsHit;
    [SerializeField] ParticleSystem death;

    // Start is called before the first frame update
    void Start()
    {

        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(Movement(path));
    }

    IEnumerator Movement(List<WayPoint> path)
    {
        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;


            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);

    }
    private void OnParticleCollision(GameObject other)
    {

        
        hitPoints--;
        bulletsHit.Play();

        if (hitPoints == 0)
        {
            var deathfx = Instantiate(death, transform.position, Quaternion.identity);
            deathfx.Play();
            float deathPS = deathfx.main.duration;
            Destroy(deathfx.gameObject, deathPS);
            Destroy(gameObject);
        }
    }

        
}