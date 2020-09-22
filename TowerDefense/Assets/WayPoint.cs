using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    const int gridSize = 10;

    Vector2Int gridPos;

    public bool isExplored = false;

    public WayPoint exploredFrom;

    public bool isPlaceable = true;

    void OnMouseOver()
    {
        var mouseClicked = Input.GetMouseButtonDown(0);
        if (mouseClicked == true)
        {
            print(gameObject.name + "clicked");
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
