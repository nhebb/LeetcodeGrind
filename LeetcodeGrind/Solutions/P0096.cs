namespace LeetcodeGrind.Solutions;

// 96. Unique Binary Search Trees
public class P0096
{
    public int NumTrees(int n)
    {
        var dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                dp[i] += dp[j - 1] * dp[i - j];
            }
        }
        return dp[n];
    }
}
