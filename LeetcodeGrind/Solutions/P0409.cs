namespace LeetcodeGrind.Solutions;

// 409. Longest Palindrome
public class P0409
{
    public int LongestPalindrome(string s)
    {
        if (s.Length <= 1)
        {
            return s.Length;
        }

        var d = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (d.TryGetValue(s[i], out int value))
            {
                d[s[i]] = ++value;
            }
            else
            {
                d[s[i]] = 1;
            }
        }

        var count = 0;
        var hasOdd = false;
        foreach (var kvp in d)
        {
            var charCount = kvp.Value;
            hasOdd |= charCount % 2 == 1;

            while (charCount > 1)
            {
                count += 2;
                charCount -= 2;
            }
        }

        if (hasOdd)
        {
            count++;
        }

        return count;
    }
}
