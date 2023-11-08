namespace LeetcodeGrind.Solutions;

// 64. Minimum Path Sum
public class P0064
{
    public int MinPathSum(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var dp = new int[rows][];
        for (int r = 0; r < rows; r++)
            dp[r] = new int[cols];

        dp[rows - 1][cols - 1] = grid[rows - 1][cols - 1];

        for (int r = rows - 2; r >= 0; r--)
            dp[r][cols - 1] = grid[r][cols - 1] + dp[r + 1][cols - 1];

        for (int c = cols - 2; c >= 0; c--)
            dp[rows - 1][c] = grid[rows - 1][c] + dp[rows - 1][c + 1];

        for (int r = rows - 2; r >= 0; r--)
        {
            for (int c = cols - 2; c >= 0; c--)
            {
                dp[r][c] = Math.Min(dp[r + 1][c], dp[r][c + 1]) +
                           grid[r][c];
            }
        }

        return dp[0][0];
    }
}
