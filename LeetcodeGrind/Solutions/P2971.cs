namespace LeetcodeGrind.Solutions;

// 2971. Find Polygon With the Largest Perimeter
public class P2971
{
    public long LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);

        var prefix = new long[nums.Length];
        prefix[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] = prefix[i - 1] + nums[i];
        }

        if (prefix[^2] > nums[^1])
            return prefix[^1];

        for (int i = prefix.Length - 1; i > 1; i--)
        {
            if (nums[i] < prefix[i - 1])
                return prefix[i];
        }

        return -1;
    }
}
