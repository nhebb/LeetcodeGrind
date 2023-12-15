namespace LeetcodeGrind.Solutions;

// 2778. Sum of Squares of Special Elements 
public class P2778
{
    public int SumOfSquares(int[] nums)
    {
        var n = nums.Length;
        var sum = 0;

        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                sum += nums[i - 1] * nums[i - 1];
            }
        }

        return sum;
    }
}
