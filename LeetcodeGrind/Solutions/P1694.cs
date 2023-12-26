using System.Text;

namespace LeetcodeGrind.Solutions;

// 1694. Reformat Phone Number
public class P1694
{
    public string ReformatNumber(string number)
    {
        var s = number.Replace(" ", "").Replace("-", "");

        var remainder = s.Length % 3;

        var block = 0;
        if (remainder == 0)
            block = 3;
        else if (remainder == 1)
            block = 4;
        else
            block = 2;

        var sb = new StringBuilder();
        var i = 0;
        while (i < s.Length - block)
        {
            for (int j = 0; j < 3; j++)
            {
                sb.Append(s[i + j]);
            }
            sb.Append('-');

            i += 3;
        }

        if (block == 2)
            sb.Append(s[^2]).Append(s[^1]);
        else if (block == 3)
            sb.Append(s[^3]).Append(s[^2]).Append(s[^1]);
        else if (block == 4)
            sb.Append(s[^4]).Append(s[^3]).Append('-').Append(s[^2]).Append(s[^1]);

        return sb.ToString();
    }
}
