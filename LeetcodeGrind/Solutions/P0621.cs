namespace LeetcodeGrind.Solutions;

// 621. Task Scheduler
public class P0621
{
    public int LeastInterval(char[] tasks, int n)
    {
        var hashMap = tasks.GroupBy(x => x)
                           .ToDictionary(g => g.Key, g => g.Count());

        var pq = new PriorityQueue<int, int>();
        foreach (var item in hashMap)
        {
            pq.Enqueue(item.Value, -item.Value);
        }

        int time = 0;
        var freq = 0;
        var queue = new Queue<(int, int)>();

        while (pq.Count > 0 || queue.Count > 0)
        {
            time++;
            if (pq.TryDequeue(out _, out freq) && ++freq != 0)
            {
                queue.Enqueue((freq, time + n));
            }
            if (queue.TryPeek(out var item) && item.Item2 == time)
            {
                freq = queue.Dequeue().Item1;
                pq.Enqueue(freq, freq);
            }
        }

        return time;
    }
}
