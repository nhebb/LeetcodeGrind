namespace LeetcodeGrind.Solutions;

// 647. Palindromic Substrings
public class P0647
{
    public int CountSubstrings(string s)
    {
        int count = s.Length;
        for (int i = 0; i < s.Length - 1; i++)
        {
            int j = i + 1;
            while (j < s.Length)
            {
                if (IsPalidromicSubstring(s.Substring(i, j - i + 1)))
                    count++;

                j++;
            }
        }
        return count;

    }

    private bool IsPalidromicSubstring(string s)
    {
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            if (s[i] != s[j])
                return false;
            i++;
            j--;
        }
        return true;
    }
}
