using System.Text;

namespace LeetcodeGrind.Solutions;

// 2864. Maximum Odd Binary Number
public class P2864
{
    public string MaximumOddBinaryNumber(string s)
    {
        var ones = 0;
        var zeros = 0;
        foreach (var c in s)
        {
            if(c == '1')
                ones++;
            else 
                zeros++;
        }

        var sb = new StringBuilder();
        while (ones > 1)
        {
            sb.Append('1');
            ones--;
        }
        while (zeros > 0)
        {
            sb.Append('0');
            zeros--;
        }

        sb.Append('1');

        return sb.ToString();
    }
}
