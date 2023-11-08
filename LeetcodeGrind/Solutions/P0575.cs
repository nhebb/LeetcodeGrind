namespace LeetcodeGrind.Solutions;

// 575. Distribute Candies
public class P0575
{
    public int DistributeCandies(int[] candyType)
    {
        var hs = candyType.ToHashSet();
        return Math.Min(hs.Count, candyType.Length / 2);
    }
}
