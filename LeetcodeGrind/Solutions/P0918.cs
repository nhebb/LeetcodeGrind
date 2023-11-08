namespace LeetcodeGrind.Solutions;

// 918. Maximum Sum Circular Subarray
public class P0918
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        // Kadane's algorithm
        int CalcMaxSum()
        {
            int curMax = nums[0];
            int maxSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                curMax = Math.Max(nums[i], curMax + nums[i]);
                maxSum = Math.Max(maxSum, curMax);
            }
            return maxSum;
        }

        // calculate max sum on normal array
        int maxSum = CalcMaxSum();

        // calculate the totals and flip the signs
        int totalSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            totalSum += nums[i];
            nums[i] = -nums[i];
        }

        // Recalculate the sum with the signs flipped
        // and add to the total sum to get the max
        // circular sum
        int circularSum = totalSum + CalcMaxSum();

        if (circularSum == 0)
            return maxSum;
        return Math.Max(circularSum, maxSum);
    }
}
