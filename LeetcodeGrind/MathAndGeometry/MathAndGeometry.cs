using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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


    // 65. Valid Number
    public bool IsNumber(string s)
    {
        if (string.IsNullOrEmpty(s))
            return false;

        s = s.ToLowerInvariant();
        if (s.Contains('e'))
        {
            var parts = s.Split('e');
            if (parts.Length > 2)
                return false;

            if (parts[0].Contains('.'))
                return IsValidFloat(parts[0]) && IsValidInteger(parts[1]);
            else if (parts[1].Contains('.'))
                return false;
            else
                return IsValidInteger(parts[0]) && IsValidInteger(parts[1]);
        }
        else if (s.Contains('.'))
        {
            return IsValidFloat(s);
        }
        else
        {
            return IsValidInteger(s);
        }
    }

    private static bool IsValidInteger(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return false;

        int numDigits = 0;
        int i = 0;

        if (s[0] == '-' || s[0] == '+')
            i++;

        while (i < s.Length)
        {
            if (char.IsDigit(s[i]))
                numDigits++;
            else
                return false;

            i++;
        }

        return numDigits > 0;
    }

    private static bool IsValidFloat(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return false;

        int numDigits = 0;
        int numDots = 0;
        int i = 0;

        if (s[0] == '-' || s[0] == '+')
            i++;

        while (i < s.Length)
        {
            if (char.IsDigit(s[i]))
                numDigits++;
            else if (s[i] == '.')
                numDots++;
            else
                return false;

            i++;
        }

        if (numDigits == 0 || numDots != 1)
            return false;

        return true;
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


    // 2427. Number of Common Factors
    public int CommonFactors(int a, int b)
    {
        var factors = new List<int>();
        int lesser = a < b ? a : b;
        var greater = a > b ? a : b;
        var start = greater / 2;

        for (int i = start; i > 1; i--)
        {
            if (greater % i == 0)
                factors.Add(i);
        }

        var count = 1; // for "1" itself
        foreach (var factor in factors)
        {
            if (factor <= lesser && lesser % factor == 0)
                count++;
        }

        if (a == b && a > 1)
            count++;

        return count;
    }


    // 2520. Count the Digits That Divide a Number
    public int CountDigits(int num)
    {
        var val = num;
        var count = 0;

        while (val > 0)
        {
            var digit = val % 10;
            val = val / 10;

            if (digit == 0)
                continue;

            if (num % digit == 0)
                count++;
        }
        return count;
    }


    // 149. Max Points on a Line
    public int MaxPoints(int[][] points)
    {
        if (points.Length <= 2)
            return points.Length;

        var lines = new Dictionary<(double, double), HashSet<(int, int)>>();
        var maxPoints = 2;

        for (int i = 0; i < points.Length - 1; i++)
        {
            var x1 = points[i][0];
            var y1 = points[i][1];

            for (int j = i + 1; j < points.Length; j++)
            {
                var x2 = points[j][0];
                var y2 = points[j][1];
                var dy = y2 - y1;
                var dx = (double)(x2 - x1);
                var slope = Math.Round(dy / dx, 5);

                var key = (x1 == x2)
                    ? (double.PositiveInfinity, x1)
                    : (slope, y1 - slope * x1);

                if (lines.TryGetValue(key, out var hs))
                {
                    hs.Add((x1, y1));
                    hs.Add((x2, y2));
                }
                else
                {
                    lines[key] = new HashSet<(int, int)>();
                    lines[key].Add((x1, y1));
                    lines[key].Add((x2, y2));
                }
                maxPoints = Math.Max(maxPoints, lines[key].Count);
            }
        }

        return maxPoints;
    }


    // 461. Hamming Distance
    public int HammingDistance(int x, int y)
    {
        var val = x ^ y;
        var hammingDistance = 0;
        while (val > 0)
        {
            if ((val & 1) == 1)
                hammingDistance++;
            val >>= 1;
        }
        return hammingDistance;
    }


    // 2525. Categorize Box According to Criteria
    public string CategorizeBox(int length, int width, int height, int mass)
    {
        var heavy = mass >= 100;

        var volume = ((long)width) * length * height;
        var bulky = width >= 10000 || 
                    height >= 10000 || 
                    length >= 10000 || 
                    volume >= 1_000_000_000;

        string cat;
        if (bulky && heavy)
            cat = "Both";
        else if (bulky)
            cat = "Bulky";
        else if (heavy)
            cat = "Heavy";
        else
            cat = "Neither";

        return cat;
    }


    // 1041. Robot Bounded In Circle
    public bool IsRobotBounded(string instructions)
    {
        var d = 'N';
        var x = 0;
        var y = 0;

        var DR = new Dictionary<char, char>();
        DR['N'] = 'E';
        DR['E'] = 'S';
        DR['S'] = 'W';
        DR['W'] = 'N';

        var DL = new Dictionary<char, char>();
        DL['N'] = 'W';
        DL['E'] = 'N';
        DL['S'] = 'E';
        DL['W'] = 'S';

        var radii = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            foreach (char c in instructions)
            {
                if (c == 'G')
                {
                    if (d == 'N')
                        y++;
                    else if (d == 'S')
                        y--;
                    else if (d == 'E')
                        x++;
                    else
                        x--;
                }
                else if (c == 'L')
                    d = DL[d];
                else //if (c == 'R')
                    d = DR[d];
            }
            if (x == 0 && y == 0)
                return true;

            radii.Add(x * x + y * y);
        }

        if (radii[^1] > radii[0])
            return false;

        return true;
    }
}
