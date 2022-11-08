using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.ArraysAndHashing;

internal class Solution
{
    // 217. Contains Duplicate
    public bool ContainsDuplicate(int[] nums)
    {
        var hs = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!hs.Add(nums[i]))
                return true;
        }
        return false;
    }


    // 1. Two Sum
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            dict[nums[i]] = i;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.TryGetValue(target - nums[i], out int result)
                && result != i)
            {
                return new int[] { i, result };
            }
        }
        return null;
    }


    // 242. Valid Anagram
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) { return false; }

        var dict = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (!dict.TryAdd(c, 1))
                dict[c]++;
        }
        foreach (char c in t)
        {
            if (!dict.ContainsKey(c))
                return false;

            dict[c] -= 1;
            if (dict[c] == 0)
                dict.Remove(c);
        }
        return true;
    }


    // 49. Group Anagrams
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var res = new List<IList<string>>();
        var d = new Dictionary<string, List<string>>();
        foreach (var s in strs)
        {
            var chars = string.Join("", s.ToCharArray().OrderBy(x => x));
            if (!d.ContainsKey(chars))
                d[chars] = new List<string>();
            d[chars].Add(s);
        }

        foreach (var kvp in d)
        {
            res.Add(kvp.Value);
        }
        return res;
    }


    // 1299. Replace Elements with Greatest Element on Right Side
    /* I did this one in Python3
    def replaceElements(self, arr: List[int]) -> List[int]:
        lastMax = -1
        for i in range(len(arr) -1, -1, -1):
            curMax = max(lastMax, arr[i])
            arr[i] = lastMax
            lastMax = curMax
            
        return arr
     */


    // 392. Is Subsequence
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length > t.Length) { return false; }
        if (s == string.Empty || s == t) { return true; }

        int i = 0;
        int j = 0;

        while (i < s.Length && j < t.Length)
        {
            if (s[i] == t[j])
            {
                if (i == s.Length - 1) { return true; }
                i++;
            }
            j++;
        }
        return false;
    }


    // 58. Length of Last Word
    public int LengthOfLastWord(string s)
    {
        // The 'hard' way - without using Split()
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


    // 14. Longest Common Prefix
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
        {
            return "";
        }

        var maxLength = int.MaxValue;
        foreach (var str in strs)
        {
            if (str == null) { return ""; }
            if (str.Length < maxLength) { maxLength = str.Length; }
        }

        if (maxLength == 0) { return ""; }

        var longest = "";
        int i = 1;
        bool nomatch = false;
        while (i <= maxLength)
        {
            var testPrefix = strs[0].Substring(0, i);
            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j].Substring(0, i) != testPrefix)
                {
                    nomatch = true;
                    break;
                }
            }
            if (nomatch) { break; }
            longest = testPrefix;
            i++;
        }
        return longest;
    }
}
