namespace LeetcodeGrind.Solutions;

// 121. Best Time to Buy and Sell Stock
public class P0121
{
    public int MaxProfit(int[] prices)
    {
        int lowestPrice = int.MaxValue;
        int maxProfit = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            lowestPrice = Math.Min(lowestPrice, prices[i]);
            int currentProfit = prices[i] - lowestPrice;
            maxProfit = Math.Max(maxProfit, currentProfit);
        }
        return maxProfit;
    }
}

