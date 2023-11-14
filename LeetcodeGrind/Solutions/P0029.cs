namespace LeetcodeGrind.Solutions;

// 29. Divide Two Integers
public class P0029
{
    public int Divide(int dividend, int divisor)
    {
        // A little 'bit' too much for my taste.
        
        if (dividend == int.MinValue && divisor == -1)
            return int.MaxValue;

        return (int)((long)dividend / divisor);
    }
}
