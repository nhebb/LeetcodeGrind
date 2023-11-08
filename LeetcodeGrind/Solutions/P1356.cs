namespace LeetcodeGrind.Solutions;

// 1356. Sort Integers by The Number of 1 Bits
public class P1356
{
    public int[] SortByBits(int[] arr)
    {
        int GetBits(int n)
        {
            var bits = 0;
            while (n > 0)
            {
                if ((n & 1) == 1)
                    bits++;
                n >>= 1;
            }
            return bits;
        }
        return arr.OrderBy(x => GetBits(x))
                  .ThenBy(x => x)
                  .ToArray();
    }
}
