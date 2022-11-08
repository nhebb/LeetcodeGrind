using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

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


    // 118. Pascal's Triangle
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>();
        if (numRows < 1) { return result; }

        result.Add(new List<int>() { 1 });
        if (numRows == 1) return result;

        result.Add(new List<int>() { 1, 1 });
        if (numRows == 2) return result;

        for (int r = 2; r < numRows; r++)
        {
            var row = new List<int>(r);
            row.Add(1);
            for (int c = 1; c < r; c++)
            {
                row.Add(result[r - 1][c - 1] + result[r - 1][c]);
            }
            row.Add(1);
            result.Add(row);
        }
        return result;
    }


    // 27. Remove Element
    /* Python3 version:
    def removeElement(self, nums: List[int], val: int) -> int:
        validLength = 0
        for i in range(len(nums)):
            if nums[i] != val:
                nums[validLength] = nums[i]
                validLength += 1
        
        return validLength
     */
    public int RemoveElement(int[] nums, int val)
    {
        int validLength = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[validLength] = nums[i];
                validLength++;
            }
        }
        return validLength;
    }



    // 496. Next Greater Element I
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < nums2.Length; i++)
        {
            d[nums2[i]] = i;
        }

        var ans = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            var found = false;
            int j = d[nums1[i]] + 1;
            while (j < nums2.Length)
            {
                if (nums2[j] > nums1[i])
                {
                    ans[i] = nums2[j];
                    found = true;
                    break;
                }
                j++;
            }
            if (!found)
                ans[i] = -1;
        }
        return ans;
    }


    // 503. Next Greater Element II
    /* Given a circular integer array nums (i.e., the next element of 
     * nums[nums.length - 1] is nums[0]), return the next greater number
     * for every element in nums.
     * 
     * The next greater number of a number x is the first greater number 
     * to its traversing-order next in the array, which means you could 
     * search circularly to find its next greater number. If it doesn't exist,
     * return -1 for this number.
     * */
    public int[] NextGreaterElements(int[] nums)
    {
        var ans = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            var found = false;
            var j = (i + 1) % nums.Length;
            while (true)
            {
                if (i == j) break;

                if (nums[j] > nums[i])
                {
                    ans[i] = nums[j];
                    found = true;
                    break;
                }
                j = (j + 1) % nums.Length;
            }
            if (!found)
                ans[i] = -1;
        }
        return ans;
    }


    // 929. Unique Email Addresses
    public int NumUniqueEmails(string[] emails)
    {
        var hs = new HashSet<string>();
        foreach (var email in emails)
        {
            var parts = email.Split('@');
            var local = parts[0].Replace(".", "");
            if (local.Contains('+'))
                hs.Add(local.Split('+')[0] + "@" + parts[1]);
            else
                hs.Add(local + "@" + parts[1]);
        }
        return hs.Count;
    }


    // 205. Isomorphic Strings
    public bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length) { return false; }
        if (s == t || s.Length == 1) { return true; }

        var sdict = new Dictionary<char, int>();
        var tdict = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!sdict.ContainsKey(s[i]))
                sdict[s[i]] = i;
            if (!tdict.ContainsKey(t[i]))
                tdict[t[i]] = i;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (sdict[s[i]] != tdict[t[i]])
                return false;
        }
        return true;
    }
}
