using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint StartPoint, Endpoint;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartPointEndPoint();
        ExploreThyNeighbor();
    }

    private void ExploreThyNeighbor()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int ExplorationCoordinates = StartPoint.GetGridPos() + direction;
            try
            {
                grid[ExplorationCoordinates].SetTopColor(Color.black);
            }
            catch
            {

            }
           
        }
    }

    private void ColorStartPointEndPoint()
    {
        StartPoint.SetTopColor(Color.blue);
        Endpoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var wayPoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint wayPoint in wayPoints)
        {
            var gridPos = wayPoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping Overlapping Block" + wayPoint);
            }
            else
            {
                grid.Add(gridPos, wayPoint);
            }
        }
        print("Loaded " + grid.Count + "blocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
