namespace LeetcodeGrind.Solutions;

// 300. Longest Increasing Subsequence
public class P0300
{
    public int LengthOfLIS(int[] nums)
    {
        // Bottom up solution - iterates backwards through the array
        // and sets the dp[i] value by checking every index of nums[]
        // to the right of i. If the current nums[i] value is less than
        // the checked nums[j] value, then the current LIS is set to
        // 1 + dp[j] if it's longer the existing LIS.
        var dp = new int[nums.Length];
        dp[^1] = 1;
        var maxLIS = 1;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            var curLIS = 1;
            for (int j = i + 1; j < dp.Length; j++)
            {
                if (nums[i] < nums[j])
                    curLIS = Math.Max(curLIS, 1 + dp[j]);
            }
            dp[i] = curLIS;
            maxLIS = Math.Max(maxLIS, curLIS);
        }

        return maxLIS;
    }
}
