namespace LeetcodeGrind.Solutions;

// 719. Find K-th Smallest Pair Distance
public class P0719
{
    public int SmallestDistancePair(int[] nums, int k)
    {
        // Binary search on solution range
        Array.Sort(nums);

        var left = 0;
        var right = nums[^1] - nums[0];

        for (int cnt = 0; left < right; cnt = 0)
        {
            var mid = left + (right - left) / 2;

            for (int i = 0, j = 0; i < nums.Length; i++)
            {
                while (j < nums.Length && nums[j] <= nums[i] + mid)
                {
                    j++;
                }
                cnt += j - i - 1;
            }

            if (cnt < k)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}
