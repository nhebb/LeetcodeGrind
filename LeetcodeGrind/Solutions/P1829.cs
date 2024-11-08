using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1829. Maximum XOR for Each Query
public class P1829
{
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
        var prefix = new int[nums.Length];
        var result = new int[nums.Length];

        prefix[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] = prefix[i - 1] ^ nums[i];
        }

        var mask = (int)(Math.Pow(2, maximumBit) - 1);

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = mask ^ prefix[^(i + 1)];
        }

        return result;
    }
}
