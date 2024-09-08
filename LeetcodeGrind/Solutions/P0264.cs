namespace LeetcodeGrind.Solutions;

// 264. Ugly Number II
public class P0264
{
    public int NthUglyNumber(int n)
    {
        // This is wrong because it allows factors
        // beyond just 2, 3, and 5.
        if (n <= 6)
        {
            return n;
        }

        var count = 6;
        var number = 6;

        while (count < n)
        {
            number++;
            if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0)
            {
                count++;
            }
        }

        return number;
    }
}
