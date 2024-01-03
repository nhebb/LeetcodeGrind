namespace LeetcodeGrind.Solutions;

// 2595. Number of Even and Odd Bits
public class P2595
{
    public int[] EvenOddBit(int n)
    {
        var evens = 0;
        var odds = 0;

        while (n > 0)
        {
            if (n % 2 == 1)
            {
                evens++;
            }
            n /= 2;

            if (n % 2 == 1)
            {
                odds++;
            }
            n /= 2;
        }

        return new int[] { evens, odds };
    }
}
