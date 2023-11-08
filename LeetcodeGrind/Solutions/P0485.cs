namespace LeetcodeGrind.Solutions;

// 485. Max Consecutive Ones
public class P0485
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var s = string.Join("", nums);
        var arr = s.Split('0', StringSplitOptions.RemoveEmptyEntries);
        var max = 0;
        foreach (var ones in arr)
        {
            max = Math.Max(max, ones.Length);
        }

        return max;
    }
}
