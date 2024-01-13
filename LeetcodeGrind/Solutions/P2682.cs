namespace LeetcodeGrind.Solutions;

// 2682. Find the Losers of the Circular Game
public class P2682
{
    public int[] CircularGameLosers(int n, int k)
    {
        var hs = new HashSet<int>();
        var factor = 1;
        var x = 0;
        while (hs.Add(x + 1))
        {
            x = (x + k * factor) % n;
            factor++;
        }

        var result = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            if (!hs.Contains(i))
                result.Add(i);
        }

        return result.ToArray();
    }
}
