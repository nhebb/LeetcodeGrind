using System.Text;

namespace LeetcodeGrind.Solutions;

// 1545. Find Kth Bit in Nth Binary String
public class P1545
{
    public char FindKthBit(int n, int k)
    {
        var sb = new StringBuilder();
        sb.Append(0);

        for (int i = 1; i < n; i++)
        {
            var s = sb.ToString();
            sb.Append(1);

            var j = s.Length - 1;
            while (j >= 0)
            {
                sb.Append(s[j] == '1' ? 0 : 1);
                j--;
            }
        }

        return sb[k - 1];
    }
}
