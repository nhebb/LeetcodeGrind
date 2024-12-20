namespace LeetcodeGrind.Solutions;

// 2044. Count Number of Maximum Bitwise-OR Subsets
public class P2044
{
    // TODO: Wrong approach. Do backtracking.

    public int CountMaxOrSubsets(int[] nums)
    {
        var max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            max ^= nums[i];
        }

        var count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var current = nums[i];

            if (current == max)
            {
                count++;
            }

            for (int j = i + 1; j < nums.Length; j++)
            {
                current ^= nums[j];
            }
        }

        return count;
    }
}
