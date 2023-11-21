namespace LeetcodeGrind.Solutions;

// 628. Maximum Product of Three Numbers
public class P0628
{
    public int MaximumProduct(int[] nums)
    {
        Array.Sort(nums);
        return Math.Max(nums[0] * nums[1] * nums[^1],
                        nums[^3] * nums[^2] * nums[^1]);
    }
}
