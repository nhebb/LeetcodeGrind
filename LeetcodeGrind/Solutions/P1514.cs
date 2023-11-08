namespace LeetcodeGrind.Solutions;

// 1514. Path with Maximum Probability
public class P1514
{
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
    {
        // Create adjacency dictionary from src node to dest node,
        // with probability as edge weight
        var adj = new Dictionary<int, List<(int vertex, double probability)>>();
        for (int i = 0; i < edges.Length; i++)
        {
            if (!adj.ContainsKey(edges[i][0]))
                adj[edges[i][0]] = new List<(int vertex, double probability)>();
            adj[edges[i][0]].Add((edges[i][1], succProb[i]));

            if (!adj.ContainsKey(edges[i][1]))
                adj[edges[i][1]] = new List<(int vertex, double probability)>();
            adj[edges[i][1]].Add((edges[i][0], succProb[i]));
        }

        // Edge case where you are given a start or end node not in the adjacency list
        if (!adj.ContainsKey(start) || !adj.ContainsKey(end))
            return 0.0;

        // Max heap of the next available vetices, prioritized by the
        // edge probability (negated).
        var pq = new PriorityQueue<(int vertex, double probability), double>();
        pq.Enqueue((start, -1.0), -1.0);

        // Keep track of visited vertices
        var visited = new HashSet<int>();
        visited.Add(start);

        // Djikstra's algo
        while (pq.Count > 0)
        {
            var edge = pq.Dequeue();
            var src = edge.vertex;
            var curProbability = edge.probability;
            visited.Add(src);

            if (src == end)
                return -curProbability;

            foreach (var dest in adj[src])
            {
                if (!visited.Contains(dest.vertex))
                {
                    var nextProbability = curProbability * dest.probability;
                    pq.Enqueue((dest.vertex, nextProbability), nextProbability);
                }
            }

        }

        return 0.0;
    }
}
