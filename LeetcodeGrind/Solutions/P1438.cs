namespace LeetcodeGrind.Solutions;

// 1438. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit
public class P1438
{
    public int LongestSubarray(int[] nums, int limit)
    {
        var left = 0;
        var maxLen = 0;

        // The dictionary key is the nums[right] value,
        // and the dictionary value is the index.
        var sd = new SortedDictionary<int, int>();

        for (int right = 0; right < nums.Length; right++)
        {
            if (sd.TryGetValue(nums[right], out int value))
            {
                sd[nums[right]] = ++value;
            }
            else
            {
                sd[nums[right]] = 1;
            }

            while (sd.Count > 1 && sd.Last().Key - sd.First().Key > limit)
            {
                sd[nums[left]]--;
                if (sd[nums[left]] == 0)
                {
                    sd.Remove(nums[left]);
                }
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }


    // The solution below originates from one of @Lee215's solutions.
    // It's a bit faster than the sorted dictionary solution.
    public int LongestSubarray2(int[] nums, int limit)
    {
        var maxQueue = new LinkedList<int>();
        var minQueue = new LinkedList<int>();

        var left = 0;
        var right = 0;
        var maxLen = 0;

        while (right < nums.Length)
        {
            while (maxQueue.Count > 0 && nums[maxQueue.Last.Value] <= nums[right])
            {
                maxQueue.RemoveLast();
            }
            maxQueue.AddLast(right);

            while (minQueue.Count > 0 && nums[minQueue.Last.Value] >= nums[right])
            {
                minQueue.RemoveLast();
            }
            minQueue.AddLast(right);

            while (maxQueue.Count > 0 && minQueue.Count > 0 && 
                   nums[maxQueue.First.Value] - nums[minQueue.First.Value] > limit)
            {
                left++;
                if (maxQueue.First.Value < left)
                {
                    maxQueue.RemoveFirst();
                }

                if (minQueue.First.Value < left)
                {
                    minQueue.RemoveFirst();
                }
            }

            maxLen = Math.Max(maxLen, right - left + 1);
            right++;
        }

        return maxLen;
    }
}
