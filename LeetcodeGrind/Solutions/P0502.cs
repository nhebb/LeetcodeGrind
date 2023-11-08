namespace LeetcodeGrind.Solutions;

// 502. IPO
public class P0502
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        var pq = new PriorityQueue<int, int>();
        var q = new Queue<(int profit, int cost)>();

        // If the project capital is <= the initial w value
        // then put it in the priority queue (min heap),
        // otherwise put it in a queue.
        for (int i = 0; i < capital.Length; i++)
        {
            if (capital[i] <= w)
                pq.Enqueue(profits[i], -profits[i]);
            else
                q.Enqueue((profits[i], capital[i]));
        }

        while (k > 0)
        {
            // Edge case, there are less projects that Leetcode
            // has the capital for than the remaining k value
            if (pq.Count == 0)
                break;

            // Increment capital with the profit
            w += pq.Dequeue();
            k--;
            if (k == 0) break;

            // By using a queue, each time we remove a project
            // and place it in the priority queue, we have less
            // items in the queue to cycle over in subsequent
            // iterations.
            // 
            // Use a for loop so we don't cycle endlessly.
            var count = q.Count;
            for (int i = 0; i < count; i++)
            {
                var project = q.Dequeue();
                if (project.cost <= w)
                    pq.Enqueue(project.profit, -project.profit);
                else
                    q.Enqueue(project);
            }
        }

        return w;
    }
    // Faster version with HashSet instead of Queue
    public int FindMaximizedCapital2(int k, int w, int[] profits, int[] capital)
    {
        var pq = new PriorityQueue<int, int>();
        var hs = new HashSet<int>();
        var hsDelete = new HashSet<int>();

        // If the project capital is <= the initial w value
        // then put it in the priority queue (min heap),
        // otherwise put its index in a hashset for subsequent
        // iterations.
        for (int i = 0; i < capital.Length; i++)
        {
            if (capital[i] <= w)
                pq.Enqueue(profits[i], -profits[i]);
            else
                hs.Add(i);
        }

        while (k > 0)
        {
            // Edge case, there are less projects that Leetcode
            // has the capital for than the remaining k value
            if (pq.Count == 0)
                break;

            // Increment capital with the profit
            w += pq.Dequeue();
            k--;
            if (k == 0) break;

            // By using a hashset, each time we remove a project
            // and place it in the priority queue, we have less
            // items to cycle over in subsequent iterations.
            foreach (var i in hs)
            {
                if (capital[i] <= w)
                {
                    pq.Enqueue(profits[i], -profits[i]);
                    hsDelete.Add(i);
                }
            }
            foreach (var i in hsDelete)
                hs.Remove(i);
            hsDelete.Clear();
        }

        return w;
    }
}
