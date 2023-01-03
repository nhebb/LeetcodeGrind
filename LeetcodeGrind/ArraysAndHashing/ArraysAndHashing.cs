using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Net.Http.Headers;

namespace LeetcodeGrind.ArraysAndHashing;

public class ArraysAndHashing
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
        return new int[] { -1, -1 }; ;
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
            var testPrefix = strs[0][..i];
            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j][..i] != testPrefix)
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
            var row = new List<int>(r) { 1 };
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


    // 30. Substring with Concatenation of All Words
    // TODO: This approach won't work. words[] has a length of up
    // to 5000, which means there are 5000! possible permutations.
    public IList<int> FindSubstring(string s, string[] words)
    {
        var ans = new List<int>();

        // store indices of each char in s in a dictionary to
        // shorten the substring lookup time
        var d = new Dictionary<char, List<int>>();
        for (char i = 'a'; i <= 'z'; i++)
            d[i] = new List<int>();

        var subLength = words.Length * words[0].Length;
        for (int i = 0; i < s.Length - subLength; i++)
            d[s[i]].Add(i);

        // create permutations of the words
        var perms = new List<string>();


        // check each permutation for existence in s, and if
        // found, add the index to the answer

        return ans;
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

        // The Dictionary 'd' is used to ensure that each letter
        // in the pattern maps to only one word.
        var d = new Dictionary<char, string>();

        // The hashSet 'hs' is used to check the converse - that
        // each word maps to only one letter in the pattern.
        var hs = new HashSet<string>();

        for (int i = 0; i < pattern.Length; i++)
        {
            if (d.TryGetValue(pattern[i], out var val))
            {
                // Check if this pattern letter is mapped
                // to a different word.
                if (val != words[i])
                    return false;
            }
            else
            {
                // If we can't add the word to the HashSet,
                // then the word was already used for another
                // letter in the pattern.
                if (!hs.Add(words[i]))
                    return false;

                // Map the letter to the word
                d[pattern[i]] = words[i];
            }
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


    // 189. Rotate Array
    // This solution is slow / barely pass
    public void Rotate(int[] nums, int k)
    {
        if (k % nums.Length == 0 || nums.Length == 1)
            return;

        k %= nums.Length;

        // save last k elements
        var arr = new int[k];
        int j = 0;
        for (int i = nums.Length - k; i < nums.Length; i++)
        {
            arr[j] = nums[i];
            j++;
        }

        // rotate 0 to len - k elements
        for (int i = nums.Length - 1; i > k - 1; i--)
            nums[i] = nums[i - k];

        // set first k elements
        for (int i = 0; i < k; i++)
            nums[i] = arr[i];
    }


    // 1047. Remove All Adjacent Duplicates In String
    public string RemoveDuplicates(string s)
    {
        var stack = new Stack<char>();
        stack.Push(s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            if (stack.Count == 0 || s[i] != stack.Peek())
            {
                stack.Push(s[i]);
            }
            else
            {
                _ = stack.Pop();
            }
        }
        var result = stack.ToList();
        result.Reverse();
        return string.Join("", result);
    }


    // 2007. Find Original Array From Doubled Array
    public int[] FindOriginalArray(int[] changed)
    {
        if (changed.Length % 2 == 1)
            return Array.Empty<int>();

        var targetLength = changed.Length / 2;

        Array.Sort(changed);
        var d = new Dictionary<int, int>();
        foreach (var num in changed)
        {
            if (d.TryGetValue(num, out int val))
                d[num] = val + 1;
            else
                d[num] = 1;
        }

        // special edge case of zeroes:
        if (d.TryGetValue(0, out var zeroCount))
        {
            if (zeroCount == 1 || zeroCount % 2 == 1)
                return Array.Empty<int>();
        }

        var count = 0;
        var res = new List<int>();
        for (int i = changed.Length - 1; i >= 0; i--)
        {
            if (changed[i] % 2 == 1 || changed[i] == 1)
                continue;

            var half = changed[i] / 2;

            if (d.TryGetValue(half, out var halfValCount) &&
                d.TryGetValue(changed[i], out int changedValCount))
            {
                d[changed[i]]--;
                if (d[changed[i]] == 0)
                    d.Remove(changed[i]);

                if (!d.ContainsKey(half))
                    break;

                d[half]--;
                if (d[half] == 0)
                    d.Remove(half);

                res.Add(half);
                count++;
                if (count == targetLength)
                    break;
            }
        }

        if (count == targetLength)
            return res.ToArray();

        return Array.Empty<int>();
    }


    // 151. Reverse Words in a String
    public string ReverseWords(string s)
    {
        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", words.Reverse());
    }


    // 1748 Sum of Unique Elements
    public int SumOfUnique(int[] nums)
    {
        const int maxLength = 101;
        var freq = new int[maxLength];
        foreach (var num in nums)
            freq[num]++;

        var sum = 0;
        for (int i = 1; i < freq.Length; i++)
            if (freq[i] == 1)
                sum += i;

        return sum;
    }


    // 1817. Finding the Users Active Minutes
    public int[] FindingUsersActiveMinutes(int[][] logs, int k)
    {
        var idMinutesMap = new Dictionary<int, HashSet<int>>();
        foreach (var log in logs)
        {
            if (idMinutesMap.TryGetValue(log[0], out var hs))
            {
                hs.Add(log[1]);
            }
            else
            {
                idMinutesMap[log[0]] = new HashSet<int>();
                idMinutesMap[log[0]].Add(log[1]);
            }
        }

        var ans = new int[k];
        foreach (var kvp in idMinutesMap)
        {
            var numMinutes = kvp.Value.Count;
            if (numMinutes <= k)
                ans[numMinutes - 1]++;
        }

        return ans;
    }


    // 2161. Partition Array According to Given Pivot
    public int[] PivotArray(int[] nums, int pivot)
    {
        var lesser = new Queue<int>();
        var greater = new Queue<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < pivot)
                lesser.Enqueue(nums[i]);
            else if (nums[i] > pivot)
                greater.Enqueue(nums[i]);
        }

        var numPivots = nums.Length - (lesser.Count + greater.Count);
        var index = -1;

        while (lesser.Count > 0)
        {
            index++;
            nums[index] = lesser.Dequeue();
        }

        for (int i = 0; i < numPivots; i++)
        {
            index++;
            nums[index] = pivot;
        }

        while (greater.Count > 0)
        {
            index++;
            nums[index] = greater.Dequeue();
        }

        return nums;
    }


    // 16. 3Sum Closest
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);

        var minDiff = int.MaxValue;
        var minSum = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            var lastDiff = int.MaxValue;
            int j = i + 1;
            int k = nums.Length - 1;
            while (j < k)
            {
                var diff = nums[i] + nums[j] + nums[k] - target;
                if (diff == 0)
                    return nums[i] + nums[j] + nums[k];

                var absDiff = Math.Abs(diff);
                if (absDiff < minDiff)
                {
                    minDiff = absDiff;
                    minSum = nums[i] + nums[j] + nums[k];
                }

                lastDiff = absDiff;

                if (diff < 0)
                    j++;
                else if (diff > 0)
                    k--;
            }
        }
        return minSum;
    }


    // 18. 4Sum
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var ans = new List<IList<int>>();
        if (nums.Length < 4)
            return ans;

        Array.Sort(nums);
        var indices = new HashSet<string>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                int k = j + 1;
                int l = nums.Length - 1;
                while (k < l)
                {
                    long diff = (long)nums[i] + nums[j] + nums[k] + nums[l] - target;
                    if (diff == 0)
                    {
                        if (indices.Add($"{nums[i]},{nums[j]},{nums[k]},{nums[l]}"))
                        {
                            ans.Add(new List<int>() { nums[i], nums[j], nums[k], nums[l] });
                        }
                        k++;
                        l--;
                    }
                    else if (diff < 0)
                        k++;
                    else
                        l--;
                }
            }
        }

        return ans;
    }


    // 283. Move Zeroes
    public void MoveZeroes(int[] nums)
    {
        var offset = 0;
        var firstZeroIndex = nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                offset++;
            else if (offset > 0)
            {
                nums[i - offset] = nums[i];
                firstZeroIndex = i - offset + 1;
            }
        }
        for (int i = firstZeroIndex; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }


    // 31. Next Permutation
    public void NextPermutation(int[] nums)
    {
        // 45123 -> 45132 -> 45213 -> 45231 -> 45312 -> 45321 -> 54321 -> 12345
        // 53421 -> 54123
        if (nums.Length == 1) return;

        // if the last 2 are reversed, just swap and return
        if (nums[^2] < nums[^1])
        {
            (nums[^2], nums[^1]) = (nums[^1], nums[^2]);
            return;
        }

        // Moving right to left, find num less than previous 
        int i = nums.Length - 3;
        while (i >= 0 && nums[i] >= nums[i + 1])
            i--;

        // If we reach i == -1, then nums is reverse order
        if (i == -1)
        {
            Array.Sort(nums);
            return;
        }

        // Find the next element >= nums[i].
        var greaterVal = int.MaxValue;
        var greaterIndex = -1;
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[j] >= nums[i] && nums[j] < greaterVal)
            {
                greaterIndex = j;
                greaterVal = nums[j];
            }
        }

        // Add values from i to end of nums - except greaterVal - to a list.
        // Assign greaterVal to nums[i], then copy the sorted list to the
        // end of nums, after i
        var tailNums = new List<int>();
        tailNums.Add(nums[i]);
        nums[i] = greaterVal;
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (j == greaterIndex) continue;
            tailNums.Add(nums[j]);
        }

        tailNums.OrderBy(x => x)
                .ToArray()
                .CopyTo(nums, i + 1);
    }

    public void NextPermutation2(int[] nums)
    {
        if (nums.Length == 1)
            return;

        // O(n) reverse instead of sort
        void Reverse(int i, int j)
        {
            while (i < j)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                i++;
                j--;
            }
        }

        int i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1])
            i--;

        // Existing array is monotonically decreasing, so next permutation
        // is just a sorted version of original
        if (i == -1)
        {
            Array.Sort(nums);
            return;
        }

        int j = nums.Length - 1;
        while (j > i && nums[i] >= nums[j])
            j--;

        (nums[i], nums[j]) = (nums[j], nums[i]);

        Reverse(i + 1, nums.Length - 1);
    }


    // 560. Subarray Sum Equals K
    public int SubarraySum(int[] nums, int k)
    {
        var d = new Dictionary<int, int>();

        // track prefix sum counts in dictionary
        var sum = nums[0];
        var count = 0;
        if (sum == k)
            count++;
        d[sum] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            sum += nums[i];

            // check for base match
            if (sum == k)
                count++;

            // check for other matches, i.e., prefix subarrays that
            // we can remove to make matching subarray sums
            var delta = sum - k;
            if (d.TryGetValue(delta, out var deltaMatches))
                count += deltaMatches;

            // add prefix sum to dictionary
            if (d.TryGetValue(sum, out var lastCount))
                d[sum] = lastCount + 1;
            else
                d[sum] = 1;
        }
        return count;
    }


    // 763. Partition Labels
    public IList<int> PartitionLabels(string s)
    {
        var ans = new List<int>();
        var d = new Dictionary<char, int>();

        for (int index = 0; index < s.Length; index++)
        {
            d[s[index]] = index; // store last index only
        }

        var idx1 = 0;
        while (idx1 < s.Length)
        {
            var idx2 = d[s[idx1]];
            if (idx1 == idx2)
            {
                ans.Add(1);
                idx1++;
            }
            else
            {
                var maxIndex = idx2;
                var j = idx1 + 1;
                while (j < maxIndex)
                {
                    maxIndex = Math.Max(maxIndex, d[s[j]]);
                    j++;
                }
                ans.Add(maxIndex - idx1 + 1);
                idx1 = maxIndex + 1;
            }
        }

        return ans;
    }


    // 1409. Queries on a Permutation With Key
    public int[] ProcessQueries(int[] queries, int m)
    {
        var p = Enumerable.Range(1, m).ToList();
        var ans = new List<int>();

        foreach (var query in queries)
        {
            var idx = p.IndexOf(query);
            ans.Add(idx);
            p.RemoveAt(idx);
            p.Insert(0, query);
        }
        return ans.ToArray();
    }


    // 1436. Destination City
    public string DestCity(IList<IList<string>> paths)
    {
        var hs = new HashSet<string>();
        foreach (var path in paths)
            hs.Add(path[0]);

        foreach (var path in paths)
            if (!hs.Contains(path[1]))
                return path[1];

        return string.Empty;
    }


    // 1534. Count Good Triplets
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        var count = 0;
        for (int i = 0; i < arr.Length - 2; i++)
        {
            for (int j = i + 1; j < arr.Length - 1; j++)
            {
                for (int k = j + 1; k < arr.Length; k++)
                {
                    /* |arr[i] - arr[j]| <= a
                     * |arr[j] - arr[k]| <= b
                     * |arr[i] - arr[k]| <= c
                     */

                    if (Math.Abs(arr[i] - arr[j]) <= a &&
                        Math.Abs(arr[j] - arr[k]) <= b &&
                        Math.Abs(arr[i] - arr[k]) <= c)
                        count++;
                }
            }
        }
        return count;
    }


    // 1630. Arithmetic Subarrays
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
    {
        var ans = new List<bool>();

        for (int i = 0; i < l.Length; i++)
        {
            var isArithmetic = true;
            var segment = nums.Skip(l[i]).Take(r[i] - l[i] + 1).OrderBy(x => x).ToArray();
            var delta = segment[1] - segment[0];
            for (int j = 1; j < segment.Count() - 1; j++)
            {
                if (segment[j + 1] - segment[j] != delta)
                {
                    isArithmetic = false;
                    break;
                }
            }
            ans.Add(isArithmetic);
        }

        return ans;
    }


    // 1637. Widest Vertical Area Between Two Points Containing No Points
    public int MaxWidthOfVerticalArea(int[][] points)
    {
        var sortedPoints = points.OrderBy(x => x[0]).ToArray();

        var maxDx = 0;

        for (int i = 1; i < sortedPoints.Count(); i++)
        {
            maxDx = Math.Max(maxDx, sortedPoints[i][0] - sortedPoints[i - 1][0]);
        }

        return maxDx;
    }


    // 1930. Unique Length-3 Palindromic Subsequences
    public int CountPalindromicSubsequence(string s)
    {
        var count = 0;
        var d = new Dictionary<char, List<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            if (d.TryGetValue(s[i], out var list))
                list.Add(i);
            else
                d[s[i]] = new List<int>() { i };
        }

        var hs = new HashSet<string>();

        foreach (var kvp in d)
        {
            if (kvp.Value.Count < 2)
                continue;

            var i = kvp.Value[0];
            var j = kvp.Value[^1];

            if (j - i < 2)
                continue;

            var letter = kvp.Key.ToString();

            for (int k = i + 1; k < j; k++)
            {
                var seq = letter + s[k].ToString() + letter;
                if (hs.Add(seq))
                    count++;
            }
        }

        return count;
    }


    // 2037. Minimum Number of Moves to Seat Everyone
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        Array.Sort(seats);
        Array.Sort(students);

        var moves = 0;
        for (int i = 0; i < seats.Length; i++)
        {
            moves += Math.Abs(students[i] - seats[i]);
        }

        return moves;
    }


    // 2176. Count Equal and Divisible Pairs in an Array
    public int CountPairs(int[] nums, int k)
    {
        var count = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j] && (i * j) % k == 0)
                {
                    count++;
                }
            }
        }

        return count;
    }


    // 2221. Find Triangular Sum of an Array
    public int TriangularSum(int[] nums)
    {
        var last = nums.Length - 1;
        while (last > 0)
        {
            for (int i = 0; i < last; i++)
            {
                nums[i] = (nums[i] + nums[i + 1]) % 10;
            }
            last--;
        }
        return nums[0];
    }


    // 2500. Delete Greatest Value in Each Row
    public int DeleteGreatestValue(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            Array.Sort(grid[i]);
        }

        var ans = 0;

        for (int j = grid[0].Length - 1; j >= 0; j--)
        {
            int max = int.MinValue;
            for (int i = 0; i < grid.Length; i++)
            {
                max = Math.Max(max, grid[i][j]);
            }
            ans += max;
        }

        return ans;
    }


    // 2506. Count Pairs Of Similar Strings
    public int SimilarPairs(string[] words)
    {
        var strs = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            var hs = new HashSet<char>(words[i]);
            strs[i] = string.Join("", hs.OrderBy(x => x));
            //strs[i] = new string(words[i].OrderBy(x => x).Distinct().ToArray());
        }

        var count = 0;
        for (int i = 0; i < strs.Length - 1; i++)
        {
            for (int j = i + 1; j < strs.Length; j++)
            {
                if (strs[i] == strs[j])
                    count++;
            }
        }
        return count;
    }


    // 944. Delete Columns to Make Sorted
    public int MinDeletionSize(string[] strs)
    {
        var count = 0;
        for (int col = 0; col < strs[0].Length; col++)
        {
            for (int row = 1; row < strs.Length; row++)
            {
                if (strs[row][col] < strs[row - 1][col])
                {
                    count++;
                    break;
                }
            }
        }
        return count;
    }
}
