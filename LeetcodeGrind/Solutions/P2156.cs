namespace LeetcodeGrind.Solutions;

// 2156. Find Substring With Given Hash Value
public class P2156
{
    public string SubStrHash(string s, int power, int modulo, int k, int hashValue)
    {
        var powers = Enumerable.Range(0, k)
                               .Select(x => (int)(Math.Pow(power, x) % modulo))
                               .ToArray();

        var charVals = s.Select(c => c - 'a' + 1)
                        .ToArray();

        int hash(int i)
        {
            var sum = 0;
            for (int j = i; j < i + k; j++)
                sum += charVals[j] * powers[j - i];
            return sum % modulo;
        }

        for (int i = 0; i + k <= s.Length; i++)
        {
            var h = hash(i);
            if (h == hashValue)
                return s.Substring(i, k);
        }

        return "fail";
    }

    public string SubStrHash2(string s, int power, int mod, int k, int hashValue)
    {
        long hash = 0;
        long p2k = 1;
        int start = s.Length - 1;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            int charval = s[i] - 'a' + 1;
            hash = (hash * power + charval) % mod;
            if (i < s.Length - k)
            {
                charval = s[i + k] - 'a' + 1;
                hash = (mod + hash - ((p2k * charval) % mod)) % mod;
            }
            else
            {
                p2k = (p2k * power) % mod;
            }

            if (hash == hashValue)
                start = i;
        }

        return s.Substring(start, k);
    }
}
