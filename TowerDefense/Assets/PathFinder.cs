using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint StartPoint, Endpoint;
    Queue<WayPoint> queue = new Queue<WayPoint>();
    [SerializeField] bool isRunning = true;

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
        
        FindPath();
    }

    private void FindPath()
    {
        queue.Enqueue(StartPoint);
        while (queue.Count > 0 && isRunning)
                {
            var searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print(searchCenter);
            HaltFindPath(searchCenter);
            ExploreThyNeighbor(searchCenter);
        } 
        
    }

    private void HaltFindPath(WayPoint searchCenter)
    {
       if (searchCenter == Endpoint)
            {
            print("end was found");
            isRunning = false;
        }
    }

    private void ExploreThyNeighbor(WayPoint from)
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int ExplorationCoordinates = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbor(ExplorationCoordinates);
            }
            catch
            {

            }
           
        }
    }

    private void QueueNewNeighbor(Vector2Int ExplorationCoordinates)
    {
        WayPoint neighbor = grid[ExplorationCoordinates];
        if (neighbor isExplored) { return;  }
        neighbor.SetTopColor(Color.black);
        queue.Enqueue(neighbor);
        print("Queing" + neighbor);
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
        
    }

   
}
