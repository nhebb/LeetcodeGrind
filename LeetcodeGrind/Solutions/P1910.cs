namespace LeetcodeGrind.Solutions;

// 1910. Remove All Occurrences of a Substring
public class P1910
{
    public string RemoveOccurrences(string s, string part)
    {
        var index = s.IndexOf(part);
        while (index >= 0)
        {
            if (index == 0)
            {
                s = s.Substring(part.Length);
            }
            else
            {
                s = s.Substring(0, index) + s.Substring(index + part.Length);
            }

            index = s.Length > 0
                ? s.IndexOf(part)
                : -1;
        }

        return s;
    }
}
