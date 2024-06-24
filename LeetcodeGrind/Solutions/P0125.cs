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

    public bool IsPalindrome2(string s)
    {
        s = s.ToLowerInvariant();
        var i = 0;
        var j = s.Length - 1;
        while (i < j)
        {
            if (!char.IsLetterOrDigit(s[i]))
            {
                i++;
            }
            else if (!char.IsLetterOrDigit(s[j]))
            {
                j--;
            }
            else if (s[i] != s[j])
            {
                return false;
            }
            else
            {
                i++;
                j--;
            }
        }

        return true;
    }

}
