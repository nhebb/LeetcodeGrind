namespace LeetcodeGrind.Solutions;

// 1332. Remove Palindromic Subsequences
public class P1332
{
    public int RemovePalindromeSub(string s)
    {
        // If s is a palindrome, return 1. Otherwise,
        // since this string only contains 'a' or 'b'
        // and you have to remove subsequences --
        // not subarrays -- then you can remove all of
        // the a's in one step then b's in the next.

        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            if (s[i] != s[j])
            {
                return 2;
            }
            i++;
            j--;
        }

        return 1;
    }
}
