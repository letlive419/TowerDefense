using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour

{
    [SerializeField] GameObject towerPrefab; 

    const int gridSize = 10;

    Vector2Int gridPos;

    public bool isExplored = false;

    public WayPoint exploredFrom;

    public bool isPlaceable = true;

    [SerializeField] Vector3 spawnTower = new Vector3(0,-5,0);

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        
        {
           if (isPlaceable)
           {

                print(gameObject.name + "clicked");
                Instantiate(towerPrefab, transform.position + spawnTower, Quaternion.identity);
                isPlaceable = false;
           }
           else
            {
                print("cant place here");
            }
        }
    }

    
    public Vector2Int GetGridPos()
    {
        return new Vector2Int (
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public void SetTopColor(Color color)
    {
       MeshRenderer topRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topRenderer.material.color = color;
    }
}
