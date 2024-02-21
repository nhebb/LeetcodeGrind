namespace LeetcodeGrind.Solutions;

// 2016. Maximum Difference Between Increasing Elements
public class P2016
{
    public int MaximumDifference(int[] nums)
    {
        var prefixMin = new int[nums.Length];
        var suffixMax = new int[nums.Length];

        prefixMin[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefixMin[i] = Math.Min(nums[i], prefixMin[i - 1]);
        }

        suffixMax[^1] = nums[^1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            suffixMax[i] = Math.Max(nums[i], suffixMax[i + 1]);
        }

        var max = int.MinValue;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            var diff = suffixMax[i + 1] - prefixMin[i];
            max = Math.Max(max, diff);
        }

        return max > 0 ? max : -1;
    }
}
