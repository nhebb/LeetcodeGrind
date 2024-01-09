namespace LeetcodeGrind.Solutions;

// 2475. Number of Unequal Triplets in Array
public class P2475
{
    // Brute force O(n^3). The O(n) solution relies on
    // combinatorics formulas.
    public int UnequalTriplets(int[] nums)
    {
        var count = 0;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                if (nums[i] == nums[j])
                {
                    continue;
                }

                for (int k = j + 1; k < nums.Length; k++)
                {
                    if (nums[i] == nums[k] || nums[j] == nums[k])
                    {
                        continue;
                    }

                    count++;
                }
            }
        }

        return count;
    }
}
