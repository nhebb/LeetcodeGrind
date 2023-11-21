namespace LeetcodeGrind.Solutions;

// 594. Longest Harmonious Subsequence
public class P0594
{
    public int FindLHS(int[] nums)
    {
        // Get the count of each number
        var d = nums.GroupBy(x => x)
                    .ToDictionary(g => g.Key, g => g.Count());

        var max = 0;

        // For each number in the dictionary, check if there
        // is another key that is 1 greater than it and sum
        // their counts.
        foreach (var kvp in d)
        {
            if (d.ContainsKey(kvp.Key + 1))
            {
                max = Math.Max(max, kvp.Value + d[kvp.Key + 1]);
            }
        }

        return max;
    }
}
