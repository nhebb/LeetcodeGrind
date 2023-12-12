namespace LeetcodeGrind.Solutions;

// 1175. Prime Arrangements
public class P1175
{
    const int mod = 1_000_000_007;

    public int NumPrimeArrangements(int n)
    {
        if (n == 1)
            return 1;
        
        // Since n <= 100, it's easier to look up a prime
        // number table than to use Sieve of Eratosthenes.
        int[] primes =
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43,
            47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
        };

        int primesCount = primes.Count(p => p <= n);

        // Calculate the number permutations of the prime numbers
        // and the number of permutations of the non-prime numbers
        long factorial1 = Factorial(n - primesCount);
        long factorial2 = Factorial(primesCount);

        // The total number of permutations is the permutation
        // counts multiplied by each other.
        return (int)((factorial1 * factorial2) % mod);

    }

    private long Factorial(int n)
    {

        if (n == 1)
            return 1;

        return (n * Factorial(n - 1)) % mod;
    }
}

