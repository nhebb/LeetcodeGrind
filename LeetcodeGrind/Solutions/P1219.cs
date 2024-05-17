namespace LeetcodeGrind.Solutions;

// 1219. Path with Maximum Gold
public class P1219
{
    public int GetMaximumGold(int[][] grid)
    {
        var visited = new HashSet<(int, int)>();
        var max = 0;
        var sum = 0;

        void BackTrack(int r, int c)
        {
            if (visited.Contains((r, c)) ||
                grid[r][c] == 0)
            {
                return;
            }

            visited.Add((r, c));
            sum += grid[r][c];
            max = Math.Max(max, sum);

            if (r > 0)
                BackTrack(r - 1, c);

            if (r < grid.Length - 1)
                BackTrack(r + 1, c);

            if (c > 0)
                BackTrack(r, c - 1);

            if (c < grid[0].Length - 1)
                BackTrack(r, c + 1);

            visited.Remove((r, c));
            sum -= grid[r][c];
        }

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] != 0)
                {
                    BackTrack(i, j);
                }
            }
        }

        return max;
    }
}
