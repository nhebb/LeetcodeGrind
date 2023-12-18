namespace LeetcodeGrind.Solutions;

// 1837. Sum of Digits in Base K
public class P1837
{
    public int SumBase(int n, int k)
    {
        var sum = 0;

        while (n > 0)
        {
            sum += n % k;
            n /= k;
        }

        return sum;
    }
}
