namespace LeetcodeGrind.Solutions;

// 5. Longest Palindromic Substring
public class P0005
{
    public string LongestPalindrome(string s)
    {
        var maxLen = 1;
        var longestPalindrome = s[0].ToString();

        for (int i = 0; i < s.Length - 1; i++)
        {
            // odd length substrings
            for (int j = i - 1, k = i + 1; j >= 0 && k < s.Length; j--, k++)
            {
                if (s[j] != s[k])
                    break;

                var curLen = k - j + 1;
                if (curLen > maxLen)
                {
                    maxLen = curLen;
                    longestPalindrome = s.Substring(j, curLen);
                }
            }
            // even length substrings
            for (int j = i, k = i + 1; j >= 0 && k < s.Length; j--, k++)
            {
                if (s[j] != s[k])
                    break;

                var curLen = k - j + 1;
                if (curLen > maxLen)
                {
                    maxLen = curLen;
                    longestPalindrome = s.Substring(j, curLen);
                }
            }
        }

        return longestPalindrome;
    }


    // older implementation
    public string LongestPalindrome2(string s)
    {
        var oddSubString = GetLongestOddSubstring(s);
        var evenSubString = GetLongestEvenSubstring(s);
        return oddSubString.Length >= evenSubString.Length
            ? oddSubString
            : evenSubString;
    }

    private string GetLongestEvenSubstring(string s)
    {
        var substr = "";
        var len = 0;
        for (int i = 0; i + 1 < s.Length; i++)
        {
            var offset = 0;
            while (i - offset >= 0 && i + 1 + offset < s.Length)
            {
                if (s[i - offset] == s[i + 1 + offset])
                {
                    var numchars = 2 * offset + 2;
                    if (numchars > len)
                    {
                        len = numchars;
                        substr = s.Substring(i - offset, numchars);
                    }
                }
                else
                {
                    break;
                }
                offset++;
            }
        }

        return substr;
    }
    private string GetLongestOddSubstring(string s)
    {
        var substr = "";
        var len = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var offset = 0;
            while (i - offset >= 0 && i + offset < s.Length)
            {
                if (s[i - offset] == s[i + offset])
                {
                    var numchars = 2 * offset + 1;
                    if (numchars > len)
                    {
                        len = numchars;
                        substr = s.Substring(i - offset, numchars);
                    }
                }
                else
                {
                    break;
                }
                offset++;
            }
        }

        return substr;
    }
}
