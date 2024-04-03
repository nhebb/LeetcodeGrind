namespace LeetcodeGrind.Solutions;

// TODO: 1289. Minimum Falling Path Sum II
public class P1289
{
    public int MinFallingPathSum(int[][] grid)
    {
        var n = grid.Length;

        if (n == 1)
        {
            return grid[0][0];
        }

        var pq = new PriorityQueue<(int val, int col), int>[n];
        for (int r = 0; r < n; r++)
        {
            pq[r] = new PriorityQueue<(int val, int col), int>(n);
            for (int c = 0; c < n; c++)
            {
                pq[r].Enqueue((grid[r][c], c), grid[r][c]);
            }

        }



        var prefix = new int[n][];
        var suffix = new int[n][];
        var dp = new int[n][];

        int GetMinOffsetVal(int r, int c1, int c2)
        {
            var val1 = c1 < 0 ? int.MaxValue : prefix[r][c1];
            var val2 = c2 >= n ? int.MaxValue : suffix[r][c2];

            return Math.Min(val1, val2);
        }

        int GetMinDPOffsetVal(int r, int c1, int c2)
        {
            var val1 = c1 < 0 ? int.MaxValue : dp[r][c1];
            var val2 = c2 >= n ? int.MaxValue : dp[r][c2];

            return Math.Min(val1, val2);
        }

        for (int r = 0; r < n; r++)
        {
            dp[r] = new int[n];
            prefix[r] = new int[n];
            suffix[r] = new int[n];

            prefix[r][0] = grid[r][0];
            suffix[r][n - 1] = grid[r][n - 1];

            for (int c1 = 1, c2 = n - 2; c1 < n && c2 >= 0; c1++, c2--)
            {
                prefix[r][c1] = Math.Min(prefix[r][c1 - 1], grid[r][c1]);
                suffix[r][c2] = Math.Min(suffix[r][c2 + 1], grid[r][c2]);
            }
        }


        for (int r = n - 2; r >= 0; r--)
        {
            for (int c = 0; c < n; c++)
            {
                dp[r][c] = grid[r][c] + GetMinOffsetVal(r + 1, c - 1, c + 1);
            }
        }

        for (int r = n - 3; r >= 0; r--)
        {
            for (int c = 0; c < n; c++)
            {
                dp[r][c] += GetMinDPOffsetVal(r + 1, c - 1, c + 1);
            }
        }
        return dp[0].Min();
    }
}
