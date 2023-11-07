namespace LeetcodeGrind.Solutions;

// 204. Count Primes
public class P0204
{
    public int CountPrimes(int n)
    {
        // Sieve of Eratosthenes
        if (n <= 2) return n;
        var count = 0;
        var nonprimes = new bool[n];

        for (int i = 2; i < n; i++)
        {
            if (nonprimes[i])
                continue;

            count++;

            var factor = 2;
            while (i * factor < n)
            {
                nonprimes[i * factor] = true;
                factor++;
            }
        }

        return count;
    }
}
