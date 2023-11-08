namespace LeetcodeGrind.Solutions;

// 1129. Shortest Path with Alternating Colors
public class P1129
{
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        var redNodes = new List<int>[n];
        var blueNodes = new List<int>[n];

        for (var i = 0; i < n; i++)
        {
            redNodes[i] = new List<int>();
            blueNodes[i] = new List<int>();
        }

        foreach (var edge in redEdges)
            redNodes[edge[0]].Add(edge[1]);

        foreach (var edge in blueEdges)
            blueNodes[edge[0]].Add(edge[1]);

        var result = new int[n];
        new Span<int>(result).Fill(-1);

        var queue = new Queue<(int node, bool isBlue)>();
        queue.Enqueue((0, true));
        queue.Enqueue((0, false));

        var visited = new HashSet<(int node, bool isBlue)>();
        visited.Add((0, true));
        visited.Add((0, false));

        var level = 0;
        while (queue.Count > 0)
        {
            var count = queue.Count;
            for (var i = 0; i < count; i++)
            {
                var (node, isBlue) = queue.Dequeue();
                if (result[node] == -1)
                    result[node] = level;

                // if current node is blue, add unvisited red edges,
                // or if current node is red, add unvisited blue edges
                if (isBlue)
                {
                    foreach (var next in redNodes[node])
                        if (!visited.Contains((next, false)))
                        {
                            queue.Enqueue((next, false));
                            visited.Add((next, false));
                        }
                }
                else
                {
                    foreach (var next in blueNodes[node])
                        if (!visited.Contains((next, true)))
                        {
                            queue.Enqueue((next, true));
                            visited.Add((next, true));
                        }
                }
            }

            level++;
        }

        return result;
    }
}
