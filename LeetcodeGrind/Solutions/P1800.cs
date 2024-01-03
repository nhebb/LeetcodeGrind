namespace LeetcodeGrind.Solutions;

// 1800. Maximum Ascending Subarray Sum
public class P1800
{
    public int MaxAscendingSum(int[] nums)
    {
        var sum = nums[0];
        var max = sum;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                sum += nums[i];
            }
            else
            {
                sum = nums[i];
            }
            max = Math.Max(max, sum);
        }

        return max;
    }
}
