namespace LeetcodeGrind.Solutions;

// 1413. Minimum Value to Get Positive Step by Step Sum
public class P1413
{
    public int MinStartValue(int[] nums)
    {
        var prefix = nums[0];
        var min = prefix;
        for (int i = 1; i < nums.Length; i++)
        {
            prefix += nums[i];
            min = Math.Min(min, prefix);
        }

        return min > 0
            ? 1
            : -min + 1;
    }
}
