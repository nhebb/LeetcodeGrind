namespace LeetcodeGrind.Solutions;

// 2068. Check Whether Two Strings are Almost Equivalent
public class P2068
{
    public bool CheckAlmostEquivalent(string word1, string word2)
    {
        var d1 = word1.GroupBy(c => c)
                      .ToDictionary(g => g.Key, g => g.Count());

        var d2 = word2.GroupBy(c => c)
                      .ToDictionary(g => g.Key, g => g.Count());

        var max = 0;

        foreach (var kvp in d1)
        {
            if (!d2.ContainsKey(kvp.Key))
            {
                max = Math.Max(max, kvp.Value);
            }
            else
            {
                max = Math.Max(max, Math.Abs(kvp.Value - d2[kvp.Key]));
                d2.Remove(kvp.Key);
            }
        }

        foreach (var kvp in d2)
        {
            max = Math.Max(max, kvp.Value);
        }

        return max <= 3;
    }
}
