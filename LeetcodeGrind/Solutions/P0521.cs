namespace LeetcodeGrind.Solutions;

// 521. Longest Uncommon Subsequence I
public class P0521
{
    public int FindLUSlength(string a, string b)
    {
        return a == b
            ? -1
            : Math.Max(a.Length, b.Length);
    }
}
