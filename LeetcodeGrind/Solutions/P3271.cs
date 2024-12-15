using System.Text;

namespace LeetcodeGrind.Solutions;

// 3271. Hash Divided String
public class P3271
{
    public string StringHash(string s, int k)
    {
        var sb = new StringBuilder();
        var i = 0;

        while (i < s.Length)
        {
            var sum = 0;
            for (int j = 0; j < k; j++)
            {
                sum += s[i + j] - 'a';
            }
            sb.Append((char)('a' + (sum % 26)));
            i += k;
        }

        return sb.ToString();
    }
}
