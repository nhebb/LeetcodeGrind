namespace LeetcodeGrind.Solutions;

// 1475. Final Prices With a Special Discount in a Shop
public class P1475
{
    // Monotonic stack - O(n)
    public int[] FinalPricesStack(int[] prices)
    {
        // Leetcode Problem Description:
        // 
        // If you buy the ith item, then you will receive a discount
        // equivalent to prices[j] where j is the minimum index such
        // that j > i and prices[j] <= prices[i].
        //
        // Note: This solution uses indexes i and j to be consistent
        //       with the description above.

        var stack = new Stack<int>();

        for (int j = 0; j < prices.Length; j++)
        {
            // Note: stack.Peek() would contain index "i" in the context
            // of the Leetcode problem description above.
            while (stack.Count > 0 && prices[j] <= prices[stack.Peek()])
            {
                // This works by looking backwards at previous indexes
                // and comparing the price to see if the discount can
                // be applied to the previous item.
                var i = stack.Pop();
                prices[i] -= prices[j];
            }

            stack.Push(j);
        }

        return prices;
    }

    // Brute force - O(n^2)
    public int[] FinalPricesBrute(int[] prices)
    {
        for (int i = 0; i < prices.Length - 1; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                if (prices[j] <= prices[i])
                {
                    prices[i] -= prices[j];
                    break;
                }
            }
        }
        return prices;
    }
}
