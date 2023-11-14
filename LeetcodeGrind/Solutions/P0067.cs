namespace LeetcodeGrind.Solutions;

// 67. Add Binary
public class P0067
{
    public string AddBinary(string a, string b)
    {
        var delta = a.Length - b.Length;
        if (delta > 0)
            b = new string('0', delta) + b;
        else if (delta < 0)
            a = new string('0', -delta) + a;

        var carry = 0;
        var result = "";

        for (int i = a.Length - 1; i >= 0; i--)
        {
            int calc = (a[i] - '0') + (b[i] - '0') + carry;
            var digit = calc % 2;
            result = digit.ToString() + result;
            carry = calc / 2;
        }

        if (carry == 1)
            result = "1" + result;

        return result;
    }
}
