using System.Text;

namespace LeetcodeGrind.Solutions;

// 1009. Complement of Base 10 Integer
public class P1009
{
    public int BitwiseComplement(int n)
    {
        var s = Convert.ToString(n, 2);
        var sb = new StringBuilder();

        foreach (var c in s)
        {
            sb.Append(c == '1' ? '0' : '1');
        }

        return Convert.ToInt32(sb.ToString(), 2);
    }
}
