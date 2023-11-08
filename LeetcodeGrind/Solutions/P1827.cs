namespace LeetcodeGrind.Solutions;

// 1827. Minimum Operations to Make the Array Increasing
public class P1827
{
    public int MinOperations(int[] nums)
    {
        var count = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                var delta = nums[i - 1] - nums[i] + 1;
                nums[i] += delta;
                count += delta;
            }
        }
        return count;
    }
}
