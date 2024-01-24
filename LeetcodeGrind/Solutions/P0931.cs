namespace LeetcodeGrind.Solutions;

// 931. Minimum Falling Path Sum
public class P0931
{
    public int MinFallingPathSum(int[][] matrix)
    {
        var n = matrix.Length;
        var dp = new int[n][];

        int GetMinOfThree(int r, int c1, int c2, int c3)
        {
            var val1 = c1 < 0 ? int.MaxValue : dp[r][c1];
            var val2 = dp[r][c2];
            var val3 = c3 == n ? int.MaxValue : dp[r][c3];

            return Math.Min(val1, Math.Min(val2, val3));
        }

        for (int r = 0; r < n; r++)
        {
            dp[r] = new int[n];
        }
        for (int c = 0; c < n; c++)
        {
            dp[n - 1][c] = matrix[n - 1][c];
        }

        for (int r = n - 2; r >= 0; r--)
        {
            for (int c = 0; c < n; c++)
            {
                dp[r][c] = matrix[r][c] + GetMinOfThree(r + 1, c - 1, c, c + 1);
            }
        }

        return dp[0].Min();
    }
}
