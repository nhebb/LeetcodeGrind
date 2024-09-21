using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2419. Longest Subarray With Maximum Bitwise AND
public class P2419
{
    public int LongestSubarray(int[] nums)
    {
        var max = nums[0];
        var maxLen = 1;
        var currentLen = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
                maxLen = 1;
                currentLen = 1;
            }
            else if (nums[i] == max)
            {
                if (nums[i] == nums[i - 1])
                {
                    currentLen++;
                    maxLen = Math.Max(currentLen, maxLen);
                }
                else
                {
                    currentLen = 1;
                }
            }
        }

        return maxLen;
    }
}
