namespace LeetcodeGrind.Solutions;

// 908. Smallest Range I
public class P0908
{
    public int SmallestRangeI(int[] nums, int k)
    {
        var max = nums.Max();
        var min = nums.Min();
        var delta = max - min - 2 * k;
        return Math.Max(delta, 0);
    }
}
