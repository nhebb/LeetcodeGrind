namespace LeetcodeGrind.Solutions;

// 3105. Longest Strictly Increasing or Strictly Decreasing Subarray
public class P3105
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        var decreasing = 1;
        var increasing = 1;
        var maxDecreasing = 1;
        var maxIncreasing = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                decreasing++;
                maxDecreasing = Math.Max(maxDecreasing, decreasing);
            }
            else
            {
                decreasing = 1;
            }

            if (nums[i] > nums[i - 1])
            {
                increasing++;
                maxIncreasing = Math.Max(maxIncreasing, increasing);
            }
            else
            {
                increasing = 1;
            }
        }

        return Math.Max(maxDecreasing, maxIncreasing);
    }
}
