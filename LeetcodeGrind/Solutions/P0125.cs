using System.Text;

namespace LeetcodeGrind.Solutions;

// 125. Valid Palindrome
public class P0125
{
    public bool IsPalindrome(string s)
    {
        s = s.ToLowerInvariant();
        var sb = new StringBuilder();
        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c))
            {
                sb.Append(c);
            }
        }

        string text = sb.ToString();
        string reverse = string.Join("", text.ToCharArray().Reverse());

        return text == reverse;
    }
}
