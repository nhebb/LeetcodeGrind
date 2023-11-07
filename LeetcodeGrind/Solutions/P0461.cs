namespace LeetcodeGrind.Solutions;

// 461. Hamming Distance
public class P0461
{
    public int HammingDistance(int x, int y)
    {
        var val = x ^ y;
        var hammingDistance = 0;
        while (val > 0)
        {
            if ((val & 1) == 1)
                hammingDistance++;
            val >>= 1;
        }
        return hammingDistance;
    }
}
