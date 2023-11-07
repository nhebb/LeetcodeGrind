namespace LeetcodeGrind.Solutions;

// 1979. Find Greatest Common Divisor of Array
public class P1979
{
    public int FindGCD(int[] nums)
    {
        var min = int.MaxValue;
        var max = int.MinValue;

        // You could do nums.Min() and nums.Max(), but
        // that would require 2 separate passes over the 
        // array, so I just did it manually.
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < min)
                min = nums[i];
            else if (nums[i] > max)
                max = nums[i];
        }

        // Euclid's Algorithm
        while (max % min > 0)
        {
            var rem = max % min;
            max = min;
            min = rem;
        }

        return min;
    }

    public int FindGCDLinq(int[] nums)
    {
        var min = nums.Min();
        var max = nums.Max();

        // Euclid's Algorithm
        while (max % min > 0)
        {
            var rem = max % min;
            max = min;
            min = rem;
        }

        return min;
    }
}
