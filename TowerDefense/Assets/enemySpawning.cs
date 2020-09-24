using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawning : MonoBehaviour
{
    [SerializeField] float secBetweenSpawns = 5f;
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform cloneParent;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Spawning(Enemy));
    }

    IEnumerator Spawning(GameObject Enemy)
    {
        while (true)
        {

            

            var newEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = cloneParent;

            yield return new WaitForSeconds(secBetweenSpawns);
        }

        // Update is called once per frame
    }
}
        
   