namespace LeetcodeGrind.Solutions;

// 128. Longest Consecutive Sequence
public class P0128
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums == null || nums.Length == 0) return 0;

        int maxCount = 1;
        var hs = new HashSet<int>(nums);

        foreach (var num in nums)
        {
            if (!hs.Contains(num - 1))
            {
                var count = 1;
                var val = num + 1;
                while (hs.Contains(val))
                {
                    count++;
                    val++;
                }
                maxCount = Math.Max(maxCount, count);
            }
        }

        return maxCount;
    }
}
