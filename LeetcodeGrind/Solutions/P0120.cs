namespace LeetcodeGrind.Solutions;

// 120. Triangle
public class P0120
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        var dp = new int[triangle.Count][];
        dp[dp.Length - 1] = new int[dp.Length];
        for (int c = 0; c < dp.Length; c++)
            dp[dp.Length - 1][c] = triangle[dp.Length - 1][c];

        for (int r = dp.Length - 2; r >= 0; r--)
        {
            dp[r] = new int[r + 1];
            for (int c = 0; c < r + 1; c++)
            {
                var val = triangle[r][c];
                dp[r][c] = Math.Min(val + dp[r + 1][c], val + dp[r + 1][c + 1]);
            }
        }

        return dp[0][0];
    }
}
