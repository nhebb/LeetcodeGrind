namespace LeetcodeGrind.Solutions;

// 560. Subarray Sum Equals K
public class P0560
{
    public int SubarraySum(int[] nums, int k)
    {
        var d = new Dictionary<int, int>();

        // track prefix sum counts in dictionary
        var sum = nums[0];
        var count = 0;
        if (sum == k)
            count++;
        d[sum] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            sum += nums[i];

            // check for base match
            if (sum == k)
                count++;

            // check for other matches, i.e., prefix subarrays that
            // we can remove to make matching subarray sums
            var delta = sum - k;
            if (d.TryGetValue(delta, out var deltaMatches))
                count += deltaMatches;

            // add prefix sum to dictionary
            if (d.TryGetValue(sum, out var lastCount))
                d[sum] = lastCount + 1;
            else
                d[sum] = 1;
        }
        return count;
    }
}
