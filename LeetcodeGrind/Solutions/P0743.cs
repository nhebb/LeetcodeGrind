namespace LeetcodeGrind.Solutions;

// 743. Network Delay Time
public class P0743
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var paths = new Dictionary<int, List<(int dest, int time)>>();
        for (int i = 0; i < times.Length; i++)
        {
            if (paths.ContainsKey(times[i][0]))
            {
                paths[times[i][0]].Add((times[i][1], times[i][2]));
            }
            else
            {
                paths[times[i][0]] = new List<(int, int)>() { (times[i][1], times[i][2]) };
            }
        }

        var visited = new HashSet<int>();
        var pq = new PriorityQueue<(int dest, int time), int>();
        var totalTime = 0;

        pq.Enqueue((k, 0), 0);
        while (pq.Count > 0)
        {
            var item = pq.Dequeue();
            var node = item.dest;
            var d = item.time;

            if (visited.Contains(node))
            {
                continue;
            }

            totalTime = Math.Max(totalTime, d);
            visited.Add(node);

            if (paths.ContainsKey(node))
            {
                foreach (var path in paths[node])
                {
                    if (!visited.Contains(path.dest))
                    {
                        pq.Enqueue((path.dest, d + path.time), d + path.time);
                    }
                }
            }
        }

        return visited.Count < n
            ? -1
            : totalTime;
    }
}
