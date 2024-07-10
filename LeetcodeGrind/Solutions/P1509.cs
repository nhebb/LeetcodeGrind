namespace LeetcodeGrind.Solutions;

// 1509. Minimum Difference Between Largest and Smallest Value in Three Moves
public class P1509
{
    public int MinDifference(int[] nums)
    {
        if (nums.Length <= 4)
        {
            return 0;
        }

        Array.Sort(nums);

        // With just 3 moves, there are 4 options:
        // change left 3 			=> nums[^1] - nums[3]
        // change right 3 			=> nums[^4] - nums[0]
        // change left 2 + right 1	=> nums[^2] - nums[2]
        // change right 2 + left 1	=> nums[^3] - nums[1]
        var minDiff = Math.Min(nums[^1] - nums[3], nums[^4] - nums[0]);
        minDiff = Math.Min(nums[^2] - nums[2], minDiff);
        minDiff = Math.Min(nums[^3] - nums[1], minDiff);

        return minDiff;
    }
}
