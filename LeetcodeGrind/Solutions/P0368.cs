using System.Collections;

namespace LeetcodeGrind.Solutions;

// 368. Largest Divisible Subset
public class P0368
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        Array.Sort(nums);
        var result = new List<int>();
        var current = new List<int>();

        for (int i = 0; i < nums.Length - 1; i++)
        {
            current.Add(nums[i]);
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] % current[^1] == 0)
                {
                    current.Add(nums[j]);
                }
            }

            if (current.Count > result.Count)
            {
                result.Clear();
                result.AddRange(current);
            }
        }

        return result;
    }

    public IList<int> LargestDivisibleSubset2(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums;
        }

        Array.Sort(nums);

        var dp = new int[nums.Length];
        var prev = new int[nums.Length];

        var index = 0;
        var max = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            prev[i] = -1;

            for (int j = i - 1; j >= 0; j--)
            {
                if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;

                    if (dp[i] > max)
                    {
                        max = dp[i];
                        index = i;
                    }
                }
            }
        }

        var result = new List<int>();
        while (index != -1)
        {
            result.Add(nums[index]);
            index = prev[index];
        }

        return result;
    }
}
