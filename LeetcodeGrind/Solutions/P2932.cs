namespace LeetcodeGrind.Solutions;

// 2932. Maximum Strong Pair XOR I

public class P2932
{
    public int MaximumStrongPairXor(int[] nums)
    {
        var max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (Math.Abs(nums[i] - nums[j]) <= Math.Min(nums[i], nums[j]))
                    max = Math.Max(max, nums[i] ^ nums[j]);
            }
        }

        return max;
    }
}
