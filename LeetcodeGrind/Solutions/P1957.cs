using System.Text;

namespace LeetcodeGrind.Solutions;

// 1957. Delete Characters to Make Fancy String
public class P1957
{
    public string MakeFancyString(string s)
    {
        if (s.Length < 3)
        {
            return s;
        }

        var sb = new StringBuilder();
        sb.Append(s[0]);
        sb.Append(s[1]);
        var first = s[0];
        var second = s[1];

        var i = 2;
        while (i < s.Length)
        {
            if (s[i] != first || s[i] != second)
            {
                sb.Append(s[i]);
                first = second;
                second = s[i];
            }
            i++;
        }

        return sb.ToString();
    }
}
