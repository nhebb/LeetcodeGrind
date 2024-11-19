namespace LeetcodeGrind.Solutions;

// 2461. Maximum Sum of Distinct Subarrays With Length K
public class P2461
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        var numbers = new Dictionary<int, int>(k);
        var i = 0;
        var j = 0;
        long sum = 0;
        long max = 0;

        // fill initial k numbers
        while (j < k)
        {
            if (numbers.TryGetValue(nums[j], out int value))
            {
                numbers[nums[j]] = ++value;
            }
            else
            {
                numbers[nums[j]] = 1;
            }
            sum += nums[j];
            j++;
        }

        if (numbers.Keys.Count == k)
        {
            max = Math.Max(max, sum);
        }

        // sliding window
        while (j < nums.Length)
        {
            numbers[nums[i]]--;
            if (numbers[nums[i]] == 0)
            {
                numbers.Remove(nums[i]);
            }

            if (numbers.TryGetValue(nums[j], out int value))
            {
                numbers[nums[j]] = ++value;
            }
            else
            {
                numbers[nums[j]] = 1;
            }

            sum -= nums[i];
            sum += nums[j];
            if (numbers.Keys.Count == k)
            {
                max = Math.Max(max, sum);
            }

            i++;
            j++;
        }

        return max;
    }
}
