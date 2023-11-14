using LeetcodeGrind.Common;
using System.Text;

namespace LeetcodeGrind.Solutions;

// 415. Add Strings
public class P0415
{
    public string AddStrings(string num1, string num2)
    {
        var i = num1.Length - 1;
        var j = num2.Length - 1;
        var carry = 0;
        var sb = new StringBuilder();

        while (i >= 0 || j >= 0)
        {
            var val1 = i >= 0
                ? num1[i] - '0'
                : 0;

            var val2 = j >= 0
                ? num2[j] - '0'
                : 0;

            var value = val1 + val2 + carry;

            sb.Append(value % 10);
            carry = value / 10;

            i--;
            j--;
        }

        if (carry > 0)
            sb.Append(carry);

        return string.Join("", sb.ToString().Reverse());
    }
}

