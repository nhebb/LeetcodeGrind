namespace LeetcodeGrind.Solutions;

// 389. Find the Difference
public class P0389
{
    public char FindTheDifference(string s, string t)
    {
        var num = 0;

        for (int i = 0; i < s.Length; i++)
            num ^= s[i] ^ t[i];

        return (char)(num ^ t[^1]);
    }
}
