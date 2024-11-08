namespace LeetcodeGrind.Solutions;

// 2275. Largest Combination With Bitwise AND Greater Than Zero
public class P2275
{
    public int LargestCombination(int[] candidates)
    {

        // max candidate is 10^7 => 24 bits
        var bits = new int[24];

        for (int i = 0; i < candidates.Length; i++)
        {
            var mask = 1;

            for (int j = 0; j < 24; j++)
            {
                if ((candidates[i] & mask) > 0)
                {
                    bits[j]++;
                }
                mask *= 2;
            }
        }

        return bits.Max();
    }
}
