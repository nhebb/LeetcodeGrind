namespace LeetcodeGrind.Solutions;

// 995. Minimum Number of K Consecutive Bit Flips
public class P0995
{
    // Same approach as P3191 but TLE for this problem.
    public int MinKBitFlips(int[] nums, int k)
    {
        var flips = 0;

        for (int i = 0; i <= nums.Length - k; i++)
        {
            if (nums[i] == 0)
            {
                for (int j = i; j < i + k; j++)
                {
                    nums[j] ^= 1;
                }
                flips++;
            }
        }

        for (int i = 0; i < k; i++)
        {
            if (nums[nums.Length - 1 - i] == 0)
            {
                return -1;
            }
        }

        return flips;
    }


    // Approach 3 from official Leetcode Editorial
    public int MinKBitFlips2(int[] nums, int k)
    {
        int currentFlips = 0;
        int totalFlips = 0;

        for (int i = 0; i < nums.Length; ++i)
        {
            // If the window slides out of the range and the left-most
            // element is marked as flipped (2), decrement currentFlips.
            if (i >= k && nums[i - k] == 2)
            {
                currentFlips--;
            }

            // Check if the current bit needs to be flipped.
            if (currentFlips % 2 == nums[i])
            {
                // If flipping would exceed array bounds, return -1
                if (i + k > nums.Length)
                {
                    return -1;
                }


                nums[i] = 2; // Mark current bit as flipped
                currentFlips++;
                totalFlips++;
            }
        }

        return totalFlips;
    }
}
