namespace LeetcodeGrind.Solutions;

// 1759. Count Number of Homogenous Substrings
public class P1759
{
    public int CountHomogenous(string s)
    {
        const int mod = 1_000_000_007;

        long count = 0;
        long current = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] != s[i - 1])
            {
                current = ((current % mod * (current + 1) % mod) % mod) / 2;
                count = (count % mod + current % mod) % mod;
                current = 0;
            }

            current++;
        }

        current = ((current % mod * (current + 1) % mod) % mod) / 2;
        count = (count % mod + current % mod) % mod;

        return (int)count;
    }
}
