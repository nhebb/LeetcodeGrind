namespace LeetcodeGrind.Solutions;

// 2477. Minimum Fuel Cost to Report to the Capital
public class P2477
{
    public long MinimumFuelCost(int[][] roads, int seats)
    {
        long fuel = 0;
        var adj = new Dictionary<int, List<int>>();

        // bidirectional roads == undirected graph
        foreach (var road in roads)
        {
            if (!adj.ContainsKey(road[0]))
                adj[road[0]] = new List<int>();
            adj[road[0]].Add(road[1]);

            if (!adj.ContainsKey(road[1]))
                adj[road[1]] = new List<int>();
            adj[road[1]].Add(road[0]);
        }

        long Dfs(int node, int parent)
        {
            long reps = 1; // city representatives. Current city has 1
            if (!adj.ContainsKey(node))
                return reps;

            foreach (var child in adj[node])
                if (child != parent)
                    reps += Dfs(child, node);

            if (node != 0)
                fuel += (long)Math.Ceiling(reps / (double)seats);

            return reps;
        }

        Dfs(0, -1);

        return fuel;
    }
}
