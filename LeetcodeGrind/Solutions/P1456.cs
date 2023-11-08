namespace LeetcodeGrind.Solutions;

// 1456. Maximum Number of Vowels in a Substring of Given Length
public class P1456
{
    public int MaxVowels(string s, int k)
    {
        var vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

        var maxVowels = 0;
        for (int i = 0; i < k; i++)
        {
            if (vowels.Contains(s[i]))
                maxVowels++;
        }

        var curVowels = maxVowels;
        for (int i = 0, j = k; j < s.Length; i++, j++)
        {
            if (vowels.Contains(s[i]))
                curVowels--;
            if (vowels.Contains(s[j]))
                curVowels++;
            maxVowels = Math.Max(curVowels, maxVowels);
        }

        return maxVowels;
    }
}
