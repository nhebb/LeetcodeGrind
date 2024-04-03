namespace LeetcodeGrind.P2642;

// TODO: 2642. Design Graph With Shortest Path Calculator
// This solution fails with Wrong Answer.
public class Graph
{
    private List<List<int[]>> _adjList;

    public Graph(int n, int[][] edges)
    {
        // Initialize adjacency list
        _adjList = new List<List<int[]>>(n);
        for (int i = 0; i < n; i++)
        {
            _adjList.Add(new List<int[]>());
        }

        foreach (var edge in edges)
        {
            var source = edge[0];
            var destination = edge[1];
            var cost = edge[2];
            _adjList[source].Add(new int[] { destination, cost });
        }
    }

    public void AddEdge(int[] edge)
    {
        var source = edge[0];
        var destination = edge[1];
        var cost = edge[2];
        _adjList[source].Add(new int[] { destination, cost });
    }

    public int ShortestPath(int node1, int node2)
    {
        if (node1 == node2)
            return 0;

        if (_adjList[node1].Count == 0)
            return -1;

        // Create a PriorityQueue (min heap) with the
        // tuple (destination node, edge cost) as the value
        // and the edge cost as the PQ weight.
        var pq = new PriorityQueue<(int node, int cost), int>();

        // Enqueue each of node1's neighbors
        foreach (var neighbor in _adjList[node1])
        {
            var node = neighbor[0];
            var cost = neighbor[1];
            pq.Enqueue((node, cost), cost);
        }

        // Initialize path "tracking" variables
        long minPathCost = int.MaxValue;
        long curPathCost = 0;
        var visited = new bool[_adjList.Count];

        while (pq.Count > 0)
        {
            // Get next node and track path.
            var (curNode, curCost) = pq.Dequeue();
            visited[curNode] = true;
            curPathCost += curCost;

            if (curNode == node2)
            {
                // Found. Remove "tracking" in case there are other
                // viable paths.
                minPathCost = Math.Min(curPathCost, minPathCost);
                curPathCost -= curCost;
                visited[curNode] = false;
            }
            else if (_adjList[curNode].Count > 0)
            {
                // Enqueue all the curNode neighbors.
                foreach (var neighbor in _adjList[curNode])
                {
                    var node = neighbor[0];
                    var cost = neighbor[1];
                    if (!visited[node])
                    {
                        pq.Enqueue((node, cost), cost);
                    }
                }
            }
            else
            {
                // No viable path forward. Reduce cost tracking and
                // essentially backtrack.
                curPathCost -= curCost;
            }
        }

        return minPathCost == int.MaxValue
            ? -1
            : (int)minPathCost;
    }
}