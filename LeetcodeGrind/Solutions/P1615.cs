namespace LeetcodeGrind.Solutions;

// 1615. Maximal Network Rank
public class P1615
{
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        var counts = new int[n];
        var hs = new HashSet<(int, int)>();

        for (int i = 0; i < roads.Length; i++)
        {
            counts[roads[i][0]]++;
            counts[roads[i][1]]++;
            hs.Add((roads[i][0], roads[i][1]));
        }

        var pq = new PriorityQueue<int, int>();
        for (int i = 0; i < counts.Length - 1; i++)
        {
            for (int j = i + 1; j < counts.Length; j++)
            {
                var count = counts[i] + counts[j];
                if (hs.Contains((i, j)) || hs.Contains((j, i)))
                {
                    count--;
                }
                pq.Enqueue(count, -count);
            }
        }
        return pq.Dequeue();
    }
}
