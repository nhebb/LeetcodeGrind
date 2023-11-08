namespace LeetcodeGrind.Solutions;

// 697. Degree of an Array
public class P0697
{
    public int FindShortestSubArray(int[] nums)
    {
        var numIndices = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (numIndices.TryGetValue(nums[i], out var list))
                list.Add(i);
            else
                numIndices[nums[i]] = new List<int> { i };
        }

        var maxFreq = 0;
        var minLen = nums.Length;

        foreach (var kvp in numIndices)
        {
            if (kvp.Value.Count > maxFreq)
            {
                maxFreq = kvp.Value.Count;
                minLen = kvp.Value[^1] - kvp.Value[0] + 1;
            }
            else if (kvp.Value.Count == maxFreq)
            {
                var curLen = kvp.Value[^1] - kvp.Value[0] + 1;
                minLen = Math.Min(minLen, curLen);
            }
        }
        return minLen;
    }
}
