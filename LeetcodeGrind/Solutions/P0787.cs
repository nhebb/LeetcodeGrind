namespace LeetcodeGrind.Solutions;

// 787. Cheapest Flights Within K Stops
// Uses Dijkstra's algorithm
public class P0787
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        // flights[i] = [from_i, to_i, price_i]
        var adj = new Dictionary<int, List<int[]>>();
        foreach (var flight in flights)
        {
            if (!adj.ContainsKey(flight[0]))
                adj[flight[0]] = new List<int[]>();

            // key: from_i, value: int[to_i, price_i]
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        // record min # stops to arrive at each airport (node)
        var stops = new int[n];
        Array.Fill(stops, int.MaxValue);

        // 0 = total cost from src, 1 = airport, 2 = # stops from src
        var firstLeg = new int[] { 0, src, 0 };

        // custom comparer on index 0 - the price
        var pq = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[0] - b[0]));
        pq.Enqueue(firstLeg, firstLeg);

        while (pq.Count > 0)
        {
            var flight = pq.Dequeue();
            var price = flight[0];
            var airport = flight[1];
            var curStops = flight[2];

            // Current path costs more than the lowest,
            // or too many stops
            if (curStops > stops[airport] || curStops > k + 1)
                continue;

            stops[airport] = curStops;

            // the eagle has landed
            if (airport == dst)
                return price;

            // dead end
            if (!adj.ContainsKey(airport))
                continue;

            // BFS on neighboring flight legs
            foreach (var neighbor in adj[airport])
            {
                var nextLeg = new int[] { price + neighbor[1], neighbor[0], curStops + 1 };
                pq.Enqueue(nextLeg, nextLeg);
            }
        }

        return -1;
    }
}
