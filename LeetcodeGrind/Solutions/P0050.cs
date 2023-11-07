namespace LeetcodeGrind.Solutions;

// 50. Pow(x, n)
public class P0050
{
    public double MyPow(double x, int n)
    {
        if (n == 0) return 1.0;
        if (x == 1.0) return x;

        if (x == -1.0)
            return (n % 2 == 0) ? 1.0 : -1.0;

        bool neg = false;
        if (n < 0)
        {
            neg = true;
            n *= -1;
        }

        if (n == int.MinValue)
            return 0.0;

        double result = 1.0;
        for (int i = 0; i < n; i++)
        {
            result *= x;
        }

        return neg ? 1 / result : result;
    }
}
