namespace LeetcodeGrind.Solutions;

// 935. Knight Dialer
public class P0935
{
    public int KnightDialer(int n)
    {
        // Note: An adjacency list for the available
        // knight paths would look like this:
        // 0 => { 4, 6 }
        // 1 => { 6, 8 }
        // 2 => { 7, 9 }
        // 3 => { 4, 8 }
        // 4 => { 0, 3, 9 }
        // 6 => { 0, 1, 7 }
        // 7 => { 2, 6 }
        // 8 => { 1, 3 }
        // 9 => { 2, 4 }

        if (n == 1)
            return 10;

        long mod = 1_000_000_007;

        // Cache previous iteration totals for DP solution
        var cache = new long[10];
        Array.Fill(cache, 1);

        // Store current iteration
        var cur = new long[10];

        // Filling the pre[] array with 1's counts
        // as step 1 on the way to 'n', so we can
        // decrement n before starting the loop.
        n--;

        while (n > 0)
        {
            cur[0] = (cache[4] + cache[6]) % mod;
            cur[1] = (cache[6] + cache[8]) % mod;
            cur[2] = (cache[7] + cache[9]) % mod;
            cur[3] = (cache[4] + cache[8]) % mod;
            cur[4] = (cache[3] + cache[9] + cache[0]) % mod;
            // There is no knight path into or out of 5
            cur[6] = (cache[1] + cache[7] + cache[0]) % mod;
            cur[7] = (cache[2] + cache[6]) % mod;
            cur[8] = (cache[1] + cache[3]) % mod;
            cur[9] = (cache[2] + cache[4]) % mod;

            // update DP cache
            for (int i = 0; i < 10; i++)
            {
                cache[i] = cur[i];
            }

            n--;
        }

        long sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum = (sum + cur[i]) % mod;
        }

        return (int)sum;
    }
}

