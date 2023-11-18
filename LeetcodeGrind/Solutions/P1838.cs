using System.Net.NetworkInformation;

namespace LeetcodeGrind.Solutions;

// 1838. Frequency of the Most Frequent Element
public class P1838
{
    public int MaxFrequency(int[] nums, int k)
    {
        if (nums.Length == 1)
            return 1;

        Array.Sort(nums);
        var max = 1;
        int i = 0;
        int j = 1;
        var delta = nums[1] - nums[0];

        while (j < nums.Length)
        {
            if (delta <= k)
            {
                max = Math.Max(max, j - i + 1);
                j++;
                if (j < nums.Length)
                {
                    delta += (nums[j] - nums[j - 1]) * (j - i);
                }
            }
            else
            {
                delta -= nums[j] - nums[i];
                i++;
            }
        }

        return max;
    }
}
