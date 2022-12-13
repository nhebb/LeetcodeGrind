﻿using System;
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
        if (s[0] == '0') return 0;
        if (s.Length == 1) return 1;

        var dp = new int[s.Length];

        dp[0] = 1;
        var num = (s[0] - '0') * 10 + s[1] - '0';
        if (num >= 10 && num <= 26)
            dp[1] = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == '0')
                dp[i - 1] = 0;
            else
                dp[i] += dp[i - 1];

            if (i + 1 < s.Length)
            {
                num = (s[i] - '0') * 10 + s[i + 1] - '0';
                if (num >= 10 && num <= 26)
                    dp[i + 1] += dp[i - 1];
            }
        }

        return dp[^1];
    }

}