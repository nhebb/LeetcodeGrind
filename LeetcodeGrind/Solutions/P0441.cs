namespace LeetcodeGrind.Solutions;

// 441. Arranging Coins
public class P0441
{
    public int ArrangeCoins(int n)
    {
        // O(n) solution:
        if (n <= 1) 
            return n;

        var stairs = 0;

        while (n > stairs)
        {
            stairs++;
            n -= stairs;
        }

        return stairs;

        // binary solution relies on sum(1 .. r) = r(r+1)/2
        // search mid points until you find a result <= n

        // O(1): quadratic formula for r^2 + r - 2n = 0
        // => n = (int)
    }
}
