namespace LeetcodeGrind.Solutions;

// 2537. Count the Number of Good Subarrays
// TODO: Finish this. Solution yields Wrong Answer
public class P2537
{
    public long CountGood(int[] nums, int k)
    {
        var d = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.TryGetValue(nums[i], out var list))
                list.Add(i);
            else
                d[nums[i]] = new List<int>() { i };
        }

        long count = 0;
        foreach (var kvp in d)
        {
            var n = kvp.Value.Count;
            var numPairs = (n * (n - 1)) / 2;
            while (numPairs >= k && n > 0)
            {
                count++;
                n--;
                numPairs = (n * (n - 1)) / 2;
            }
        }

        return count;
    }
}
