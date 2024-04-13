using System.Text;

namespace LeetcodeGrind.Solutions;

// 402. Remove K Digits
public class P0402
{
    public string RemoveKdigits(string num, int k)
    {
        if (k == num.Length)
            return "0";

        var nonZeros = num.Count(x => x != '0');
        if (nonZeros <= k)
            return "0";

        var sb = new StringBuilder();
        sb.Append(num[0]);

        for (int i = 1; i < num.Length; i++)
        {
            if (k == 0 || sb.Length == 0 || num[i] >= sb[^1])
            {
                sb.Append(num[i]);
            }
            else if (num[i] < sb[^1])
            {
                sb.Length--;
                k--;
                i--;

                if (i == num.Length)
                {
                    sb.Append(num[i]);
                }
            }
        }

        while (k > 0 && sb.Length > 0)
        {
            sb.Length--;
            k--;
        }

        var result = TrimLeadingZeros(sb.ToString());
        return result;
    }

    private string TrimLeadingZeros(string s)
    {
        var i = 0;
        while (i < s.Length && s[i] == '0')
        {
            i++;
        }
        var trimmed = s.Substring(i);
        if (trimmed.Length == 0)
            return "0";
        return trimmed;
    }
}
