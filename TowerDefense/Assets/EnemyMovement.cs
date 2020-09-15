using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List <WayPoint> path;
    // Start is called before the first frame update
    void Start()
    {
        foreach (WayPoint wayPoint in path)
            print(wayPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
