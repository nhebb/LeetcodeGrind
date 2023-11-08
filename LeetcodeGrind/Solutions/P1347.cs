namespace LeetcodeGrind.Solutions;

// 1347. Minimum Number of Steps to Make Two Strings Anagram
public class P1347
{
    public int MinSteps(string s, string t)
    {
        var ds = new Dictionary<char, int>();
        var dt = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (ds.TryGetValue(s[i], out var val))
                ds[s[i]] = val + 1;
            else
                ds[s[i]] = 1;
        }
        for (int i = 0; i < t.Length; i++)
        {
            if (dt.TryGetValue(t[i], out var val))
                dt[t[i]] = val + 1;
            else
                dt[t[i]] = 1;
        }

        var need = 0;
        foreach (var kvp in ds)
        {
            if (dt.ContainsKey(kvp.Key))
                need += Math.Max(0, kvp.Value - dt[kvp.Key]);
            else
                need += kvp.Value;
        }

        return need;
    }
}
