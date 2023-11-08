namespace LeetcodeGrind.Solutions;

// 62. Unique Paths
public class P0062
{
    public int UniquePaths(int m, int n)
    {
        var dp = new int[m, n];

        for (int i = 0; i < n; i++)
            dp[m - 1, i] = 1;

        for (int i = 0; i < m; i++)
            dp[i, n - 1] = 1;

        for (int i = m - 2; i >= 0; i--)
        {
            for (int j = n - 2; j >= 0; j--)
            {
                dp[i, j] = dp[i + 1, j] + dp[i, j + 1];
            }
        }

        return dp[0, 0];
    }
}
