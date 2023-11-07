namespace LeetcodeGrind.Solutions;

// 2575. Find the Divisibility Array of a String
public class P2575
{
    public int[] DivisibilityArray(string word, int m)
    {
        var res = new int[word.Length];
        var prefix = 0;
        for (int i = 0; i < word.Length; i++)
        {
            prefix = (10 * prefix) % m + (word[i] - '0') % m;
            if (prefix % m == 0)
                res[i] = 1;
        }

        return res;
    }
}
