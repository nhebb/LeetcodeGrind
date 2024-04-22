namespace LeetcodeGrind.Solutions;

// 1971. Find if Path Exists in Graph
public class P1971
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if(source == destination) 
            return true;

        var graph = new Dictionary<int, List<int>>(n);
        var containDestination = false;

        for (int i = 0; i < edges.Length; i++)
        {
            if (edges[i][0] == destination || edges[i][1] == destination)
                containDestination = true;

            if (graph.TryGetValue(edges[i][0], out List<int>? list0))
                list0.Add(edges[i][1]);
            else
                graph[edges[i][0]] = new List<int>() { edges[i][1] };

            if (graph.TryGetValue(edges[i][1], out List<int>? list1))
                list1.Add(edges[i][0]);
            else
                graph[edges[i][1]] = new List<int>() { edges[i][0] };
        }

        if(!containDestination)
            return false;

        var visited = new HashSet<int>(n);
        var queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();
            if (vertex == destination)
                return true;

            visited.Add(vertex);

            foreach (var neighbor in graph[vertex])
            {
                if (!visited.Contains(neighbor))
                    queue.Enqueue(neighbor);
            }
        }

        return false;
    }
}
