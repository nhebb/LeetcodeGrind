using System.Text;

namespace LeetcodeGrind.Solutions;

// 3039. Apply Operations to Make String Empty
public class P3039
{
    public string LastNonEmptyString(string s)
    {
        var max = 0;
        var d = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!d.ContainsKey(s[i]))
            {
                d[s[i]] = 1;
            }
            else
            {
                d[s[i]]++;
            }
            max = Math.Max(d[s[i]], max);
        }

        var sb = new StringBuilder();
        var indexes = new List<int>();
        foreach (var kvp in d)
        {
            if (kvp.Value == max)
            {
                indexes.Add(s.LastIndexOf(kvp.Key));
            }
        }
        indexes.Sort();

        for (int i = 0; i < indexes.Count; i++)
        {
            sb.Append(s[indexes[i]]);
        }

        return sb.ToString();
    }
}
