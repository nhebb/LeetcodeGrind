namespace LeetcodeGrind.Solutions;

// 424. Longest Repeating Character Replacement
public class P0424
{
    public int CharacterReplacement(string s, int k)
    {
        var abcCount = new int[26];

        int max = 0;
        int i = 0;
        int j = 0;

        while (j < s.Length)
        {
            abcCount[s[j] - 'A']++;
            if (j - i + 1 - abcCount.Max() > k)
            {
                abcCount[s[i] - 'A']--;
                i++;
            }
            max = Math.Max(max, j - i + 1);
            j++;
        }

        return max;
    }
}
