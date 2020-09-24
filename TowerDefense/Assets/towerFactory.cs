using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerFactory : MonoBehaviour
{
    [SerializeField] int maxOfTowers = 5;

    [SerializeField] Tower towerPrefab;

    Vector3 spawnTower = new Vector3(0, -5, 0);

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void addTower(WayPoint baseWayPoint)
    {

        int numOfTowers = towerQueue.Count;

        if (numOfTowers < maxOfTowers)
        {


            var addedTower = Instantiate(towerPrefab, baseWayPoint.transform.position + spawnTower, Quaternion.identity);

            baseWayPoint.isPlaceable = false;
            towerQueue.Enqueue(addedTower);
            
        }
        else
        {
            Debug.Log("number of towers maxed.");

            var oldTower = towerQueue.Dequeue();



            towerQueue.Enqueue(oldTower);
        }
    }

}
