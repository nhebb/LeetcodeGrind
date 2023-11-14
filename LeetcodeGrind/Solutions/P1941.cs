namespace LeetcodeGrind.Solutions;

//1941. Check if All Characters Have Equal Number of Occurrences
public class P1941
{
    public bool AreOccurrencesEqual(string s)
    {
        var d = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (!d.TryAdd(c, 1))
                d[c]++;
        }

        var count = d[s[0]];
        foreach (var kvp in d)
        {
            if (kvp.Value != count)
                return false;
        }
        return true;
    }
}
