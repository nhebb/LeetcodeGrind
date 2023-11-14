using System.Text;

namespace LeetcodeGrind.Solutions;

// 1309. Decrypt String from Alphabet to Integer Mapping
public class P1309
{
    public string FreqAlphabets(string s)
    {
        int val = 0;
        var sb = new StringBuilder();

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '#')
            {
                val = 10 * (s[i - 2] - '0') + (s[i - 1] - '0');
                i -= 2;
            }
            else
            {
                val = s[i] - '0';
            }

            sb.Append((char)('a' + val - 1));
        }

        return string.Join("", sb.ToString().Reverse());
    }
}
