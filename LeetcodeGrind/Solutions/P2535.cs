namespace LeetcodeGrind.Solutions;

// 2535. Difference Between Element Sum and Digit Sum of an Array
public class P2535
{
    public int DifferenceOfSum(int[] nums)
    {
        var sumNums = 0;
        var sumDigits = 0;

        foreach (var num in nums)
        {
            sumNums += num;
            var n = num;
            while (n > 0)
            {
                sumDigits += n % 10;
                n /= 10;
            }
        }

        return Math.Abs(sumNums - sumDigits);
    }
}
