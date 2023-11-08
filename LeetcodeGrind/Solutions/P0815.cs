namespace LeetcodeGrind.Solutions;

// 815. Bus Routes
public class P0815
{
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        var adj = new Dictionary<int, List<int>>();
        var visited = new HashSet<int>();
        var minBuses = int.MaxValue;

        // create adjacency list
        for (int i = 0; i < routes.Length; i++)
        {
            if (routes[i].Length == 0)
                continue;

            for (int j = 1; j < routes[i].Length; j++)
            {
                var key = routes[i][j - 1];
                var val = routes[i][j];
                if (!adj.ContainsKey(key))
                    adj[key] = new List<int>();
                adj[key].Add(val);
            }
            if (routes[i].Length > 1)
            {
                if (!adj.ContainsKey(routes[i][^1]))
                    adj[routes[i][^1]] = new List<int>();
                adj[routes[i][^1]].Add(routes[i][0]);
            }
        }

        void Bfs(int bus, int numBuses)
        {
            if (bus == target)
            {
                minBuses = Math.Min(minBuses, numBuses);
                return;
            }

            if (visited.Contains(bus))
                return;

            visited.Add(bus);
            foreach (var nextBus in adj[bus])
            {
                if (visited.Contains(nextBus))
                    continue;

                Bfs(nextBus, numBuses + 1);
            }
            visited.Remove(bus);
        }

        return minBuses == int.MaxValue ? -1 : minBuses;
    }
}
