namespace LeetcodeGrind.Solutions;

// 2716. Minimize String Length
public class P2716
{
    public int MinimizedStringLength(string s)
    {
        return s.ToHashSet().Count;
    }

    // slightly faster
    public int MinimizedStringLength2(string s)
    {
        var hs = new HashSet<char>(s.Length);
        var count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (hs.Add(s[i]))
            {
                count++;
            }
        }

        return count;
    }

    // slower
    public int MinimizedStringLength3(string s)
    {
        return s.Distinct().Count();
    }
}
