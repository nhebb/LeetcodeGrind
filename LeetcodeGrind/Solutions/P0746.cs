namespace LeetcodeGrind.Solutions;

// 746. Min Cost Climbing Stairs
public class P0746
{
    public int MinCostClimbingStairs(int[] cost)
    {
        if (cost.Length == 2)
            return Math.Min(cost[0], cost[1]);

        var dp = new int[cost.Length];
        dp[^1] = cost[^1];
        dp[^2] = cost[^2];

        for (int i = dp.Length - 3; i >= 0; i--)
        {
            dp[i] = Math.Min(cost[i] + dp[i + 1], cost[i] + dp[i + 2]);
        }

        return Math.Min(dp[0], dp[1]);
    }
}
