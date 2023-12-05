namespace LeetcodeGrind.Solutions;

// 888. Fair Candy Swap
public class P0888
{
    public int[] FairCandySwap(int[] aliceSizes, int[] bobSizes)
    {
        var aliceSum = aliceSizes.Sum();
        var bobSum = bobSizes.Sum();
        var hsBob = bobSizes.ToHashSet();

        var delta = (bobSum - aliceSum) / 2;

        for (int i = 0; i < aliceSizes.Length; i++)
        {
            if (hsBob.Contains(aliceSizes[i] + delta))
            {
                return new int[] { aliceSizes[i], aliceSizes[i] + delta };
            }
        }

        return null;
    }
}
