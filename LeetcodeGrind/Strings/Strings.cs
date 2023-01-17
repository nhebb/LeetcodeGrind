using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
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


    // 859. Buddy Strings
    public bool BuddyStrings(string s, string goal)
    {
        if (s.Length == 1 || s.Length != goal.Length)
            return false;

        var misMatches = new List<int>();
        for (int i = 0; i < s.Length; i++)
            if (s[i] != goal[i])
                misMatches.Add(i);

        // edge case where we have to find any repeated character
        if (misMatches.Count == 0)
        {
            var arr = new int[26];
            foreach (var c in s)
            {
                arr[c - 'a']++;
                if (arr[c - 'a'] > 1)
                    return true;
            }
            return false;
        }

        if (misMatches.Count != 2)
            return false;

        if (s[misMatches[0]] != goal[misMatches[1]] ||
            s[misMatches[1]] != goal[misMatches[0]])
            return false;

        return true;
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


    // 2423. Remove Letter To Equalize Frequency
    public bool EqualFrequency(string word)
    {
        // count the frequency of each letter
        var arr = new int[26];
        foreach (char c in word)
            arr[c - 'a']++;

        // group the letters by frequency
        var freq = new Dictionary<int, List<char>>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 0)
                continue;

            char letter = (char)(i + 'a');
            if (freq.TryGetValue(arr[i], out var list))
                list.Add(letter);
            else
                freq[arr[i]] = new List<char>() { letter };
        }

        // If there are more than 2 frequency groups,
        // you can't remove just one index to achieve
        // frequency
        if (freq.Count > 2)
            return false;

        var min = freq.Keys.Min();
        var max = freq.Keys.Max();

        // all letters are the same
        if (freq.Count == 1 && freq[min].Count == 1)
            return true;

        // A single letter that appears only once
        if (min == 1 && freq[min].Count == 1)
            return true;

        // all letters appear only once
        if (min == 1 && max == 1)
            return true;

        // one letter appears one more time than the rest
        if (max - min == 1 && freq[max].Count == 1)
            return true;

        return false;
    }


    // 500. Keyboard Row
    public string[] FindWords(string[] words)
    {
        var row1 = "qwertyuiop".ToCharArray();
        var row2 = "asdfghjkl".ToCharArray();
        var row3 = "zxcvbnm".ToCharArray();

        return words.Where(w => w.ToLower().Except(row1).Count() == 0 ||
                                w.ToLower().Except(row2).Count() == 0 ||
                                w.ToLower().Except(row3).Count() == 0)
                    .ToArray();
    }


    // 2047. Number of Valid Words in a Sentence
    public int CountValidWords(string sentence)
    {
        var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var count = 0;

        foreach (var w in words)
        {
            bool valid = true;
            var hyphens = 0;
            var punctuation = 0;

            for (int i = 0; i < w.Length; i++)
            {
                if (char.IsDigit(w[i]))
                {
                    valid = false;
                    break;
                }
                else if (w[i] == '-')
                {
                    hyphens++;
                    if (hyphens > 1 | i == 0 || i == w.Length - 1
                        || !char.IsLetter(w[i - 1]) || !char.IsLetter(w[i + 1]))
                    {
                        valid = false;
                        break;
                    }
                }
                else if (w[i] == '.' || w[i] == ',' || w[i] == '!')
                {
                    punctuation++;
                    if (punctuation > 1 || i != w.Length - 1)
                    {
                        valid = false;
                        break;
                    }
                }
                else if (!char.IsLetter(w[i]))
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
            {
                count++;
            }
        }

        return count;
    }


    // 2000. Reverse Prefix of Word
    public string ReversePrefix(string word, char ch)
    {
        var j = word.IndexOf(ch);
        if (j < 0)
            return word;

        var chars = word.ToCharArray();
        int i = 0;
        while (i < j)
        {
            (chars[i], chars[j]) = (chars[j], chars[i]);
            i++;
            j--;
        }
        return new string(chars);
    }


    //1941. Check if All Characters Have Equal Number of Occurrences
    public bool AreOccurrencesEqual(string s)
    {
        var d = new Dictionary<char, int>();
        foreach (char c in s)
            if (!d.TryAdd(c, 1))
                d[c]++;

        var count = d[s[0]];
        foreach (var kvp in d)
            if (kvp.Value != count)
                return false;

        return true;
    }


    // 2351. First Letter to Appear Twice
    public char RepeatedCharacter(string s)
    {
        var hs = new HashSet<char>();
        char result = ' ';
        foreach (var c in s)
        {
            if (!hs.Add(c))
            {
                result = c;
                break;
            }
        }
        return result;
    }


    // 2437. Number of Valid Clock Times
    public int CountTime(string time)
    {
        var ans = 1;
        if (time[0] == '?' && time[1] == '?')
        {
            ans *= 24;
        }
        else
        {
            if (time[0] == '?')
            {
                if (time[1] - '0' <= 3)
                    ans *= 3;
                else
                    ans *= 2;
            }
            if (time[1] == '?')
            {
                if (time[0] == '2')
                    ans *= 4;
                else
                    ans *= 10;
            }
        }
        if (time[3] == '?')
            ans *= 6;
        if (time[4] == '?')
            ans *= 10;

        return ans;
    }


    // 1061. Lexicographically Smallest Equivalent String
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        var parent = new int[26];
        for (int i = 0; i < parent.Length; i++)
            parent[i] = i;

        int Find(int x)
        {
            while (x != parent[x])
                x = parent[x];
            return x;
        }

        void Union(char x, char y)
        {
            var lower = Find(x - 'a');
            var higher = Find(y - 'a');
            if (lower > higher)
                (lower, higher) = (higher, lower);
            parent[higher] = lower;
        }

        for (int i = 0; i < s1.Length; i++)
            Union(s1[i], s2[i]);

        var sb = new StringBuilder();
        for (int i = 0; i < baseStr.Length; i++)
            sb.Append((char)('a' + Find(baseStr[i] - 'a')));

        return sb.ToString();
    }


    // 949. Largest Time for Given Digits
    public string LargestTimeFromDigits(int[] arr)
    {
        if (arr.Min() >= 3) return "";

        var time = new List<int>();
        var chosen = new bool[4];
        var maxHrs = 0;
        var maxMins = 0;

        void Backtrack()
        {
            for (int i = 0; i < 4; i++)
            {
                if (chosen[i])
                    continue;

                time.Add(arr[i]);
                if (time.Count == 4)
                {
                    var hrs = time[0] * 10 + time[1];
                    var mins = time[2] * 10 + time[3];
                    if ((hrs > maxHrs && hrs < 24 && mins < 60) ||
                        (hrs == maxHrs && mins > maxMins && mins < 60))
                    {
                        maxHrs = hrs;
                        maxMins = mins;
                    }
                }
                else
                {
                    chosen[i] = true;
                    Backtrack();
                    chosen[i] = false;
                }
                time.RemoveAt(time.Count - 1);
            }
        }

        Backtrack();

        if (maxHrs == 0 && maxMins == 0 && arr.Any(x => x > 0))
            return "";

        return maxHrs.ToString("00") + ":" + maxMins.ToString("00");
    }


    // 1021. Remove Outermost Parentheses
    public string RemoveOuterParentheses(string s)
    {
        var count = 0;
        var sb = new StringBuilder();
        var start = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                count--;
            else
                count++;

            if (count == 0)
            {
                sb.Append(s.Substring(start + 1, i - start - 1));
                start = i + 1;
            }
        }
        return sb.ToString();
    }


    // 2108. Find First Palindromic String in the Array
    public string FirstPalindrome(string[] words)
    {
        bool IsPalindrome(string s)
        {
            var i = 0;
            var j = s.Length - 1;
            while (i <= j)
            {
                if (s[i] != s[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }

        foreach (var word in words)
            if (IsPalindrome(word))
                return word;

        return "";
    }


    // 1309. Decrypt String from Alphabet to Integer Mapping
    public string FreqAlphabets(string s)
    {
        int val = 0;
        var sb = new StringBuilder();
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '#')
            {
                val = 10 * (s[i - 2] - '0') + (s[i - 1] - '0');
                i -= 2;
            }
            else
            {
                val = s[i] - '0';
            }
            sb.Append((char)('a' + val - 1));
        }
        return string.Join("", sb.ToString().Reverse());
    }

    //TODO: finish
    // 1641. Count Sorted Vowel Strings
    //public int CountVowelStrings(int n)
    //{

    //}
}
