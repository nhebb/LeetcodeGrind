using System.ComponentModel;

namespace LeetcodeGrind.Solutions;

// 1463. Cherry Pickup II
public class P1463
{
    public int CherryPickup(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int[][][] dp = new int[m][][];

        int ans = 0;

        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n][];
            for (int j = 0; j < n; j++)
            {
                dp[i][j] = new int[n];
                Array.Fill(dp[i][j], -1);
            }
        }

        dp[0][0][n - 1] = grid[0][0] + grid[0][n - 1];

        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // Robot A
                for (int k = j + 1; k < n; k++)
                {
                    // Robot B
                    int max = -1;
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if (j + x >= 0 && j + x < n && k + y >= 0 && k + y < n)
                            {
                                max = Math.Max(max, dp[i - 1][j + x][k + y]);
                            }
                        }
                    }

                    if (max != -1)
                    {
                        dp[i][j][k] = max + grid[i][j] + grid[i][k];
                    }

                    if (ans < dp[i][j][k])
                    {
                        ans = dp[i][j][k];
                    }
                }
            }
        }

        return ans;
    }
}
