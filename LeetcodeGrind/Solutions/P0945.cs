using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 945. Minimum Increment to Make Array Unique
public class P0945
{
    public int MinIncrementForUnique(int[] nums)
    {
        Array.Sort(nums);
        var moves = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                var delta = Math.Abs(nums[i] - nums[i - 1]) + 1;
                moves += delta;
                nums[i] += delta;
            }
        }

        return moves;
    }
}
