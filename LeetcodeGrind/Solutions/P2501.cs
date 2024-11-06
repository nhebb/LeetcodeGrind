namespace LeetcodeGrind.Solutions;

// 2501. Longest Square Streak in an Array
public class P2501
{
    public int LongestSquareStreak(int[] nums)
    {
        var maxSquare = nums.Max();
        var hs = nums.ToHashSet();
        var mexLen = 1;
        var curLen = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            curLen = 0;
            long value = nums[i];
            while (value <= maxSquare && hs.Contains((int)value))
            {
                curLen++;
                value *= value;
            }
            mexLen = Math.Max(mexLen, curLen);
        }

        return mexLen > 1
            ? mexLen
            : -1;
    }
}
