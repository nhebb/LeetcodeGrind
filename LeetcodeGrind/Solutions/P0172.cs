namespace LeetcodeGrind.Solutions;

// 172. Factorial Trailing Zeroes
public class P0172
{
    public int TrailingZeroes(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n / 5;
            n /= 5;
        }
        return count;
    }
}
