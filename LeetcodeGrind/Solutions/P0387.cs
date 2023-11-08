namespace LeetcodeGrind.Solutions;

// 387. First Unique Character in a String
public class P0387
{
    public int FirstUniqChar(string s)
    {
        var counts = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (counts.TryGetValue(s[i], out var val))
                counts[s[i]] = val + 1;
            else
                counts[s[i]] = 1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (counts[s[i]] == 1)
                return i;
        }

        return -1;
    }
}
