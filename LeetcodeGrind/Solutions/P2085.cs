namespace LeetcodeGrind.Solutions;

// 2085. Count Common Words With One Occurrence
public class P2085
{
    public int CountWords(string[] words1, string[] words2)
    {
        var d1 = words1.GroupBy(w => w)
                       .ToDictionary(g => g.Key, g => g.Count());

        var d2 = words2.GroupBy(w => w)
                       .ToDictionary(g => g.Key, g => g.Count());

        var count = 0;
        foreach (var kvp in d1)
        {
            if (kvp.Value == 1 && 
                d2.ContainsKey(kvp.Key) && 
                d2[kvp.Key] == 1)
            {
                count++;
            }
        }

        return count;
    }
}
