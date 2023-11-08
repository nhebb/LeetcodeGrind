namespace LeetcodeGrind.Solutions;

// 680. Valid Palindrome II
public class P0680
{
    public bool ValidPalindrome(string s)
    {
        if (s.Length <= 2) return true;
        if (s == string.Join("", s.Reverse())) return true;

        bool IsValidRecurse(int i, int j, int skipCount)
        {
            while (i < j)
            {
                if (s[i] != s[j])
                {
                    skipCount++;
                    if (skipCount > 1)
                        return false;

                    if (s[i] == s[j - 1] && s[i + 1] == s[j])
                        return IsValidRecurse(i + 1, j, skipCount)
                            || IsValidRecurse(i, j - 1, skipCount);
                    else if (s[i] == s[j - 1])
                        j--;
                    else if (s[i + 1] == s[j])
                        i++;
                    else
                        return false;
                }
                i++;
                j--;
            }
            return true;
        }

        return IsValidRecurse(0, s.Length - 1, 0);
    }
}
