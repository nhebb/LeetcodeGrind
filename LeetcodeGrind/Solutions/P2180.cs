namespace LeetcodeGrind.Solutions;

// 2180. Count Integers With Even Digit Sum
public class P2180
{
    public int CountEven(int num)
    {
        var n = num;
        var sum = 0;

        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }

        return sum % 2 == 0
            ? num / 2
            : (num - 1) / 2;
    }
}
