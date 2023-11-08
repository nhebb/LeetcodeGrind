namespace LeetcodeGrind.Solutions;

// 509. Fibonacci Number
public class P0509
{
    public int Fib(int n)
    {
        if (n < 2) return n;

        var ans = new int[n + 1];
        ans[0] = 0;
        ans[1] = 1;

        for (int i = 2; i <= n; i++)
            ans[i] = ans[i - 1] + ans[i - 2];

        return ans[n];
    }
}
