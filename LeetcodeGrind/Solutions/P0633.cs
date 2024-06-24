namespace LeetcodeGrind.Solutions;

// 633. Sum of Square Numbers
public class P0633
{
    public bool JudgeSquareSum(int c)
    {
        // Use binary search on solution
        var low = 0;
        var high = (int)Math.Sqrt(c);

        while (low <= high)
        {
            var sum = low * low + high * high;

            if (sum == c)
                return true;
            else if (sum < c)
                low++;
            else
                high--;
        }

        return false;
    }
}
