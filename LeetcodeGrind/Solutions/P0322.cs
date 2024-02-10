using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 322. Coin Change
public class P0322
{
    public int CoinChange(int[] coins, int amount)
    {
        // size = 0 to amount
        var dp = new int[amount + 1];
        Array.Fill(dp, amount + 1); // our max number

        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            foreach (var c in coins)
            {
                if (i - c >= 0)
                {
                    // when the coin value equals the index, you will
                    // get 1 + dp[0] => 1 + 0 => 1
                    dp[i] = Math.Min(dp[i], 1 + dp[i - c]);
                }
            }
        }
        return dp[amount] == amount + 1 ? -1 : dp[amount];
    }
}
