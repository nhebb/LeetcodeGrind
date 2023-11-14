using System.Text;

namespace LeetcodeGrind.Solutions;

// 541. Reverse String II
public class P0541
{
    public string ReverseStr(string s, int k)
    {
        var sb = new StringBuilder(s.Length);
        var skip = 0;
        var taken = 0;

        while (taken < s.Length)
        {
            var strk = s.Skip(skip * 2 * k).Take(k);
            sb.Append(string.Join("", strk.Reverse()));
            sb.Append(string.Join("", s.Skip(skip * 2 * k + k).Take(k)));
            taken += 2 * k;
            skip++;
        }

        return sb.ToString();
    }
}
