namespace LeetcodeGrind.Solutions;

// 41. First Missing Positive
public class P0041
{
    public int FirstMissingPositive(int[] nums)
    {
        if (nums == null || nums.Length == 0) { return 1; }
        int min = int.MaxValue;
        int max = int.MinValue;
        var hs = new HashSet<int>();

        foreach (var num in nums)
        {
            hs.Add(num);
            if (num < min) { min = num; }
            if (num > max) { max = num; }
        }

        if (max <= 0) { return 1; }
        if (min < 1) { min = 1; }
        if (min > 1) { return 1; }

        for (int i = min; i <= max; i++)
        {
            if (!hs.Contains(i)) { return i; }
        }
        return max + 1;
    }
}
