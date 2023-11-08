namespace LeetcodeGrind.Solutions;

// 122. Best Time to Buy and Sell Stock II
public class P0122
{
    public int MaxProfit(int[] prices)
    {
        var profit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            var delta = prices[i] - prices[i - 1];
            if (delta > 0)
                profit += delta;
        }

        return profit;
    }
}
