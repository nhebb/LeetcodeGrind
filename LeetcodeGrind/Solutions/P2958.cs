using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2958. Length of Longest Subarray With at Most K Frequency
public class P2958
{
    public int MaxSubarrayLength(int[] nums, int k)
    {
        var d = new Dictionary<int, int>();
        var i = 0;
        var max = 0;

        for (int j = 0; j < nums.Length; j++)
        {
            if (d.TryGetValue(nums[j], out int value))
            {
                d[nums[j]] = ++value;
            }
            else
            {
                d[nums[j]] = 1;
            }

            while (d[nums[j]] > k)
            {

                d[nums[i]]--;
                i++;
            }
            max = Math.Max(max, j - i + 1);
        }

        return max;
    }
}
