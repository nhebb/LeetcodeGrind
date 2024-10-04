namespace LeetcodeGrind.Solutions;

// 3300. Minimum Element After Replacement With Digit Sum
public class P3300
{
    public int MinElement(int[] nums)
    {
        var min = int.MaxValue;

        foreach (var num in nums)
        {
            var sum = 0;
            var val = num;
            while (val > 0)
            {
                sum += val % 10;
                val /= 10;
            }
            min = Math.Min(min, sum);
        }

        return min;
    }
}
