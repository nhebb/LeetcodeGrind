namespace LeetcodeGrind.Solutions;

// 2492. Minimum Score of a Path Between Two Cities
public class P2492
{
    // TODO: Finish this.
    public int MinScore(int n, int[][] roads)
    {
        // create bidirectional adjacency list
        var adj = new Dictionary<int, List<(int, int)>>();
        foreach (var road in roads)
        {
            if (!adj.ContainsKey(road[0]))
                adj[road[0]] = new List<(int, int)>();
            adj[road[0]].Add((road[1], road[2]));

            if (!adj.ContainsKey(road[1]))
                adj[road[1]] = new List<(int, int)>();
            adj[road[1]].Add((road[0], road[2]));
        }

        // Create a disjoint set array to eliminate unneeded paths
        var parent = new int[n + 1];
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = i;
        }

        int Find(int x)
        {
            while (x != parent[x])
                x = parent[x];
            return x;
        }

        void Union(int x, int y)
        {
            var min = Find(x);
            var max = Find(y);
            if (min > max)
                (min, max) = (max, min);
            parent[max] = min;
        }

        bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }

        var minpath = int.MaxValue;
        var q = new Queue<(int city, int dist)>();
        foreach (var edge in adj[1])
        {
            q.Enqueue(edge);
        }

        while (q.Count > 0)
        {
            var count = q.Count;

        }

        return 0;
    }
}
