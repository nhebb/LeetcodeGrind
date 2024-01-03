using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2873. Maximum Value of an Ordered Triplet I
public class P2873
{
    public long MaximumTripletValue(int[] nums)
    {
        long max = int.MinValue;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    long val = (nums[i] - nums[j]) * (long)nums[k];
                    max = Math.Max(max, val);
                }
            }
        }

        return max > 0
            ? max
            : 0;
    }
}

