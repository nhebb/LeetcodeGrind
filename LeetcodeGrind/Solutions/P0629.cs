namespace LeetcodeGrind.Solutions;

// 629. K Inverse Pairs Array
public class P0629
{
    const int mod = 1_000_000_007;
    private int?[,] cache = new int?[1001, 1002];

    public int KInversePairs(int n, int k)
    {
        if (n == 0)
            return 0;

        if (k == 0)
            return 1;

        if (cache[n, k].HasValue)
            return cache[n, k].Value;

        int inv = 0;
        for (int i = 0; i <= Math.Min(k, n - 1); i++)
        {
            inv = (inv + KInversePairs(n - 1, k - i)) % mod;
        }

        cache[n, k] = inv;
        return inv;
    }
}

