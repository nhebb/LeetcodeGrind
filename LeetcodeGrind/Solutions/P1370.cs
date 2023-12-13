using System.Text;

namespace LeetcodeGrind.Solutions;

// 1370. Increasing Decreasing String
public class P1370
{
    public string SortString(string s)
    {
        var chars = s.ToCharArray();
        Array.Sort(chars);

        var sb = new StringBuilder();
        var taken = new bool[chars.Length];

        while (sb.Length < s.Length)
        {
            // Increasing traversal
            int i = 0;
            var lastChar = ' ';

            while (i < chars.Length)
            {
                if (!taken[i] && chars[i] != lastChar)
                {
                    taken[i] = true;
                    sb.Append(chars[i]);
                    lastChar = chars[i];
                }
                i++;
            }

            // Decreasing traversal;
            i = chars.Length - 1;
            lastChar = ' ';

            while (i >= 0)
            {
                if (!taken[i] && chars[i] != lastChar)
                {
                    taken[i] = true;
                    sb.Append(chars[i]);
                    lastChar = chars[i];
                }
                i--;
            }
        }

        return sb.ToString();
    }
}
