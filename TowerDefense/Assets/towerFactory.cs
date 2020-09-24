using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerFactory : MonoBehaviour
{
    [SerializeField] int maxOfTowers = 5;

    [SerializeField] Tower towerPrefab;

    [SerializeField] Transform towerParent;

    Vector3 spawnTower = new Vector3(0, -5, 0);

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void addTower(WayPoint baseWayPoint)
    {

        int numOfTowers = towerQueue.Count;

        if (numOfTowers < maxOfTowers)
        {
            InstantiateNewTower(baseWayPoint);
        }
        else
        {
            MoveOldTower(baseWayPoint);
        }
    }

    private void MoveOldTower(WayPoint newBaseWayPoint)
    {
        Debug.Log("number of towers maxed.");

        var oldTower = towerQueue.Dequeue();
        oldTower.baseWayPoint.isPlaceable = true;
        newBaseWayPoint.isPlaceable = false;

        oldTower.baseWayPoint = newBaseWayPoint;
        oldTower.transform.position = newBaseWayPoint.transform.position;
        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(WayPoint baseWayPoint)
    {
        var newTower = Instantiate(towerPrefab, baseWayPoint.transform.position + spawnTower, Quaternion.identity);
        newTower.transform.parent = towerParent;

        newTower.baseWayPoint = baseWayPoint;
        baseWayPoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);
    }
}
