namespace LeetcodeGrind.Solutions;

// 2287. Rearrange Characters to Make Target String
public class P2287
{
    public int RearrangeCharacters(string s, string target)
    {
        var sd = s.GroupBy(c => c)
                  .ToDictionary(g => g.Key, g => g.Count());

        var td = target.GroupBy(c => c)
                       .ToDictionary(g => g.Key, g => g.Count());

        var copies = int.MaxValue;

        foreach (var kvp in td)
        {
            if (sd.TryGetValue(kvp.Key, out var val))
            {
                copies = Math.Min(copies, val / kvp.Value);
            }
            else
            {
                return 0;
            }
        }

        return copies;
    }
}
