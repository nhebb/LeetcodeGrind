namespace LeetcodeGrind.Solutions;

// 2255. Count Prefixes of a Given String
public class P2255
{
    public int CountPrefixes(string[] words, string s)
    {
        return words.Where(w => s.StartsWith(w)).Count();
    }
}
