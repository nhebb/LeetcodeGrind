using LeetcodeGrind.Common;
using System.Numerics;
using System.Xml.Linq;

namespace LeetcodeGrind.Solutions;

// 2962. Count Subarrays Where Max Element Appears at Least K Times
public class P2962
{
    long CountSubarrays(int[] nums, int k)
    {
        var maxVal = nums.Max();
        var maxValCount = 0;

        var i = 0;
        var j = 0;
        long result = 0;

        while (j < nums.Length)
        {
            if (nums[j] == maxVal)
            {
                maxValCount++;
            }

            while (maxValCount >= k)
            {
                result += nums.Length - j;
                if (nums[i] == maxVal)
                {
                    maxValCount--;
                }
                i++;
            }
            j++;
        }

        return result;
    }
}