using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace LeetcodeGrind.ArraysAndHashing;

internal class ArraysAndHashing
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


    // 605. Can Place Flowers
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        // edge cases
        if (n == 0) return true;
        if (n > flowerbed.Length / 2 + 1) return false;
        if (flowerbed.Length == 1)
            return flowerbed[0] == 0; // n must be 1 based on prior 'if'

        if (flowerbed[0] == 0 && flowerbed[1] == 0)
        {
            flowerbed[0] = 1;
            n--;
        }
        if (flowerbed[^1] == 0 && flowerbed[^2] == 0)
        {
            flowerbed[^1] = 1;
            n--;
        }

        for (int i = 1; i < flowerbed.Length - 1; i++)
        {
            if (flowerbed[i] == 0 && flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0)
            {
                flowerbed[i] = 1;
                n--;
            }
        }

        return n <= 0;
    }


    // 169. Majority Element
    public int MajorityElement(int[] nums)
    {
        int maj = nums[0];
        int max = 0;
        var d = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!d.ContainsKey(nums[i]))
                d[nums[i]] = 0;

            d[nums[i]]++;

            if (d[nums[i]] > max)
            {
                max = d[nums[i]];
                maj = nums[i];
            }
        }

        return maj;
    }


    // 724. Find Pivot Index
    public int PivotIndex(int[] nums)
    {
        int rsum = nums.Sum();
        if (rsum - nums[0] == 0)
        {
            return 0;
        }

        int lsum = nums[0];
        rsum -= nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            rsum -= nums[i];
            if (lsum == rsum)
            {
                return i;
            }
            lsum += nums[i];
        }
        return -1;
    }


    // 448. Find All Numbers Disappeared in an Array
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var hs = new HashSet<int>();
        foreach (var num in nums)
            hs.Add(num);

        var missing = new List<int>();
        for (int i = 1; i <= nums.Length; i++)
        {
            if (!hs.Contains(i))
                missing.Add(i);
        }

        return missing;
    }


    // 1189. Maximum Number of Balloons
    public int MaxNumberOfBalloons(string text)
    {
        var charCounts = new Dictionary<char, int>();
        var validChars = "balon";

        foreach (var c in text)
        {
            if (validChars.Contains(c))
            {
                if (!charCounts.TryAdd(c, 1))
                {
                    charCounts[c]++;
                }
            }
        }

        foreach (var c in validChars)
        {
            if (!charCounts.ContainsKey(c))
                return 0;
        }

        var numLO = Math.Min(charCounts['l'], charCounts['o']) / 2; // l and o appear twice
        var numABN = Math.Min(Math.Min(charCounts['a'], charCounts['b']), charCounts['n']);
        return Math.Min(numLO, numABN);
    }


    //290. Word Pattern
    public bool WordPattern(string pattern, string s)
    {
        var words = s.Split(' ');

        if (pattern.Length != words.Length)
            return false;

        var d = new Dictionary<char, string>();
        for (int i = 0; i < pattern.Length; i++)
        {
            if (d.TryGetValue(pattern[i], out var val))
            {
                if (val != words[i])
                    return false;
            }
            else
            {
                d[pattern[i]] = words[i];
            }
        }
        var hs = new HashSet<string>();
        foreach (var kvp in d)
        {
            if (!hs.Add(kvp.Value))
                return false;
        }
        return true;
    }


    // 347. Top K Frequent Elements
    public int[] TopKFrequent(int[] nums, int k)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
                d[nums[i]]++;
            else
                d[nums[i]] = 1;
        }

        var pq = new PriorityQueue<int, long>();
        foreach (var kvp in d)
        {
            pq.Enqueue(kvp.Key, Int32.MaxValue - kvp.Value);
        }

        var topk = new int[k];
        int j = 0;
        while (j < k)
        {
            topk[j] = pq.Dequeue();
            j++;
        }

        return topk;
    }


    // 238. Product of Array Except Self
    public int[] ProductExceptSelf(int[] nums)
    {
        var products = new int[nums.Length];

        // special cases
        if (nums.Length == 1)
        {
            products[0] = 0;
            return products;
        }
        else if (nums.Length == 2)
        {
            products[0] = nums[1];
            products[1] = nums[0];
            return products;
        }
        else if (nums.Where(x => x == 0).Count() > 1)
        {
            return products;
        }

        // prefix products
        var prefixes = new int[nums.Length];
        prefixes[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefixes[i] = prefixes[i - 1] * nums[i];
        }

        var suffixes = new int[nums.Length];
        suffixes[^1] = nums[^1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            suffixes[i] = suffixes[i + 1] * nums[i];
        }

        for (int i = 1; i < nums.Length - 1; i++)
        {
            products[i] = prefixes[i - 1] * suffixes[i + 1];
        }
        products[0] = suffixes[1];
        products[^1] = prefixes[^2];

        return products;
    }


    // 36. Valid Sudoku
    public bool IsValidSudoku(char[][] board)
    {
        var hsRow = new HashSet<char>();
        HashSet<char>[] hsCol = new HashSet<char>[9];
        HashSet<char>[] hsBlock = new HashSet<char>[9];

        for (int i = 0; i < 9; i++)
        {
            hsCol[i] = new HashSet<char>();
            hsBlock[i] = new HashSet<char>();
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == '.')
                    continue;

                if (!hsRow.Add(board[i][j]))
                    return false;

                if (!hsCol[j].Add(board[i][j]))
                    return false;

                int b = (j / 3) + (i / 3) * 3;
                if (!hsBlock[b].Add(board[i][j]))
                    return false;
            }
            hsRow.Clear();
        }
        return true;
    }


    // 128. Longest Consecutive Sequence
    public int LongestConsecutive(int[] nums)
    {
        if (nums == null || nums.Length == 0) return 0;

        int maxCount = 1;
        var hs = new HashSet<int>(nums);

        foreach (var num in nums)
        {
            if (!hs.Contains(num - 1))
            {
                var count = 1;
                var val = num + 1;
                while (hs.Contains(val))
                {
                    count++;
                    val++;
                }
                maxCount = Math.Max(maxCount, count);
            }
        }

        return maxCount;
    }


    // 75. Sort Colors
    public void SortColors(int[] nums)
    {
        int count0 = 0;
        int count1 = 0;
        int count2 = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                count0++;
            else if (nums[i] == 1)
                count1++;
            else
                count2++;
        }

        for (int i = 0; i < count0; i++)
            nums[i] = 0;

        for (int i = count0; i < count0 + count1; i++)
            nums[i] = 1;

        for (int i = count0 + count1; i < nums.Length; i++)
            nums[i] = 2;

    }


    // 554. Brick Wall
    public int LeastBricks(IList<IList<int>> wall)
    {
        var lengthCounts = new Dictionary<int, int>();
        foreach (var row in wall)
        {
            var len = 0;
            for (int i = 0; i < row.Count - 1; i++)
            {
                len += row[i];
                if (!lengthCounts.TryAdd(len, 1))
                    lengthCounts[len]++;
            }
        }

        var mostEdges = 0;
        foreach (var kvp in lengthCounts)
            mostEdges = Math.Max(mostEdges, kvp.Value);

        return wall.Count - mostEdges;

    }


    // 28. Find the Index of the First Occurrence in a String
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle))
            return 0;

        if (needle.Length > haystack.Length)
            return -1;

        if (haystack.Length == needle.Length)
            return haystack == needle ? 0 : -1;


        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if (haystack[i] == needle[0])
            {
                bool match = true;
                for (int j = i, k = 0; k < needle.Length; j++, k++)
                {
                    if (haystack[j] != needle[k])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                    return i;
            }
        }
        return -1;
    }


    // 179. Largest Number
    private class StringJoinComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return (x + y).CompareTo(y + x);
        }
    }

    public string LargestNumber(int[] nums)
    {
        if (nums.All(x => x == 0)) return "0";

        var vals = nums.Select(x => x.ToString())
                       .OrderByDescending(x => x, new StringJoinComparer());

        return string.Join("", vals);
    }


    // 41. First Missing Positive
    public int FirstMissingPositive(int[] nums)
    {
        if (nums == null || nums.Length == 0) { return 1; }
        int min = int.MaxValue;
        int max = int.MinValue;
        var hs = new HashSet<int>();

        foreach (var num in nums)
        {
            hs.Add(num);
            if (num < min) { min = num; }
            if (num > max) { max = num; }
        }

        if (max <= 0) { return 1; }
        if (min < 1) { min = 1; }
        if (min > 1) { return 1; }

        for (int i = min; i <= max; i++)
        {
            if (!hs.Contains(i)) { return i; }
        }
        return max + 1;
    }
}
