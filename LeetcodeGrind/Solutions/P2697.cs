namespace LeetcodeGrind.Solutions;

// 2697. Lexicographically Smallest Palindrome
public class P2697
{
    public string MakeSmallestPalindrome(string s)
    {
        var chars = s.ToCharArray();

        var i = 0;
        var j = chars.Length - 1;

        while (i < j)
        {
            if (chars[i] != chars[j])
            {
                if (chars[i] < chars[j])
                {
                    chars[j] = chars[i];
                }
                else
                {
                    chars[i] = chars[j];
                }
            }
            i++;
            j--;
        }

        return new string(chars);
    }
}
