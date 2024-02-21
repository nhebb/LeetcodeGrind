namespace LeetcodeGrind.Solutions;

// 2485. Find the Pivot Integer
public class P2485
{
    public int PivotInteger(int n)
    {
        var prefix = new int[n];
        var suffix = new int[n];

        prefix[0] = 1;
        for (int i = 2; i < n; i++)
            prefix[i - 1] = prefix[i - 2] + i;

        suffix[^1] = n;
        for (int i = n - 1; i > 0; i--)
            suffix[i - 1] = suffix[i] + i;

        for (int i = 0; i < n; i++)
            if (prefix[i] == suffix[i])
                return i + 1;

        return -1;
    }
}
