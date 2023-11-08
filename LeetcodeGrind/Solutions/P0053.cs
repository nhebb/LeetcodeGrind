namespace LeetcodeGrind.Solutions;

// 53. Maximum Subarray
public class P0053
{
    public int MaxSubArray(int[] nums)
    {
        var maxSum = nums[0];
        var currentMaxSum = maxSum;

        for (int i = 1; i < nums.Length; i++)
        {
            currentMaxSum = Math.Max(currentMaxSum + nums[i], nums[i]);
            maxSum = Math.Max(maxSum, currentMaxSum);
        }
        return maxSum;
    }
}
