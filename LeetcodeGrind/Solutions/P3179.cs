namespace LeetcodeGrind.Solutions;

// 3179. Find the N-th Value After K Seconds
public class P3179
{
    public int ValueAfterKSeconds(int n, int k)
    {
        const int mod = 1_000_000_007;

        var prefixSum = new int[n];
        Array.Fill(prefixSum, 1);

        for (int i = 0; i < k; i++)
        {
            for (int j = 1; j < n; j++)
            {
                prefixSum[j] = (prefixSum[j - 1] + prefixSum[j]) % mod;
            }
        }

        return prefixSum[^1] % mod;
    }
}
