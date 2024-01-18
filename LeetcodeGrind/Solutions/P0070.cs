namespace LeetcodeGrind.Solutions;

// 70. Climbing Stairs
public class P0070
{
    public int ClimbStairs(int n)
    {
        if (n == 1)
        {
            return 1;
        }

        var dp = new int[n];
        dp[0] = 1;
        dp[1] = 2;
        for (int i = 2; i < n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[^1];
    }
}
