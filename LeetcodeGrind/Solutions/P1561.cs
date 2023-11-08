namespace LeetcodeGrind.Solutions;

// 1561. Maximum Number of Coins You Can Get
public class P1561
{
    public int MaxCoins(int[] piles)
    {
        Array.Sort(piles);
        var count = 0;

        for (int j = piles.Length - 2; j >= piles.Length / 3; j -= 2)
            count += piles[j];

        return count;
    }
}
