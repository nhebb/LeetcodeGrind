namespace LeetcodeGrind.Solutions;

// 1043. Partition Array for Maximum Sum
public class P1043
{
    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        var n = arr.Length;
        var dp = new int[n];

        for (int i = 0; i < n; ++i)
        {
            int curMax = 0;
            for (int j = 1; j <= k && i - j + 1 >= 0; j++)
            {
                curMax = Math.Max(curMax, arr[i - j + 1]);
                dp[i] = Math.Max(dp[i], (i >= j ? dp[i - j] : 0) + curMax * j);
            }
        }

        return dp[^1];
    }
}
