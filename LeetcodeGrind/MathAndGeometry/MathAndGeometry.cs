using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.MathAndGeometry;

public class MathAndGeometry
{
    // 7. Reverse Integer
    public int Reverse(int x)
    {
        double val = x % 10;

        while (Math.Abs(x / 10) > 0)
        {
            x /= 10;
            val = (val * 10) + (x % 10);
        }

        if (val < int.MinValue
            || val > int.MaxValue)
        {
            return 0;
        }
        return (int)val;
    }


    // 12. Integer to Roman
    public string IntToRoman(int num)
    {
        var thousands = new string[] { "", "M", "MM", "MMM" };
        var hundreds = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        var tens = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        var ones = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        var sb = new StringBuilder();

        sb.Append(thousands[num / 1000]);

        num %= 1000;
        sb.Append(hundreds[num / 100]);

        num %= 100;
        sb.Append(tens[num / 10]);

        num %= 10;
        sb.Append(ones[num]);

        return sb.ToString();
    }


    // 13. Roman to Integer
    public int RomanToInt(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) { return 0; }

        var numerals = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

        var i = s.Length - 1;
        var val = numerals[s[i]];
        var maxVal = val;

        i--;

        while (i >= 0)
        {
            var numeralValue = numerals[s[i]];
            maxVal = Math.Max(maxVal, numeralValue);

            if (numeralValue >= maxVal)
                val += numeralValue;
            else
                val -= numeralValue;

            i--;
        }

        return val;
    }


    // 43. Multiply Strings
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
        {
            return "0";
        }
        var answer = new int[num1.Length + num2.Length];
        Array.Fill(answer, 0);

        var onesPlace = answer.Length - 1;

        for (int i = num1.Length - 1; i >= 0; i--)
        {
            var k = onesPlace;
            var factor1 = num1[i] - '0';

            for (int j = num2.Length - 1; j >= 0; j--)
            {
                answer[k] += (num1[i] - '0') * (num2[j] - '0');
                if (answer[k] >= 10)
                {
                    answer[k - 1] += (answer[k] / 10);
                    answer[k] %= 10;
                }
                k--;
            }
            onesPlace--;
        }

        for (int i = answer.Length - 1; i >= 0; i--)
        {
            int carry = 0;
            if (answer[i] >= 10)
            {
                carry = answer[i] / 10;
                answer[i] %= 10;
                answer[i - 1] += carry;
            }
        }

        var result = String.Join("", answer);

        // skip leading 0's
        int x = 0;
        while (result[x] == '0')
            x++;

        return result[x..];
    }


    // 50. Pow(x, n)
    public double MyPow(double x, int n)
    {
        if (n == 0) return 1.0;
        if (x == 1.0) return x;

        if (x == -1.0)
            return (n % 2 == 0) ? 1.0 : -1.0;

        bool neg = false;
        if (n < 0)
        {
            neg = true;
            n *= -1;
        }

        if (n == int.MinValue)
            return 0.0;

        double result = 1.0;
        for (int i = 0; i < n; i++)
        {
            result *= x;
        }

        return neg ? 1 / result : result;
    }


    // 1037. Valid Boomerang
    public bool IsBoomerang(int[][] points)
    {
        if ((points[0][0] == points[1][0] && points[0][1] == points[1][1]) ||
            points[0][0] == points[2][0] && points[0][1] == points[2][1] ||
            points[2][0] == points[1][0] && points[2][1] == points[1][1] ||
            points[0][0] == points[1][0] && points[1][0] == points[2][0] ||
            points[0][1] == points[1][1] && points[1][1] == points[2][1])
        {
            return false;
        }

        var slope1 = (points[1][1] - points[0][1]) / ((double)(points[1][0] - points[0][0]));
        var slope2 = (points[2][1] - points[1][1]) / ((double)(points[2][0] - points[1][0]));

        return Math.Abs(slope1 - slope2) > double.Epsilon;
    }


    // 2028. Find Missing Observations
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        // (rolls.Sum() + missing.Sum()) / (m + n) = mean
        // missing.Sum() = mean * (m + n) - rolls.Sum()
        var missingTotal = mean * (rolls.Length + n) - rolls.Sum();
        var ans = new int[n];
        Array.Fill(ans, 1);
        missingTotal -= n;

        while (missingTotal > 0)
        {
            for (int i = 0; i < n && missingTotal > 0; i++)
            {
                ans[i]++;
                missingTotal--;
            }
        }

        var impossible = ans.Any(x => x > 6) ||
                         (rolls.Sum() + ans.Sum()) / ((double)(rolls.Length + n)) > mean;
        if (impossible)
            return Array.Empty<int>();
        return ans;
    }
}
