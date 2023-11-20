namespace LeetcodeGrind.Solutions;

// 1207. Unique Number of Occurrences
public class P1207
{
    public bool UniqueOccurrences(int[] arr)
    {
        var d = arr.GroupBy(x => x)
                   .ToDictionary(g => g.Key, g => g.Count());

        var hs = new HashSet<int>();
        foreach (var value in d.Values)
        {
            if (!hs.Add(value))
                return false;
        }

        return true;
    }
}
