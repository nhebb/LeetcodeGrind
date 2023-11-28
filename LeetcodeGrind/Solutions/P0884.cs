namespace LeetcodeGrind.Solutions;

// 884. Uncommon Words from Two Sentences
public class P0884
{
    public string[] UncommonFromSentences(string s1, string s2)
    {
        var words1 = s1.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .GroupBy(w => w)
                       .ToDictionary(g => g.Key, g => g.Count());
        var words2 = s2.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .GroupBy(w => w)
                       .ToDictionary(g => g.Key, g => g.Count());

        var ans = new List<string>();

        foreach (var kvp in words1)
        {
            if (kvp.Value == 1 && !words2.ContainsKey(kvp.Key))
                ans.Add(kvp.Key);
        }

        foreach (var kvp in words2)
        {
            if (kvp.Value == 1 && !words1.ContainsKey(kvp.Key))
                ans.Add(kvp.Key);
        }

        return ans.ToArray();
    }
}
