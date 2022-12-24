using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Strings;

public class Strings
{
    // 6. Zigzag Conversion
    public string Convert(string s, int numRows)
    {
        if (numRows == 1 || string.IsNullOrWhiteSpace(s))
            return s;

        var sb = new StringBuilder();
        var len = s.Length;
        var offset = 2 * numRows - 2;

        for (int i = 0; i < numRows; i++)
        {
            if (i == 0 || i == numRows - 1)
            {
                // top and bottom characters (offset = 2n-2)
                for (int j = i; j < len; j += offset)
                    sb.Append(s[j]);
            }
            else
            {
                // diagonal characters (dynamic offset)
                int j = i;
                bool down = true;
                int downOffset = 2 * (numRows - 1 - i);
                int upOffset = offset - downOffset;
                while (j < len)
                {
                    sb.Append(s[j]);
                    if (down)
                        j += downOffset;
                    else
                        j += upOffset;
                    down = !down;
                }
            }
        }
        return sb.ToString();
    }


    // 8. String to Integer (atoi)
    public int MyAtoi(string str)
    {
        if (string.IsNullOrWhiteSpace(str)) { return 0; }

        str = str.TrimStart();

        var i = 0;
        bool neg = false;
        if (str[i] == '-')
        {
            neg = true;
            i++;
        }
        else if (str[i] == '+')
        {
            i++;
        }

        if (i >= str.Length || !char.IsDigit(str[i])) 
            return 0;

        double num = (double)(str[i] - '0');
        i++;

        while (i < str.Length && char.IsDigit(str[i]))
        {
            num = (num * 10) + (str[i] - '0');
            i++;
        }

        if (neg)
        {
            num *= -1;
            return num < int.MinValue 
                ? int.MinValue 
                : (int)num;
        }

        return num > int.MaxValue 
            ? int.MaxValue 
            : (int)num;
    }


    // 9. Palindrome Number
    public bool IsPalindrome(int x)
    {
        var input = x.ToString();
        int i = 0;
        int j = input.Length - 1;
        while (i < j)
        {
            if (input[i] != input[j]) 
                return false;
            i++;
            j--;
        }
        return true;
    }


    // 10. Regular Expression Matching
    public bool IsMatch(string s, string p)
    {
        // lol
        return System.Text.RegularExpressions.Regex.IsMatch(s, $"^{p}$");
    }


    // 22. Generate Parentheses
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        var parens = "";

        void RecurseParens(string parens, int left, int right)
        {
            if (left == right && right == n)
            {
                result.Add(parens);
                return;
            }

            if (left < n)
            {
                RecurseParens(parens + "(", left + 1, right);
            }

            if (right < left)
            {
                RecurseParens(parens + ")", left, right + 1);
            }
        }

        RecurseParens(parens, 0, 0);
        return result;
    }


    // 38. Count and Say
    public string CountAndSay(int n)
    {
        var s = "1";
        var sb = new StringBuilder();

        for (int i = 2; i <= n; i++)
        {
            var j = 0;
            while (j < s.Length)
            {
                var val = s[j] - '0';
                var count = 1;
                while (j < s.Length - 1 && s[j + 1] == s[j])
                {
                    count++;
                    j++;
                }
                sb.Append(count).Append(val);
                j++;
            }
            s = sb.ToString();
            sb.Clear();
        }
        return s;
    }


    // 58. Length of Last Word
    public int LengthOfLastWord(string s)
    {
        var length = 0;
        var instring = false;
        var count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                if (instring)
                {
                    instring = false;
                    length = count;
                    count = 0;
                }
                continue;
            }
            instring = true;
            count++;
        }
        if (count > 0) length = count;

        return length;
    }


    // 1221. Split a String in Balanced Strings
    public int BalancedStringSplit(string s)
    {
        var count = 0;
        var sum = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'L')
                sum--;
            else
                sum++;

            if (sum == 0)
                count++;
        }
        return count;
    }
}
