namespace LeetcodeGrind.Solutions;

// 63. Unique Paths II
public class P0063
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var lastRow = obstacleGrid.Length - 1;
        var lastCol = obstacleGrid[0].Length - 1;

        if (obstacleGrid[lastRow][lastCol] == 1 ||
            obstacleGrid[0][0] == 1)
            return 0;

        // NB: a 1 in the dp matrix represents a path count -
        // not an obstacle
        var dp = new int[lastRow + 1, lastCol + 1];
        dp[lastRow, lastCol] = 1;

        // set each cell in last column to 1 if there are no
        // obstacles defined below it
        for (int r = lastRow - 1; r >= 0; r--)
        {
            if (dp[r + 1, lastCol] == 1 && obstacleGrid[r][lastCol] == 0)
                dp[r, lastCol] = 1;
        }

        // set each cell in last row to 1 if there are no
        // obstacles defined to the right of it
        for (int c = lastCol - 1; c >= 0; c--)
        {
            if (dp[lastRow, c + 1] == 1 && obstacleGrid[lastRow][c] == 0)
                dp[lastRow, c] = 1;
        }

        for (int r = lastRow - 1; r >= 0; r--)
        {
            for (int c = lastCol - 1; c >= 0; c--)
            {
                if (obstacleGrid[r][c] == 1)
                {
                    // if there's an obstacle, the cell has no path
                    dp[r, c] = 0;
                }
                else
                {
                    // otherwise it's the sum of the path to
                    // the right plus the path down
                    dp[r, c] = dp[r + 1, c] + dp[r, c + 1];
                }
            }
        }

        return dp[0, 0];
    }
}
