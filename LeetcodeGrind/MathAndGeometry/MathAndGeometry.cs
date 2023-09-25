using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
        if (string.IsNullOrWhiteSpace(s))
            return 0;

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

        var val = numerals[s[^1]];
        var maxVal = val;
        var i = s.Length - 2;

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
    public int RomanToInt2(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;

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

        var val = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            var curVal = numerals[s[i]];
            var nextVal = numerals[s[i + 1]];

            if (curVal >= nextVal)
                val += curVal;
            else
                val -= curVal;
        }
        val += numerals[s[^1]];
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


    // 2455. Average Value of Even Numbers That Are Divisible by Three
    public int AverageValue(int[] nums)
    {
        var sum = 0;
        var count = 0;
        foreach (var num in nums)
        {
            if (num % 6 == 0)
            {
                sum += num;
                count++;
            }
        }

        return count == 0 ? 0 : sum / count;
    }


    // 2527. Find Xor-Beauty of Array
    public int XorBeauty(int[] nums)
    {
        // the trick is that you just XOR all the values
        var ans = 0;
        foreach (var num in nums)
            ans ^= num;
        return ans;
    }


    // 2443. Sum of Number and Its Reverse
    public bool SumOfNumberAndReverse(int num)
    {
        var half = num / 2;
        var num1 = num;

        int ReverseNum(int val)
        {
            var result = 0;
            while (val > 0)
            {
                result *= 10;
                result += val % 10;
                val /= 10;
            }

            return result;
        }

        while (num1 >= half)
        {
            var num2 = ReverseNum(num1);
            if (num1 + num2 == num)
                return true;

            num1--;
        }
        return false;
    }


    // 2544. Alternating Digit Sum
    public int AlternateDigitSum(int n)
    {
        var sum = 0;
        var s = n.ToString();
        for (int i = 0; i < s.Length; i++)
        {
            var val = s[i] - '0';
            if (i % 2 == 0)
                sum += val;
            else
                sum -= val;
        }
        return sum;
    }


    // 171. Excel Sheet Column Number
    public int TitleToNumber(string columnTitle)
    {
        var number = 0;
        var pow = 1;
        for (int i = columnTitle.Length - 1; i >= 0; i--)
        {
            number += (columnTitle[i] - 'A' + 1) * pow;
            pow *= 26;
        }

        return number;
    }


    //172. Factorial Trailing Zeroes
    public int TrailingZeroes(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n / 5;
            n /= 5;
        }
        return count;
    }


    // 204. Count Primes
    public int CountPrimes(int n)
    {
        // Sieve of Eratosthenes
        if (n <= 2) return n;
        var count = 0;
        var nonprimes = new bool[n];

        for (int i = 2; i < n; i++)
        {
            if (nonprimes[i])
                continue;

            count++;

            var factor = 2;
            while (i * factor < n)
            {
                nonprimes[i * factor] = true;
                factor++;
            }
        }

        return count;
    }


    // 1266. Minimum Time Visiting All Points
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        var time = 0;
        for (int i = 0; i < points.Length - 1; i++)
        {
            var dx = Math.Abs(points[i + 1][0] - points[i][0]);
            var dy = Math.Abs(points[i + 1][1] - points[i][1]);
            time += dx > dy ? dx : dy;
        }
        return time;
    }


    // 292. Nim Game
    public bool CanWinNim(int n)
    {
        // Explanation: If there are 4 remaining sticks,
        // no matter how many you choose, the opponent
        // can always pick up the remainder and win.
        // If tyou follow the pattern out, any multiple
        // of 4 lets the opponent choose a number that
        // leaves you with another multiple of 4.
        return n % 4 != 0;
    }


    // 728. Self Dividing Numbers
    public IList<int> SelfDividingNumbers(int left, int right)
    {
        bool IsSelfDividing(int n)
        {
            var val = n;
            while (n > 0)
            {
                var digit = n % 10;
                if (digit == 0)
                    return false;

                if (val % digit != 0)
                    return false;

                n /= 10;
            }
            return true;
        }

        var res = new List<int>();
        while (left <= right)
        {
            if (IsSelfDividing(left))
                res.Add(left);
            left++;
        }

        return res;
    }


    // 1979. Find Greatest Common Divisor of Array
    public int FindGCD(int[] nums)
    {
        var min = int.MaxValue;
        var max = int.MinValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < min)
                min = nums[i];
            else if (nums[i] > max)
                max = nums[i];
        }

        // Euclid's Algorithm
        while (max % min > 0)
        {
            var rem = max % min;
            max = min;
            min = rem;
        }
        return min;
    }


    // 507. Perfect Number
    public bool CheckPerfectNumber(int num)
    {
        var divisors = new List<int>();
        divisors.Add(1);

        var n = num / 2;

        for (int i = 2; i <= n; i++)
        {
            if (num % i == 0)
            {
                divisors.Add(i);
            }
        }

        return divisors.Sum() == num;
    }


    // 2571. Minimum Operations to Reduce an Integer to 0
    public int MinOperations(int n)
    {
        int GetMostSignificantBit(int n)
        {
            if (n == 0)
                return 0;

            int msb = 0;
            n /= 2;

            while (n != 0)
            {
                n /= 2;
                msb++;
            }

            return (1 << msb);
        }

        int GetHammingWeight(int n)
        {
            var binary = Convert.ToString(n, 2);
            return binary.Count(c => c == '1');
        }

        var val1 = GetHammingWeight((GetMostSignificantBit(n) * 2)) + 1;
        var val2 = GetHammingWeight(n);

        return Math.Min(val1, val2);
    }


    // 2575. Find the Divisibility Array of a String
    public int[] DivisibilityArray(string word, int m)
    {
        var res = new int[word.Length];
        var prefix = 0;
        for (int i = 0; i < word.Length; i++)
        {
            prefix = (10 * prefix) % m + (word[i] - '0') % m;
            if (prefix % m == 0)
                res[i] = 1;
        }

        return res;
    }


    // TODO: 279. Perfect Squares
    public int NumSquares(int n)
    {
        var squares = new List<int>();
        var i = 1;

        while (i * i <= n)
        {
            squares.Add(i * i);
            i++;
        }

        var ans = new List<int>();

        return ans.Count;
    }


    // 191. Number of 1 Bits
    public int HammingWeight(uint n)
    {
        //int count = 0;
        //while (n > 0)
        //{
        //    if ((n & 1) == 1) { count++; }
        //    n >>= 1;
        //}
        //return count;

        return System.Numerics.BitOperations.PopCount(n);
    }


    // 389. Find the Difference
    public char FindTheDifference(string s, string t)
    {
        var num = 0;

        for (int i = 0; i < s.Length; i++)
            num ^= s[i] ^ t[i];

        return (char)(num ^ t[^1]);
    }
}
