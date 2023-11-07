namespace LeetcodeGrind.Solutions;

// 2571. Minimum Operations to Reduce an Integer to 0
public class P2571
{
    public int MinOperations(int n)
    {
        int GetMostSignificantBit(int n)
        {
            if (n == 0)
                return 0;

            int msb = 0;
            n /= 2;

            while (n != 0)
            {
                n /= 2;
                msb++;
            }

            return (1 << msb);
        }

        int GetHammingWeight(int n)
        {
            var binary = Convert.ToString(n, 2);
            return binary.Count(c => c == '1');
        }

        var val1 = GetHammingWeight((GetMostSignificantBit(n) * 2)) + 1;
        var val2 = GetHammingWeight(n);

        return Math.Min(val1, val2);
    }
}
