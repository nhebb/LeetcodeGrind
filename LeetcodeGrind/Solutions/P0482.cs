using System.Text;

namespace LeetcodeGrind.Solutions;

// 482. License Key Formatting
public class P0482
{
    public string LicenseKeyFormatting(string s, int k)
    {
        s = s.Replace("-", "").ToUpper();
        var firstLen = s.Length % k;

        var sb = new StringBuilder();
        sb.Append(s[0..firstLen]);

        var i = firstLen;
        while (i < s.Length)
        {
            if (i > 0)
                sb.Append('-');

            for (int j = i; j < i + k; j++)
            {
                sb.Append(s[j]);
            }
            i += k;
        }
        return sb.ToString();
    }
}
