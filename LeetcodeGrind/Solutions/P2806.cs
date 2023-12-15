namespace LeetcodeGrind.Solutions;

// 2806. Account Balance After Rounded Purchase
public class P2806
{
    public int AccountBalanceAfterPurchase(int purchaseAmount)
    {
        const int balance = 100;

        var ones = purchaseAmount % 10;
        if (ones >= 5)
        {
            purchaseAmount += 10 - ones;
        }
        else
        {
            purchaseAmount -= ones;
        }

        return balance - purchaseAmount;
    }
}
