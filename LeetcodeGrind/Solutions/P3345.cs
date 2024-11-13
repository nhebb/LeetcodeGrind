namespace LeetcodeGrind.Solutions;

// 3345. Smallest Divisible Digit Product I
public class P3345
{
    public int SmallestNumber(int n, int t)
    {
        int GetProductOfDigits(int val)
        {
            var product = 1;
            while (val > 0)
            {
                product *= val % 10;
                val /= 10;
            }

            return product;
        }

        var result = GetProductOfDigits(n);
        while (result % t != 0)
        {
            n++;
            result = GetProductOfDigits (n);
        }

        return n;
    }
}
