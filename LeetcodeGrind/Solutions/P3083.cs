using System.Runtime.ExceptionServices;

namespace LeetcodeGrind.Solutions;

// 3083. Existence of a Substring in a String and Its Reverse
public class P3083
{
    public bool IsSubstringPresent(string s)
    {
        var hs = new HashSet<string>();

        for (int i = 0; i < s.Length - 1; i++)
        {
            hs.Add(s.Substring(i, 2));
        }

        var rev = string.Join("", s.Reverse());
        for (int i = 0; i < rev.Length - 1; i++)
        {
            if (hs.Contains(rev.Substring(i, 2)))
            {
                return true;
            }
        }

        return false;
    }
}
