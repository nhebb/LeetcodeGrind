namespace LeetcodeGrind.Solutions;

// 164. Maximum Gap
public class P0164
{
    // Bucket sort approach
    public int MaximumGap(int[] nums)
    {
        if (nums.Length == 1)
            return 0;

        // The LINQ calls below require 2 passes. It
        // could be speed up by making a for loop
        // and doing it manually:
        var min = nums.Min();
        var max = nums.Max();

        // Create an array of tuples to store the min and
        // max values for each bucket interval.
        var buckets = new (int Low, int High)[nums.Length + 1];
        Array.Fill(buckets, (int.MaxValue, int.MinValue));

        double delta = max == min ? 1.0 : (double)(max - min);
        double interval = nums.Length / delta;

        // Set the low and high values for the buckets
        for (int i = 0; i < nums.Length; i++)
        {
            var index = (int)((nums[i] - min) * interval);
            buckets[index].Low = Math.Min(buckets[index].Low, nums[i]);
            buckets[index].High = Math.Max(buckets[index].High, nums[i]);
        }

        int result = 0;
        int prev = buckets[0].High;
        for (int i = 1; i < buckets.Length; i++)
        {
            if (buckets[i].Low == int.MaxValue)
                continue; // no values in bucket

            // The low value in each bucket should be greater
            // than the previous bucket's high, so we take the
            // difference to find the max gap.
            result = Math.Max(result, buckets[i].Low - prev);
            prev = buckets[i].High;
        }

        return result;
    }
}
