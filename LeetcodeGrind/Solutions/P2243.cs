using System.Text;

namespace LeetcodeGrind.Solutions;

// 2243. Calculate Digit Sum of a String

public class P2243
{
    public string DigitSum(string s, int k)
    {
        if (s.Length <= k)
        {
            return s;
        }

        var sb = new StringBuilder();
        var done = false;

        while (!done)
        {
            var skip = 0;
            while (skip < s.Length)
            {
                var digits = s.Skip(skip).Take(k);
                var sum = 0;
                foreach (var digit in digits)
                {
                    sum += digit - '0';
                }
                sb.Append(sum.ToString());

                skip += k;
            }

            s = sb.ToString();
            sb.Clear();

            if (s.Length <= k)
            {
                done = true;
            }
        }

        return s;
    }
}
