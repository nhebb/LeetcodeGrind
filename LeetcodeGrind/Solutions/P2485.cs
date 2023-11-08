namespace LeetcodeGrind.Solutions;

// 2485. Find the Pivot Integer
public class P2485
{
    public int PivotInteger(int n)
    {
        var prefix = new int[n];
        var postfix = new int[n];

        prefix[0] = 1;
        for (int i = 2; i < n; i++)
            prefix[i - 1] = prefix[i - 2] + i;

        postfix[^1] = n;
        for (int i = n - 1; i > 0; i--)
            postfix[i - 1] = postfix[i] + i;

        for (int i = 0; i < n; i++)
            if (prefix[i] == postfix[i])
                return i + 1;

        return -1;
    }
}
