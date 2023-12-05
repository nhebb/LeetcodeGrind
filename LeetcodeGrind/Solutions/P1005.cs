using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1005. Maximize Sum Of Array After K Negations
public class P1005
{
    public int LargestSumAfterKNegations(int[] nums, int k)
    {
        Array.Sort(nums);
        var count = k;

        // Negate the largest negate numbers
        for (int i = 0; i < nums.Length && i < count; i++)
        {
            if (nums[i] < 0)
            {
                nums[i] = -nums[i];
                k--;
            }
            else
            {
                break;
            }
        }

        var result = nums.Sum();

        // If k is zero, there's no more to do.
        // If k is a positive even, we can skip this since
        // we are allowed to negate an index twice.
        if (k > 0 && k % 2 == 1)
        {
            var min = nums.Min();
            result -= 2 * min;
        }

        return result;
    }
}

