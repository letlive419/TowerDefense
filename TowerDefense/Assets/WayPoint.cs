﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    const int gridSize = 10;

    Vector2Int gridPos;

    // Start is called before the first frame update
  

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
