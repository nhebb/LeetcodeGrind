namespace LeetcodeGrind.Solutions;

// 2108. Find First Palindromic String in the Array
public class P2108
{
    public string FirstPalindrome(string[] words)
    {
        bool IsPalindrome(string s)
        {
            var i = 0;
            var j = s.Length - 1;
            while (i <= j)
            {
                if (s[i] != s[j])
                    return false;

                i++;
                j--;
            }
            return true;
        }

        foreach (var word in words)
        {
            if (IsPalindrome(word))
                return word;
        }

        return "";
    }
}
