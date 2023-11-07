namespace LeetcodeGrind.Solutions;

// 2427. Number of Common Factors
public class P2427
{
    public int CommonFactors(int a, int b)
    {
        var factors = new List<int>();
        int lesser = a < b ? a : b;
        var greater = a > b ? a : b;
        var start = greater / 2;

        for (int i = start; i > 1; i--)
        {
            if (greater % i == 0)
                factors.Add(i);
        }

        var count = 1; // for "1" itself
        foreach (var factor in factors)
        {
            if (factor <= lesser && lesser % factor == 0)
                count++;
        }

        if (a == b && a > 1)
            count++;

        return count;
    }
}
