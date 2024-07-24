namespace LeetcodeGrind.Solutions;

// 3223. Minimum Length of String After Operations
public class P3223
{
    public int MinimumLength(string s)
    {
        var counts = s.GroupBy(c => c)
                      .ToDictionary(g => g.Key, g => g.Count());

        var deleted = 0;
        foreach (var kvp in counts)
        {
            var count = kvp.Value;
            while (count > 2)
            {
                deleted += 2;
                count -= 2;
            }
        }

        return s.Length - deleted;
    }
}
