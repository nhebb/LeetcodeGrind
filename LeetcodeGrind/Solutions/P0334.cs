namespace LeetcodeGrind.Solutions;

// 334. Increasing Triplet Subsequence
public class P0334
{
    public bool IncreasingTriplet(int[] nums)
    {

        var mins = new int[nums.Length];
        var maxs = new int[nums.Length];

        // Create prefix array of minimum values to the left
        mins[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            mins[i] = Math.Min(nums[i], mins[i - 1]);
        }

        // Create suffix array of maximum values to the right
        maxs[^1] = nums[^1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            maxs[i] = Math.Max(nums[i], maxs[i + 1]);
        }

        // check if current value is between mins and maxs
        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (mins[i - 1] < nums[i] && nums[i] < maxs[i + 1])
                return true;
        }

        return false;
    }
}
