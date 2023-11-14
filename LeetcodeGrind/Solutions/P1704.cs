namespace LeetcodeGrind.Solutions;

// 1704. Determine if String Halves Are Alike
public class P1704
{
    public bool HalvesAreAlike(string s)
    {
        s = s.ToLower();
        var vowels = "aeiou".ToHashSet();
        var count1 = 0;
        var count2 = 0;
        var halfLen = s.Length / 2;

        for (int i = 0; i < halfLen; i++)
        {
            if (vowels.Contains(s[i]))
                count1++;
            if (vowels.Contains(s[i + halfLen]))
                count2++;
        }

        return count1 == count2;
    }
}
