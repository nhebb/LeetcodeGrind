namespace LeetcodeGrind.Solutions;

// 1685. Sum of Absolute Differences in a Sorted Array
public class P1685
{
    public int[] GetSumAbsoluteDifferences(int[] nums)
    {
        int prefix = 0;
        int suffix = nums.Sum();
        var result = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            // Remove current from right side sum before calculating result
            suffix -= nums[i];

            // The math is a bit tricky at first glance. First, the
            // absolute value isn't needed because the numbers to
            // the left are <= current number, and the numbers to
            // the right are >=, which means we can just do the
            // subtractions: current - left and right - current.
            // Second, the sum of the deltas is equal to the number
            // of elements on each side * current - the sum of
            // the elements.
            result[i] = i * nums[i] - prefix + // left side
                        suffix - (nums[i] * (nums.Length - i - 1)); // right side

            // Add current to left side sum after calculating result
            prefix += nums[i];
        }

        return result;
    }
}
