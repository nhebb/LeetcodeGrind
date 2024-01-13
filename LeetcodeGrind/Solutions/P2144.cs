namespace LeetcodeGrind.Solutions;

// 2144. Minimum Cost of Buying Candies With Discount
public class P2144
{
    public int MinimumCost(int[] cost)
    {
        Array.Sort(cost);

        var total = 0;
        for (int i = cost.Length - 1; i >= 0; i--)
        {
            total += cost[i];
            if (i > 0)
                total += cost[i - 1];
            i -= 2;
        }

        return total;
    }
}
