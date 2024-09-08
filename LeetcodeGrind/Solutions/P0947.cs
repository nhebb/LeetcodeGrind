namespace LeetcodeGrind.Solutions;

// 947. Most Stones Removed with Same Row or Column
public class P0947
{
    public int RemoveStones(int[][] stones)
    {
        // Slow solution. Union-Find is probably faster

        var visited = new HashSet<int>(stones.Length);
        var count = 0;

        void DFS(int idx)
        {
            visited.Add(idx);

            for (int i = 0; i < stones.Length; i++)
            {
                if (visited.Contains(i))
                    continue;

                if (stones[i][0] == stones[idx][0] || 
                    stones[i][1] == stones[idx][1])
                        DFS(i);
            }
        }

        for (int i = 0; i < stones.Length; i++)
        {
            if (!visited.Contains(i))
            {
                DFS(i);
                count++;
            }
        }

        return stones.Length - count;
    }
}
