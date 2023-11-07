namespace LeetcodeGrind.Solutions;

// 191. Number of 1 Bits
public class P0191
{
    public int HammingWeight(uint n)
    {
        //int count = 0;
        //while (n > 0)
        //{
        //    if ((n & 1) == 1) { count++; }
        //    n >>= 1;
        //}
        //return count;

        return System.Numerics.BitOperations.PopCount(n);
    }
}
