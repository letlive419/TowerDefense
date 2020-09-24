using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerFactory : MonoBehaviour
{
    [SerializeField] int maxOfTowers = 5;

    [SerializeField] GameObject towerPrefab;

    Vector3 spawnTower = new Vector3(0, -5, 0);

    public void addTower(WayPoint baseWayPoint)
    {

        var createdTowers = FindObjectsOfType<Tower>();
        int numOfTowers = createdTowers.Length;
        

        if (numOfTowers < maxOfTowers)
        {


            Instantiate(towerPrefab, baseWayPoint.transform.position + spawnTower, Quaternion.identity);

            baseWayPoint.isPlaceable = false;
            print(numOfTowers);
        }
        else
        {
            Debug.Log("number of towers maxed.");
        }
    }

}
