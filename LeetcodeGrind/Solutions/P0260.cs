using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 260. Single Number III
public class P0260
{
    // Approach 1: HashSet - O(n) time, O(n) space
    public int[] SingleNumber(int[] nums)
    {
        var hs = new HashSet<int>();
        foreach (var num in nums)
        {
            if (!hs.Add(num))
            {
                // If Add() failed, it's a duplicate
                hs.Remove(num);
            }
        }

        return hs.ToArray();
    }

    // Approach 2: Bitmask - O(n) time, O(1) space
    public int[] SingleNumber2(int[] nums)
    {
        // Credit: https://leetcode.com/u/zhiqing_xiao/
        // https://leetcode.com/problems/single-number-iii/solutions/68900/accepted-c-java-o-n-time-o-1-space-easy-solution-with-detail-explanations/

        var xor = 0;
        foreach (var num in nums)
        {
            // Duplicate numbers with cancel each other out,
            // leaving just the XOR of the two single numbers.
            xor ^= num;
        }

        // This bit trick finds a set bit for just one of the
        // two single numbers.
        var mask = xor & -xor;

        var result = new int[2];
        foreach (var num in nums)
        {
            // This splits nums into two groups - one with the
            // mask bit set and the other without it set. Again,
            // the duplicated numbers will cancel each other out,
            // leaving just a single number at each array index.
            if ((num & mask) == 0)
                result[0] ^= num;
            else
                result[1] ^= num;
        }

        return result;
    }
}
