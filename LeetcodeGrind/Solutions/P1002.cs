namespace LeetcodeGrind.Solutions;

// 1002. Find Common Characters
public class P1002
{
    public IList<string> CommonChars(string[] words)
    {
        var d = words[0].GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        for (int i = 1; i < words.Length; i++)
        {
            var d2 = words[i].GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            foreach (var kvp in d)
            {
                if (!d2.ContainsKey(kvp.Key))
                    d.Remove(kvp.Key);
                else
                    d[kvp.Key] = Math.Min(kvp.Value, d2[kvp.Key]);
            }
        }

        var result = new List<string>();
        foreach (var kvp in d)
        {
            for (int i = 0; i < kvp.Value; i++)
                result.Add(kvp.Key.ToString());
        }

        return result;
    }

}
