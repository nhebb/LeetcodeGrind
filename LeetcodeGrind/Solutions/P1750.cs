namespace LeetcodeGrind.Solutions;

// 1750. Minimum Length of String After Deleting Similar Ends
public class P1750
{
    public int MinimumLength(string s)
    {
        var i = 0;
        var j = s.Length - 1;

        while (i < j && s[i] == s[j])
        {
            if (j == i + 1 && s[i] == s[j])
                return 0;

            while (i + 1 < j && s[i] == s[i + 1])
                i++;

            while (j - 1 > i && s[j] == s[j - 1])
                j--;

            i++;
            j--;
        }

        return j - i + 1;
    }
}
