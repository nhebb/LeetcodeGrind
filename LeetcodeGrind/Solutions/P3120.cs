namespace LeetcodeGrind.Solutions;

// 3120. Count the Number of Special Characters I
public class P3120
{
    public int NumberOfSpecialChars(string word)
    {
        var lower = new bool[26];
        var upper = new bool[26];

        foreach (var c in word)
        {
            if (char.IsLower(c))
            {
                lower[c - 'a'] = true;
            }
            else
            {
                upper[c - 'A'] = true;
            }
        }

        var count = 0;
        for (int i = 0; i < 26; i++)
        {
            if (lower[i] && upper[i])
            {
                count++;
            }
        }

        return count;
    }
}
