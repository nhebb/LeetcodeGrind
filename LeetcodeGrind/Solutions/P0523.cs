namespace LeetcodeGrind.Solutions;

// 523. Continuous Subarray Sum
public class P0523
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        // edge cases
        if (nums.Length == 1)
            return false;

        // Create prefix sum
        var prefixes = new int[nums.Length];
        prefixes[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
            prefixes[i] = nums[i] + prefixes[i - 1];

        // If two (or more) prefix sums have the same % k value,
        // then the subrray between them is divisible by k.
        var remainderCounts = new Dictionary<int, int>();
        for (int i = 0; i < prefixes.Length; i++)
        {
            var remainder = prefixes[i] % k;

            // If remau=inder is zero then it's a straight
            // division by k
            if (remainder == 0 && i > 0)
                return true;

            // If the key already exists, then there is
            // a subarray divisible by k with a length >= 2
            if (remainderCounts.ContainsKey(remainder))
            {
                if (nums[i] != 0 && nums[i] % k != 0)
                    return true;
                if (i > 0 && nums[i] == 0 && nums[i - 1] == 0)
                    return true;
                if (i > 0 && nums[i - 1] == 0 && nums[i] % k == 0)
                    return true;

                remainderCounts[remainder]++;
            }

            remainderCounts[remainder] = 1;
        }

        return false;
    }
}
