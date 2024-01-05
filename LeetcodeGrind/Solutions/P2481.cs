namespace LeetcodeGrind.Solutions;

// 2481. Minimum Cuts to Divide a Circle
public class P2481
{
    public int NumberOfCuts(int n)
    {
        if (n == 1)
            return 0;

        return n % 2 == 1
            ? n
            : n / 2;
    }
    r
}
