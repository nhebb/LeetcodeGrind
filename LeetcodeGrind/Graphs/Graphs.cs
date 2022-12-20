using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Graphs;

public class Graphs
{
    // 1971. Find if Path Exists in Graph
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var graph = new Dictionary<int , List<int>>();
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(source);

        while(queue.Count> 0) 
        {
            var vertex = queue.Dequeue();
            if (vertex == destination)
                return true;

            visited.Add(vertex);

            foreach (var neighbor in graph[vertex])
            {
                if(!visited.Contains(neighbor))
                    queue.Enqueue(neighbor);
            }
        }

        return false;
    }
}
