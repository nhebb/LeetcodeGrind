using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.DynamicProgramming;

public class DynamicProgramming
{
    // 198. House Robber
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        var dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
        }

        return dp[^1];
    }


    // 213. House Robber II
    public int RobII(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        int RobDp(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }

            return dp[^1];
        }

        var arr1 = new ArraySegment<int>(nums, 0, nums.Length - 1).ToArray();
        var arr2 = new ArraySegment<int>(nums, 1, nums.Length - 1).ToArray();

        return Math.Max(RobDp(arr1), RobDp(arr2));
    }


    // 91. Decode Ways
    public int NumDecodings(string s)
    {
        if (s.StartsWith('0')) return 0;
        if (s.Length == 1) return 1;

        // check for out of bounds pairs containing 0
        for (int i = 1; i < s.Length; i++)
        {
            // check for 00 or >= 30
            if (s[i] == '0')
            {
                var val = s[i - 1] - '0';
                if (val == 0 || val >= 3)
                    return 0;
            }
        }

        var dp = new int[s.Length];
        dp[^1] = s[^1] == '0' ? 0 : 1;
        if (s[^1] == '0')
            dp[^2] = 1;
        else if ((s[^2] - '0') * 10 + s[^1] - '0' > 26)
            dp[^2] = 1;
        else
            dp[^2] = 2;

        for (int i = s.Length - 3; i >= 0; i--)
        {
            // if the next number is 0, or the current plus the next form
            // a two digit number greater than 26, then there is only one
            // decode way
            if (s[i + 1] == '0' || (s[i] - '0') * 10 + s[i + 1] - '0' > 26)
                dp[i] = 1 + dp[i + 2];
            else
                dp[i] = 2 + dp[i + 2];


            if (s[i + 1] == '0' || (s[i] - '0') * 10 + s[i + 1] - '0' > 26)
                dp[i] = 1 * dp[i + 2];
            else if (s[i + 2] == '0')
                dp[i] = 1 * dp[i + 1];
            else
                dp[i] = 2 * dp[i + 2];
        }

        return dp[0];
    }
}
