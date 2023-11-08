namespace LeetcodeGrind.Solutions;

// 14. Longest Common Prefix
public class P0014
{
    public string LongestCommonPrefix(string[] strs)
    {
        var maxLength = strs?.Min(s => s.Length) ?? 0;
        if (maxLength == 0)
            return "";

        var longest = "";
        int i = 1;
        bool noMatch = false;

        while (i <= maxLength)
        {
            var testPrefix = strs[0][..i];

            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j][..i] != testPrefix)
                {
                    noMatch = true;
                    break;
                }
            }

            if (noMatch)
                break;

            longest = testPrefix;
            i++;
        }

        return longest;
    }
}
