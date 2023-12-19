namespace LeetcodeGrind.Solutions;

// 2706. Buy Two Chocolates
public class P2706
{
    public int BuyChoco(int[] prices, int money)
    {
        var min1 = int.MaxValue;
        var min2 = int.MaxValue;

        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < min1)
            {
                min2 = min1;
                min1 = prices[i];
            }
            else if (prices[i] < min2)
            {
                min2 = prices[i];
            }
        }

        var cost = min1 + min2;
        return cost <= money
            ? money - cost
            : money;
    }
}
