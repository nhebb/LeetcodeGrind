namespace LeetcodeGrind.Solutions;

// 3146. Permutation Difference between Two Strings
public class P3146
{
    public int FindPermutationDifference(string s, string t)
    {
        var ds = new Dictionary<char, int>(26);
        var dt = new Dictionary<char, int>(26);

        for (int i = 0; i < s.Length; i++)
        {
            ds[s[i]] = i;
            dt[t[i]] = i;
        }

        var diff = 0;
        foreach (var kvp in ds)
        {
            diff += Math.Abs(kvp.Value - dt[kvp.Key]);
        }

        return diff;
    }
}
