using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Greedy;

public class Greedy
{
    // 53. Maximum Subarray
    public int MaxSubArray(int[] nums)
    {
        var maxSum = nums[0];
        var currentMaxSum = maxSum;

        for (int i = 1; i < nums.Length; i++)
        {
            currentMaxSum = Math.Max(currentMaxSum + nums[i], nums[i]);
            maxSum = Math.Max(maxSum, currentMaxSum);
        }
        return maxSum;
    }


    // 55. Jump Game
    public bool CanJump(int[] nums)
    {
        var target = nums.Length - 1;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (i + nums[i] >= target)
                target = i;
        }
        return target == 0;
    }


    // 45. Jump Game II
    public int Jump(int[] nums)
    {
        if (nums.Length == 1) return 0;

        var jumps = 0;
        var maxJumps = nums.Max();
        var target = nums.Length - 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            var minIndex =  Math.Max(0, i - maxJumps);
            var nextTarget = target;
            for (int j = i; j >= minIndex; j--)
            {
                if (nums[j] + j >= target)
                {
                    i = j;
                    nextTarget = j;
                }
            }
            target = nextTarget;
            jumps++;
        }
        return jumps;
    }
}
