using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Solutions;

// 3010. Divide an Array Into Subarrays With Minimum Cost I
public class P3010
{
    public int MinimumCost(int[] nums)
    {
        var cost = nums[0];
        var min1 = nums[1];
        var min2 = int.MaxValue;

        for (int i = 2; i < nums.Length; i++)
        {
            if (nums[i] < min1)
            {
                min2 = min1;
                min1 = nums[i];
            }
            else if (nums[i] < min2)
            {
                min2 = nums[i];
            }
        }

        cost += min1 + min2;

        return cost;
    }
}
