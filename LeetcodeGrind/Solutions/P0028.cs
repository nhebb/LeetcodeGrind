namespace LeetcodeGrind.Solutions;

// 28. Find the Index of the First Occurrence in a String
public class P0028
{
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle))
            return 0;

        if (needle.Length > haystack.Length)
            return -1;

        if (haystack.Length == needle.Length)
            return haystack == needle ? 0 : -1;


        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if (haystack[i] == needle[0])
            {
                bool match = true;
                for (int j = i, k = 0; k < needle.Length; j++, k++)
                {
                    if (haystack[j] != needle[k])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                    return i;
            }
        }

        return -1;
    }
}
