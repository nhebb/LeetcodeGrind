namespace LeetcodeGrind.Solutions;

// 693. Binary Number with Alternating Bits
public class P0693
{
    public bool HasAlternatingBits(int n)
    {
        var lastBit = (n & 1) == 1 ? 1 : 0;
        n /= 2;

        while (n > 0)
        {
            var bit = (n & 1) == 1 ? 1 : 0;
            if (bit == lastBit)
                return false;

            lastBit = bit;
            n /= 2;
        }

        return true;
    }
}
