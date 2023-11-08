namespace LeetcodeGrind.Solutions;

// 1930. Unique Length-3 Palindromic Subsequences
public class P1930
{
    public int CountPalindromicSubsequence(string s)
    {
        var count = 0;
        var d = new Dictionary<char, List<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            if (d.TryGetValue(s[i], out var list))
                list.Add(i);
            else
                d[s[i]] = new List<int>() { i };
        }

        var hs = new HashSet<string>();

        foreach (var kvp in d)
        {
            if (kvp.Value.Count < 2)
                continue;

            var i = kvp.Value[0];
            var j = kvp.Value[^1];

            if (j - i < 2)
                continue;

            var letter = kvp.Key.ToString();

            for (int k = i + 1; k < j; k++)
            {
                var seq = letter + s[k].ToString() + letter;
                if (hs.Add(seq))
                    count++;
            }
        }

        return count;
    }
}
