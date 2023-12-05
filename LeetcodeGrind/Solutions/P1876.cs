namespace LeetcodeGrind.Solutions;

// 1876. Substrings of Size Three with Distinct Characters
public class P1876
{
    public int CountGoodSubstrings(string s)
    {
        var count = 0;
        for (int i = 0; i < s.Length - 2; i++)
        {
            if (s[i] != s[i + 1] && s[i] != s[i + 2] && s[i + 1] != s[i + 2])
            {
                count++;
            }
        }
        return count;
    }
}
