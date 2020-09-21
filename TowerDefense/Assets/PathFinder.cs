using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint StartPoint, Endpoint;
    Queue<WayPoint> queue = new Queue<WayPoint>();
    bool isRunning = true;
    WayPoint searchCenter;
    List<WayPoint> path = new List<WayPoint>();

    public List<WayPoint> GetPath()
    {
        if (path.Count == 0)
        {

            LoadBlocks();
            ColorStartPointEndPoint();

            FindPath();
            CreateThePath();
            return path;

        }
        else
        {
            return path;
        }
    
    }

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    // Start is called before the first frame update
    

    private void CreateThePath()
    {
        path.Add(Endpoint);

        WayPoint previous = Endpoint.exploredFrom;
        while (previous != StartPoint)
        {
            previous = previous.exploredFrom;
            path.Add(previous);
        }
        path.Add(StartPoint);
        path.Reverse();
    }

    private void FindPath()
    {
        queue.Enqueue(StartPoint);
        while (queue.Count > 0 && isRunning)
                {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print(searchCenter);
            HaltFindPath();
            ExploreThyNeighbor();
        } 
        
    }

    private void HaltFindPath()
    {
       if (searchCenter == Endpoint)
            {
            print("end was found");
            isRunning = false;
        }
    }

    private void ExploreThyNeighbor()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int ExplorationCoordinates = searchCenter.GetGridPos() + direction;
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
        if (neighbor.isExplored || queue.Contains(neighbor))
        {
        }
        else
        {
            neighbor.SetTopColor(Color.black);
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
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
        
    }

   
}
