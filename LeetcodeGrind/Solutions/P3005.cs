namespace LeetcodeGrind.Solutions;

public class P3005
{
    public int MaxFrequencyElements(int[] nums)
    {
        var max = 0;
        var counts = new int[101];
        foreach (var num in nums)
        {
            counts[num]++;
            max = Math.Max(max, counts[num]);
        }

        return counts.Count(x => x == max) * max;
    }
}
