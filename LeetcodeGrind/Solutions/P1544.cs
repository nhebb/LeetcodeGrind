using System.Text;

namespace LeetcodeGrind.Solutions;

// 1544. Make The String Great
public class P1544
{
    public string MakeGood(string s)
    {
        if (s.Length == 1)
            return s;

        var sb = new StringBuilder();
        var bad = true;

        while (bad)
        {
            bad = false;
            var i = 0;

            while (i < s.Length - 1)
            {
                if (Math.Abs(s[i] - s[i + 1]) == 32)
                {
                    i += 2;
                    bad = true;
                }
                else
                {
                    sb.Append(s[i]);
                    i++;

                }
                if (i == s.Length - 1)
                {
                    sb.Append(s[i]);
                }
            }
            s = sb.ToString();
            sb.Clear();

            if (s.Length == 1)
                break;
        }

        return s;
    }
}
