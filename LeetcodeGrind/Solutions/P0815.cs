namespace LeetcodeGrind.Solutions;

// TODO: 815. Bus Routes
// This solution fails with Out of Memory error.
public class P0815
{
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        var adj = new Dictionary<int, List<int>>();
        var visited = new HashSet<int>();

        // create adjacency list
        for (int i = 0; i < routes.Length; i++)
        {
            if (routes[i].Length == 0)
                continue;

            for (int j = 0; j < routes[i].Length; j++)
            {
                for (int k = 0; k < routes[i].Length; k++)
                {
                    if (j == k)
                        continue;

                    var key = routes[i][j];
                    var val = routes[i][k];
                    if (!adj.ContainsKey(key))
                        adj[key] = new List<int>();
                    adj[key].Add(val);
                }
            }
        }

        // Do a BFS search using queue. Queue item is a tuple
        // with the bus stop and bus count.
        var q = new Queue<(int, int)>();
        q.Enqueue((source, 0));

        while (q.Count > 0)
        {
            var (busStop, numBuses) = q.Dequeue();
            if (busStop == target)
            {                
                return numBuses;
            }

            if (visited.Contains(busStop))
                continue;

            visited.Add(busStop);
            foreach (var nextStop in adj[busStop])
            {
                if (!visited.Contains(nextStop))
                    q.Enqueue((nextStop, numBuses + 1));
            }
        }

        return -1;
    }
}
