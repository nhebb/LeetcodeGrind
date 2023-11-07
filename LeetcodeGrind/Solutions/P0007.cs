namespace LeetcodeGrind.Solutions;

// 7. Reverse Integer
public class P0007
{
    public int Reverse(int x)
    {
        double val = x % 10;

        while (Math.Abs(x / 10) > 0)
        {
            x /= 10;
            val = (val * 10) + (x % 10);
        }

        if (val < int.MinValue
            || val > int.MaxValue)
        {
            return 0;
        }
        return (int)val;
    }
}
