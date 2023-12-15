namespace LeetcodeGrind.Solutions;

// 2760. Longest Even Odd Subarray With Threshold
public class P2760
{
    public int LongestAlternatingSubarray(int[] nums, int threshold)
    {
        var max = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0 && nums[i] <= threshold)
            {
                var len = 1;

                for (int j = i + 1; j < nums.Length; j++)
                {

                    if (nums[j] > threshold || 
                        nums[j] % 2 == nums[j - 1] % 2)
                        break;

                    len++;
                }

                max = Math.Max(max, len);
            }
        }

        return max;
    }
}
