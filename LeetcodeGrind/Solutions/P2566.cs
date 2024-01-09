namespace LeetcodeGrind.Solutions;

// 2566. Maximum Difference by Remapping a Digit
public class P2566
{
    public int MinMaxDifference(int num)
    {
        var min = num;
        var max = num;

        for (int i = 0; i < 10; ++i)
        {
            var lo = 0;
            var hi = 0;
            var factor = 1;

            for (int n = num; n > 0; n /= 10)
            {
                bool replace = n % 10 == i;
                lo += (replace ? 0 : n % 10) * factor;
                hi += (replace ? 9 : n % 10) * factor;
                factor *= 10;
            }
            min = Math.Min(min, lo);
            max = Math.Max(max, hi);
        }

        return max - min;
    }
}
