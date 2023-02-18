using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

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
            => (x + y).CompareTo(y + x);
    }

    public string LargestNumber(int[] nums)
    {
        if (nums.All(x => x == 0))
            return "0";

        Array.Sort(nums, (x, y) => ($"{x}{y}").CompareTo($"{y}{x}"));
        return string.Join("", nums);

        //var vals = nums.Select(x => x.ToString())
        //               .OrderByDescending(x => x, new StringJoinComparer());

        //return string.Join("", vals);
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


    // 2079. Watering Plants
    public int WateringPlants(int[] plants, int capacity)
    {
        var count = 0;
        var water = capacity;

        for (int i = 0; i < plants.Length; i++)
        {
            // walk to plant and water it
            count += i + 1;
            water -= plants[i];

            // while water can has enough to fill neighnoring plant(s)
            // increment count, i, and water the plant(s)
            while (i < plants.Length - 1 && water >= plants[i + 1])
            {
                count++;
                i++;
                water -= plants[i];
            }

            // walk back to river and refill can
            count += i + 1;
            water = capacity;
        }

        return count;
    }


    // 1561. Maximum Number of Coins You Can Get
    public int MaxCoins(int[] piles)
    {
        Array.Sort(piles);
        var count = 0;

        for (int j = piles.Length - 2; j >= piles.Length / 3; j -= 2)
            count += piles[j];

        return count;
    }


    // 2284. Sender With Largest Word Count
    public string LargestWordCount(string[] messages, string[] senders)
    {
        var maxWords = 0;
        var bigSenders = new List<string>();
        var d = new Dictionary<string, int>();

        for (int i = 0; i < messages.Length; i++)
        {
            var numWords = messages[i].Split(' ').Length;
            if (d.TryGetValue(senders[i], out int val))
                numWords += val;
            d[senders[i]] = numWords;

            if (numWords == maxWords)
            {
                bigSenders.Add(senders[i]);
            }
            else if (numWords > maxWords)
            {
                bigSenders.Clear();
                bigSenders.Add(senders[i]);
                maxWords = numWords;
            }
        }
        return bigSenders.OrderByDescending(x => x, StringComparer.Ordinal)
                         .First();
    }


    // 2244. Minimum Rounds to Complete All Tasks
    public int MinimumRounds(int[] tasks)
    {
        var difficultyCounts = new Dictionary<int, int>();
        foreach (var task in tasks)
        {
            if (difficultyCounts.TryGetValue(task, out int val))
                difficultyCounts[task] = val + 1;
            else
                difficultyCounts[task] = 1;
        }

        var rounds = 0;
        foreach (var kvp in difficultyCounts)
        {
            if (kvp.Value == 1)
                return -1;

            var count = kvp.Value;
            while (count > 0)
            {
                if (count == 4)
                {
                    rounds += 2;
                    count = 0;
                }
                else if (count <= 3)
                {
                    rounds++;
                    count = 0;
                }
                else
                {
                    count -= 3;
                    rounds++;
                }
            }
        }

        return rounds;
    }


    // 1833. Maximum Ice Cream Bars
    public int MaxIceCream(int[] costs, int coins)
    {
        var count = 0;

        // Calculate whether O(n log n) solution would be
        // faster than O(n) solution
        if (costs.Length * Math.Log(costs.Length, 2) < coins)
        {
            Array.Sort(costs);
            foreach (var cost in costs)
            {
                if (coins < cost)
                    break;

                coins -= cost;
                count++;
            }
        }
        else
        {
            var d = new Dictionary<int, int>();
            foreach (var cost in costs)
            {
                if (d.TryGetValue(cost, out var val))
                    d[cost] = val + 1;
                else
                    d[cost] = 1;
            }

            for (int icCost = 1; icCost <= coins; icCost++)
            {
                if (d.TryGetValue(icCost, out var numIceCreams))
                {
                    while (numIceCreams > 0 && coins - icCost >= 0)
                    {
                        count++;
                        coins -= icCost;
                        numIceCreams--;
                    }
                }
            }
        }
        return count;
    }


    // 228. Summary Ranges
    public IList<string> SummaryRanges(int[] nums)
    {
        var res = new List<string>();

        if (nums.Length == 0)
            return res;
        if (nums.Length == 1)
        {
            res.Add(nums[0].ToString());
            return res;
        }

        Array.Sort(nums);

        var first = nums[0];
        var last = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1] + 1)
            {
                if (first == last)
                    res.Add(first.ToString());
                else
                    res.Add($"{first}->{last}");

                first = nums[i];
            }

            if (i == nums.Length - 1)
            {
                if (first == nums[i])
                    res.Add(first.ToString());
                else
                    res.Add($"{first}->{nums[i]}");
            }

            last = nums[i];
        }

        return res;
    }


    // 350. Intersection of Two Arrays II
    public int[] IntersectII(int[] nums1, int[] nums2)
    {
        var d1 = new Dictionary<int, int>();
        var d2 = new Dictionary<int, int>();

        foreach (var num in nums1)
            if (!d1.TryAdd(num, 1))
                d1[num]++;

        foreach (var num in nums2)
            if (!d2.TryAdd(num, 1))
                d2[num]++;

        var res = new List<int>();
        foreach (var kvp in d1)
        {
            if (d2.TryGetValue(kvp.Key, out var val))
            {
                var count = Math.Min(kvp.Value, val);
                for (int i = 0; i < count; i++)
                    res.Add(kvp.Key);
            }
        }

        return res.ToArray();
    }


    // 414. Third Maximum Number
    public int ThirdMax(int[] nums)
    {
        var sorted = nums.OrderByDescending(x => x)
                         .Distinct();

        if (sorted.Count() < 3)
            return sorted.First();
        else
            return sorted.Skip(2).Take(1).First();
    }


    // 482. License Key Formatting
    public string LicenseKeyFormatting(string s, int k)
    {
        s = s.Replace("-", "").ToUpper();
        var firstLen = s.Length % k;

        var sb = new StringBuilder();
        sb.Append(s[0..firstLen]);

        var i = firstLen;
        while (i < s.Length)
        {
            if (i > 0)
                sb.Append('-');

            for (int j = i; j < i + k; j++)
            {
                sb.Append(s[j]);
            }
            i += k;
        }
        return sb.ToString();
    }


    // 134. Gas Station
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        // Run a postfix sum on the net difference between
        // gas and cost. The index where the postfix is
        // maximized indicates the inflection point
        var postfixSum = new int[gas.Length];
        postfixSum[^1] = gas[^1] - cost[^1];
        var max = postfixSum[^1];
        var maxIndex = gas.Length - 1;
        for (int i = gas.Length - 2; i >= 0; i--)
        {
            postfixSum[i] = postfixSum[i + 1] + gas[i] - cost[i];
            if (postfixSum[i] >= max)
            {
                max = postfixSum[i];
                maxIndex = i;
            }
        }

        // If the total cost is greater than the total
        // gas available, solution isn't possible
        if (postfixSum[0] < 0)
            return -1;

        return maxIndex;
    }


    // 2485. Find the Pivot Integer
    public int PivotInteger(int n)
    {
        var prefix = new int[n];
        var postfix = new int[n];

        prefix[0] = 1;
        for (int i = 2; i < n; i++)
            prefix[i - 1] = prefix[i - 2] + i;

        postfix[^1] = n;
        for (int i = n - 1; i > 0; i--)
            postfix[i - 1] = postfix[i] + i;

        for (int i = 0; i < n; i++)
            if (prefix[i] == postfix[i])
                return i + 1;

        return -1;
    }


    // 1967. Number of Strings That Appear as Substrings in Word
    public int NumOfStrings(string[] patterns, string word)
    {
        var count = 0;
        foreach (var pattern in patterns)
        {
            if (word.Contains(pattern))
                count++;
        }
        return count;
    }


    // 485. Max Consecutive Ones
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var s = string.Join("", nums);
        var arr = s.Split('0', StringSplitOptions.RemoveEmptyEntries);
        var max = 0;
        foreach (var ones in arr)
            max = Math.Max(max, ones.Length);
        return max;
    }


    // 941. Valid Mountain Array
    public bool ValidMountainArray(int[] arr)
    {
        if (arr.Length < 3)
            return false;

        var increasing = true;
        var i = 0;
        var j = arr.Length - 1;
        while (increasing && i < j)
        {
            increasing = false;
            if (arr[i] < arr[i + 1])
            {
                i++;
                increasing = true;
            }

            if (arr[j - 1] > arr[j])
            {
                j--;
                increasing = true;
            }

            if (i == j && i > 0 && j < arr.Length - 1)
                return true;
        }
        return false;
    }


    // 80. Remove Duplicates from Sorted Array II
    public int RemoveDuplicatesII(int[] nums)
    {
        int i = 0;
        foreach (var num in nums)
        {
            if (i < 2 || num > nums[i - 2])
            {
                nums[i] = num;
                i++;
            }
        }
        return i;
    }


    // 2515. Shortest Distance to Target String in a Circular Array
    public int ClosetTarget(string[] words, string target, int startIndex)
    {
        if (!words.Any(x => x == target))
            return -1;

        var n = words.Length;
        var min = n;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == target)
            {
                if (i == startIndex)
                    return 0;

                var curMin = startIndex > i
                    ? Math.Min(startIndex - i, n + i - startIndex)
                    : Math.Min(i - startIndex, n + startIndex - i);

                min = Math.Min(min, curMin);
            }
        }

        return min;
    }


    // 2432. The Employee That Worked on the Longest Task
    public int HardestWorker(int n, int[][] logs)
    {
        var res = new List<int>() { logs[0][0] };
        var longest = logs[0][1];

        for (int i = 1; i < logs.Length; i++)
        {
            var time = logs[i][1] - logs[i - 1][1];
            if (time == longest)
            {
                res.Add(logs[i][0]);
            }
            else if (time > longest)
            {
                res.Clear();
                res.Add(logs[i][0]);
                longest = time;
            }
        }

        return res.Min();
    }


    // 509. Fibonacci Number
    public int Fib(int n)
    {
        if (n < 2) return n;

        var ans = new int[n + 1];
        ans[0] = 0;
        ans[1] = 1;

        for (int i = 2; i <= n; i++)
            ans[i] = ans[i - 1] + ans[i - 2];

        return ans[n];
    }

    // TODO: finish
    // 2537. Count the Number of Good Subarrays
    public long CountGood(int[] nums, int k)
    {
        var d = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.TryGetValue(nums[i], out var list))
                list.Add(i);
            else
                d[nums[i]] = new List<int>() { i };
        }

        long count = 0;
        foreach (var kvp in d)
        {
            var n = kvp.Value.Count;
            var numPairs = (n * (n - 1)) / 2;
            while (numPairs >= k && n > 0)
            {
                count++;
                n--;
                numPairs = (n * (n - 1)) / 2;
            }
        }
        return count;
    }


    // 2535. Difference Between Element Sum and Digit Sum of an Array
    public int DifferenceOfSum(int[] nums)
    {
        var sumNums = 0;
        var sumDigits = 0;

        foreach (var num in nums)
        {
            sumNums += num;
            var n = num;
            while (n > 0)
            {
                sumDigits += n % 10;
                n /= 10;
            }
        }

        return Math.Abs(sumNums - sumDigits);
    }


    // 890. Find and Replace Pattern
    public IList<string> FindAndReplacePattern(string[] words, string pattern)
    {
        // create index pattern
        var patternDict = new Dictionary<char, int>();
        var indexList = new List<int>();

        // Create a pattern based on the first index that each
        // letter appears in the string. "mee" would be "0,1,1"
        string CreatePattern(string s)
        {
            // clear between calls
            indexList.Clear();
            patternDict.Clear();

            for (int i = 0; i < s.Length; i++)
            {
                if (!patternDict.ContainsKey(s[i]))
                    patternDict[s[i]] = i;
            }
            foreach (var c in s)
                indexList.Add(patternDict[c]);
            return string.Join(",", indexList);
        }

        var ans = new List<string>();
        var basePattern = CreatePattern(pattern);

        foreach (var word in words)
        {
            if (CreatePattern(word) == basePattern)
                ans.Add(word);
        }

        return ans;
    }


    // 209. Minimum Size Subarray Sum
    public int MinSubArrayLen(int target, int[] nums)
    {
        if (nums.Length == 1 && nums[0] < target)
            return 0;

        var min = nums.Length + 1;

        var i = 0;
        var j = 0;
        var sum = 0;
        // nums = [2,3,1,2,4,3] target = 7
        while (j < nums.Length)
        {
            sum += nums[j];
            if (sum >= target)
            {
                // 1, 5 = 10
                //min = Math.Min(min, j - i + 1);
                while (i <= j && sum >= target)
                {
                    min = Math.Min(min, j - i + 1);
                    sum -= nums[i];
                    i++;
                }
            }
            j++;
        }

        if (min > nums.Length)
            return 0;
        return min;
    }


    // 1725. Number Of Rectangles That Can Form The Largest Square
    public int CountGoodRectangles(int[][] rectangles)
    {
        var max = 0;
        foreach (var rect in rectangles)
            max = Math.Max(max, Math.Min(rect[0], rect[1]));

        var count = 0;
        foreach (var rect in rectangles)
            if (Math.Min(rect[0], rect[1]) == max)
                count++;

        return count;
    }


    // 299. Bulls and Cows
    public string GetHint(string secret, string guess)
    {
        var bulls = 0;
        var cows = 0;

        // dicts contain only unmatched characters
        var secretChars = new Dictionary<char, int>();
        var guessChars = new Dictionary<char, int>();

        for (int i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i])
            {
                bulls++;
            }
            else
            {
                if (secretChars.TryGetValue(secret[i], out var secretVal))
                    secretChars[secret[i]] = secretVal + 1;
                else
                    secretChars[secret[i]] = 1;

                if (guessChars.TryGetValue(guess[i], out var guessVal))
                    guessChars[guess[i]] = guessVal + 1;
                else
                    guessChars[guess[i]] = 1;
            }
        }

        foreach (var secretKV in secretChars)
        {
            if (guessChars.ContainsKey(secretKV.Key))
            {
                if (guessChars[secretKV.Key] >= secretKV.Value)
                    cows += secretKV.Value;
                else
                    cows += guessChars[secretKV.Key];
            }
        }

        return $"{bulls}A{cows}B";
    }


    // 918. Maximum Sum Circular Subarray
    public int MaxSubarraySumCircular(int[] nums)
    {
        // Kadane's algorithm
        int CalcMaxSum()
        {
            int curMax = nums[0];
            int maxSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                curMax = Math.Max(nums[i], curMax + nums[i]);
                maxSum = Math.Max(maxSum, curMax);
            }
            return maxSum;
        }

        // calculate max sum on normal array
        int maxSum = CalcMaxSum();

        // calculate the totals and flip the signs
        int totalSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            totalSum += nums[i];
            nums[i] = -nums[i];
        }

        // Recalculate the sum with the signs flipped
        // and add to the total sum to get the max
        // circular sum
        int circularSum = totalSum + CalcMaxSum();

        if (circularSum == 0)
            return maxSum;
        return Math.Max(circularSum, maxSum);
    }


    // 697. Degree of an Array
    public int FindShortestSubArray(int[] nums)
    {
        var numIndices = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (numIndices.TryGetValue(nums[i], out var list))
                list.Add(i);
            else
                numIndices[nums[i]] = new List<int> { i };
        }

        var maxFreq = 0;
        var minLen = nums.Length;

        foreach (var kvp in numIndices)
        {
            if (kvp.Value.Count > maxFreq)
            {
                maxFreq = kvp.Value.Count;
                minLen = kvp.Value[^1] - kvp.Value[0] + 1;
            }
            else if (kvp.Value.Count == maxFreq)
            {
                var curLen = kvp.Value[^1] - kvp.Value[0] + 1;
                minLen = Math.Min(minLen, curLen);
            }
        }
        return minLen;
    }


    // 974. Subarray Sums Divisible by K
    public int SubarraysDivByK(int[] nums, int k)
    {
        var count = 0;
        var curr = 0;
        var prefMap = new Dictionary<int, int>();
        prefMap[0] = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            curr += nums[i];
            curr %= k;
            if (curr < 0)
                curr += k;

            if (prefMap.ContainsKey(curr))
            {
                count += prefMap[curr];
                prefMap[curr] += 1;
            }
            else
            {
                prefMap[curr] = 1;
            }
        }
        return count;
    }


    // 1991. Find the Middle Index in Array
    public int FindMiddleIndex(int[] nums)
    {
        var n = nums.Length;
        if (n == 1)
            return 0;

        var pre = new int[nums.Length];
        var post = new int[nums.Length];

        pre[0] = nums[0];
        for (int i = 1; i < n; i++)
            pre[i] = pre[i - 1] + nums[i];

        post[^1] = nums[^1];
        for (int i = n - 2; i >= 0; i--)
            post[i] = post[i + 1] + nums[i];

        if (post[1] == 0)
            return 0;

        if (pre[^2] == 0)
            return n - 1;

        for (int i = 1; i < n - 1; i++)
            if (pre[i - 1] == post[i + 1])
                return i;

        return -1;
    }


    // 2057. Smallest Index With Equal Value
    public int SmallestEqual(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
            if (i % 10 == nums[i])
                return i;
        return -1;
    }


    // 2404. Most Frequent Even Element
    public int MostFrequentEven(int[] nums)
    {
        var evens = nums.Where(x => x % 2 == 0);
        if (!evens.Any())
            return -1;

        var grps = evens.GroupBy(x => x);
        var num = grps.FirstOrDefault().Key;
        var maxFreq = 0;

        foreach (var grp in grps)
        {
            var count = grp.Count();
            if (count > maxFreq
                || (count == maxFreq && grp.Key < num))
            {
                maxFreq = count;
                num = grp.Key;
            }
        }
        return num;
    }


    // 1356. Sort Integers by The Number of 1 Bits
    public int[] SortByBits(int[] arr)
    {
        int GetBits(int n)
        {
            var bits = 0;
            while (n > 0)
            {
                if ((n & 1) == 1)
                    bits++;
                n >>= 1;
            }
            return bits;
        }
        return arr.OrderBy(x => GetBits(x))
                  .ThenBy(x => x)
                  .ToArray();
    }


    // 997. Find the Town Judge
    public int FindJudge(int n, int[][] trust)
    {
        // naming: "vote" is a vote of trust
        var voted = new bool[n + 1];
        var voteCount = new int[n + 1];

        foreach (var vote in trust)
        {
            voted[vote[0]] = true;
            voteCount[vote[1]]++;
        }

        for (int i = 1; i <= n; i++)
        {
            // Find the possible judge and check their vote count
            if (!voted[i] && voteCount[i] == n - 1)
                return i;
        }

        return -1;
    }


    // 2496. Maximum Value of a String in an Array
    public int MaximumValue(string[] strs)
    {
        var maxScore = int.MinValue;

        foreach (var s in strs)
        {
            var score = int.TryParse(s, out var val)
                ? val
                : s.Length;

            maxScore = Math.Max(maxScore, score);
        }

        return maxScore;
    }


    // 2540. Minimum Common Value
    public int GetCommon(int[] nums1, int[] nums2)
    {
        var both = nums1.Intersect(nums2);
        if (both.Count() == 0)
            return -1;
        return both.Min();
    }


    // 2215. Find the Difference of Two Arrays
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        var ans = new List<IList<int>>();

        ans.Add(nums1.Except(nums2).Distinct().ToList());
        ans.Add(nums2.Except(nums1).Distinct().ToList());

        return ans;
    }


    // 229. Majority Element II
    public IList<int> MajorityElementII(int[] nums)
    {
        var numCount = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!numCount.TryAdd(num, 1))
            {
                numCount[num]++;
            }
        }

        var ans = new List<int>();
        var target = nums.Length / 3;
        return numCount.Where(x => x.Value > target)
                       .Select(x => x.Key)
                       .ToList();
    }


    // 1827. Minimum Operations to Make the Array Increasing
    public int MinOperations(int[] nums)
    {
        var count = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                var delta = nums[i - 1] - nums[i] + 1;
                nums[i] += delta;
                count += delta;
            }
        }
        return count;
    }


    // 953. Verifying an Alien Dictionary
    public bool IsAlienSorted(string[] words, string order)
    {
        var d = new Dictionary<char, int>();
        for (int i = 0; i < order.Length; i++)
            d[order[i]] = i;

        for (int i = 0; i < words.Length - 1; i++)
        {
            var len1 = words[i].Length;
            var len2 = words[i + 1].Length;
            var minLen = Math.Min(len1, len2);
            var equal = true;
            for (int j = 0; j < minLen; j++)
            {
                var idx1 = d[words[i][j]];
                var idx2 = d[words[i + 1][j]];

                // not sorted
                if (idx1 > idx2)
                    return false;
                // sorted, move to next word pair
                if (idx1 < idx2)
                {
                    equal = false;
                    break;
                }
            }
            // all letters up to minLen match, but
            // first word is longer than second word
            if (equal && len1 > len2)
                return false;
        }
        return true;
    }


    // 540. Single Element in a Sorted Array
    public int SingleNonDuplicate(int[] nums)
    {
        var xor = 0;
        foreach (var num in nums)
            xor ^= num;
        return xor;
    }


    // 274. H-Index
    public int HIndex(int[] citations)
    {
        Array.Sort(citations);
        int i = 0;
        int j = citations.Length - 1;

        while (i <= j)
        {
            int m = i + (j - i) / 2;

            if (citations[m] >= citations.Length - m)
                j = m - 1;
            else
                i = m + 1;
        }

        return citations.Length - i;
    }


    // 275. H-Index II
    public int HIndexII(int[] citations)
    {
        int i = 0;
        int j = citations.Length - 1;

        while (i <= j)
        {
            int m = i + (j - i) / 2;

            if (citations[m] >= citations.Length - m)
                j = m - 1;
            else
                i = m + 1;
        }

        return citations.Length - i;
    }


    // 438. Find All Anagrams in a String
    public IList<int> FindAnagrams(string s, string p)
    {
        var ans = new List<int>();
        var sd = new Dictionary<char, int>();
        var pd = new Dictionary<char, int>();
        foreach (var c in p)
        {
            sd[c] = 0;
            if (pd.ContainsKey(c))
                pd[c]++;
            else
                pd[c] = 1;
        }

        var need = p.Length;
        for (int i = 0; i < p.Length; i++)
        {
            if (sd.ContainsKey(s[i]))
            {
                sd[s[i]]++;
                if (sd[s[i]] <= pd[s[i]])
                    need--;
            }
        }

        if (need == 0)
            ans.Add(0);

        for (int i = 1, j = p.Length; j < s.Length; i++, j++)
        {

            if (sd.ContainsKey(s[i - 1]))
            {
                var lastChar = s[i - 1];
                sd[lastChar]--;
                if (sd[lastChar] < pd[lastChar])
                    need++;
            }

            if (sd.ContainsKey(s[j]))
            {
                var nextChar = s[j];
                sd[nextChar]++;
                if (sd[nextChar] <= pd[nextChar])
                    need--;
            }

            if (need == 0)
                ans.Add(i);
        }

        return ans;
    }


    // 2554. Maximum Number of Integers to Choose From a Range I
    public int MaxCount(int[] banned, int n, int maxSum)
    {
        var nums = Enumerable.Range(1, n).Except(banned).ToArray();
        var sum = 0;
        var count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (sum + nums[i] <= maxSum)
            {
                sum += nums[i];
                count++;
            }
            else
            {
                break;
            }
        }
        return count;
    }


    // 2553. Separate the Digits in an Array
    public int[] SeparateDigits(int[] nums)
    {
        var ans = new List<int>();
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            var n = nums[i];
            while (n > 0)
            {
                ans.Add(n % 10);
                n /= 10;
            }
        }
        ans.Reverse();
        return ans.ToArray();
    }


    // 1461. Check If a String Contains All Binary Codes of Size K
    public bool HasAllCodes(string s, int k)
    {
        var hs = new HashSet<int>();
        for (int i = 0; i <= s.Length - k; i++)
        {
            hs.Add(Convert.ToInt32(s.Substring(i, k), 2));
        }

        var limit = (int)Math.Pow(2, k);
        for (int i = 0; i < limit; i++)
        {
            if (!hs.Contains(i))
                return false;
        }
        return true;
    }

    // TODO: This fails test case { 3,4,2,3 }
    // 665. Non-decreasing Array
    public bool CheckPossibility(int[] nums)
    {
        var changed = false;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] <= nums[i + 1])
                continue;

            if (changed)
                return false;

            if (i == 0 || nums[i + 1] >= nums[i - 1])
                nums[i] = nums[i + 1];
            else
                nums[i + 1] = nums[i];

            changed = true;
        }
        return true;
    }


    // 2306. Naming a Company
    public long DistinctNames(string[] ideas)
    {
        var suffixes = new HashSet<string>[26];
        for (int i = 0; i < 26; i++)
            suffixes[i] = new HashSet<string>();

        foreach (var idea in ideas)
            suffixes[idea[0] - 'a'].Add(idea.Substring(1));

        long result = 0;
        for (int i = 0; i < 25; ++i)
        {
            var iCount = suffixes[i].Count;
            for (int j = i + 1; j < 26; ++j)
            {
                long common = suffixes[i].Intersect(suffixes[j]).Count();
                var jCount = suffixes[j].Count;
                result += 2 * (iCount - common) * (jCount - common); ;
            }
        }
        return result;
    }


    // 122. Best Time to Buy and Sell Stock II
    public int MaxProfit(int[] prices)
    {
        var profit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            var delta = prices[i] - prices[i - 1];
            if (delta > 0)
                profit += delta;
        }

        return profit;
    }


    //561. Array Partition
    public int ArrayPairSum(int[] nums)
    {
        Array.Sort(nums);
        return nums.Where(x => x % 2 == 0).Sum();
    }


    // 523. Continuous Subarray Sum
    // TODO: I fucking hated this problem. Revisit and simplify.
    // Notes to self:
    // This solution started with half the present lines of code.
    // Then I hit edge case after edge case. I looked at other
    // solutions afterward, and they look very similar to how
    // this one started. Obviously I missed somthing, so I need
    // to re-think this type of problem.
    public bool CheckSubarraySum(int[] nums, int k)
    {
        // edge cases
        if (nums.Length == 1)
            return false;

        // Create prefix sum
        var prefixes = new int[nums.Length];
        prefixes[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
            prefixes[i] = nums[i] + prefixes[i - 1];

        // If two (or more) prefix sums have the same % k value,
        // then the subrray between them is divisible by k.
        var remainderCounts = new Dictionary<int, int>();
        for (int i = 0; i < prefixes.Length; i++)
        {
            var remainder = prefixes[i] % k;

            // If remau=inder is zero then it's a straight
            // division by k
            if (remainder == 0 && i > 0)
                return true;

            // If the key already exists, then there is
            // a subarray divisible by k with a length >= 2
            if (remainderCounts.ContainsKey(remainder))
            {
                if (nums[i] != 0 && nums[i] % k != 0)
                    return true;
                if (i > 0 && nums[i] == 0 && nums[i - 1] == 0)
                    return true;
                if (i > 0 && nums[i - 1] == 0 && nums[i] % k == 0)
                    return true;

                remainderCounts[remainder]++;
            }

            remainderCounts[remainder] = 1;
        }

        return false;
    }


    // 1051. Height Checker
    public int HeightChecker(int[] heights)
    {
        var expected = new int[heights.Length];
        Array.Copy(heights, expected, heights.Length);
        Array.Sort(expected);

        var count = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            if (heights[i] != expected[i])
                count++;
        }

        return count;
    }


    // 2295. Replace Elements in an Array
    public int[] ArrayChange(int[] nums, int[][] operations)
    {
        var d = new Dictionary<int, HashSet<int>>();
        var res = new int[nums.Length];
        Array.Copy(nums, res, nums.Length);

        for (int i = 0; i < nums.Length; i++)
        {
            if (!d.ContainsKey(nums[i]))
                d[nums[i]] = new HashSet<int>();
            d[nums[i]].Add(i);
        }

        foreach (var operation in operations)
        {
            var indices = d[operation[0]];
            foreach (var index in indices)
            {
                res[index] = operation[1];
                if (!d.ContainsKey(res[index]))
                    d[res[index]] = new HashSet<int>();
                d[res[index]].Add(index);
                d[operation[0]].Remove(index);
            }
        }
        return res;
    }


    // 794. Valid Tic-Tac-Toe State
    public bool ValidTicTacToe(string[] board)
    {
        var countX = 0;
        var countO = 0;
        var xRowWins = 0;
        var oRowWins = 0;
        var xColWins = 0;
        var oColWins = 0;

        foreach (var row in board)
        {
            if (row.Length != 3)
                return false;

            if (row == "XXX")
                xRowWins++;
            else if (row == "OOO")
                oRowWins++;

            foreach (var c in row)
            {
                if (c == 'X')
                    countX++;
                else if (c == 'O')
                    countO++;
            }
        }

        if (xRowWins > 1 || oRowWins > 1)
            return false;
        if (xRowWins == 1 && oRowWins == 1)
            return false;

        for (int c = 0; c < 3; c++)
        {
            if (board[0][c] == board[1][c] && board[1][c] == board[2][c])
            {
                if (board[0][c] == 'X')
                    xColWins++;
                else if (board[0][c] == 'O')
                    oColWins++;
            }
        }

        var xDiagWins = 0;
        var oDiagWins = 0;
        if (board[0][0] == board[1][1] && board[1][1] == board[2][2])
        {
            if (board[0][0] == 'X')
                xDiagWins++;
            else if (board[0][0] == 'O')
                oDiagWins++;
        }
        if (board[0][2] == board[1][1] && board[1][1] == board[2][0])
        {
            if (board[0][2] == 'X')
                xDiagWins++;
            else if (board[0][2] == 'O')
                oDiagWins++;
        }

        if (xColWins > 1 || oColWins > 1)
            return false;
        if (xColWins == 1 && oColWins == 1)
            return false;

        if (countO > countX || countX - countO > 1)
            return false;

        if (oColWins + oRowWins + oDiagWins > 0 && countX > countO)
            return false;

        if (countX == countO && (xRowWins + xColWins + xDiagWins > 0))
            return false;

        return true;
    }


    // 989. Add to Array-Form of Integer
    public IList<int> AddToArrayForm(int[] num, int k)
    {
        // 2,1,5 806
        var res = new List<int>();

        var carry = 0;
        var i = num.Length - 1;
        while (k > 0 && i >= 0)
        {
            var val = carry + num[i] + k % 10;
            res.Add(val % 10);
            carry = val / 10;
            k /= 10;
            i--;
        }

        while (k > 0)
        {
            var val = carry + k % 10;
            res.Add(val % 10);
            carry = val / 10;
            k /= 10;
        }

        while (i >= 0)
        {
            var val = carry + num[i];
            res.Add(val % 10);
            carry = val / 10;
            i--;
        }

        if (carry > 0)
            res.Add(carry);

        res.Reverse();
        return res;
    }


    // 187. Repeated DNA Sequences
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        if (s.Length <= 10)
            return new List<string>();

        var res = new HashSet<string>();
        var hs = new HashSet<string>();
        Span<char> dna = s.ToCharArray();
        var i = 0;
        var j = 10;
        while (j <= s.Length)
        {
            var seq = dna.Slice(i, j - i).ToString();
            // 2 hashsets - first detects duplicates,
            // and second ensures unique results
            if (!hs.Add(seq))
                res.Add(seq);
            i++;
            j++;
        }

        return res.ToList();
    }


    // 2089. Find Target Indices After Sorting Array
    public IList<int> TargetIndices(int[] nums, int target)
    {
        var res = new List<int>();
        Array.Sort(nums);
        var index = Array.BinarySearch(nums, target);
        if (index < 0)
            return res;

        var i = index;
        while (i >= 0 && nums[i] == target)
        {
            res.Add(i);
            i--;
        }

        i = index + 1;
        while (i < nums.Length && nums[i] == target)
        {
            res.Add(i);
            i++;
        }
        res.Sort();
        return res;
    }


    // 565. Array Nesting
    public int ArrayNesting(int[] nums)
    {
        var hs = new HashSet<int>();
        var maxCount = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var val = nums[i];
            int count = 0;

            while (hs.Add(val))
            {
                count++;
                i = val;
                val = nums[i];
            }
            if (count > maxCount)
                maxCount = count;
        }
        return maxCount;
    }


    // 1823. Find the Winner of the Circular Game
    public int FindTheWinner(int n, int k)
    {
        var q = new Queue<int>();
        for (int i = 1; i <= n; i++)
            q.Enqueue(i);

        while (q.Count > 1)
        {
            var count = k;
            while (count > 0)
            {
                q.Enqueue(q.Dequeue());
                count--;
            }
            _ = q.Dequeue();
        }
        return q.Dequeue();
    }


    // 950. Reveal Cards in Increasing Order
    public int[] DeckRevealedIncreasing(int[] deck)
    {
        Array.Sort(deck);
        var q = new Queue<int>(Enumerable.Range(0, deck.Length));
        var res = new int[deck.Length];

        foreach (var card in deck)
        {
            res[q.Dequeue()] = card;
            if (q.Count > 0)
                q.Enqueue(q.Dequeue());
        }
        return res;
    }


    // 1347. Minimum Number of Steps to Make Two Strings Anagram
    public int MinSteps(string s, string t)
    {
        var ds = new Dictionary<char, int>();
        var dt = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (ds.TryGetValue(s[i], out var val))
                ds[s[i]] = val + 1;
            else
                ds[s[i]] = 1;
        }
        for (int i = 0; i < t.Length; i++)
        {
            if (dt.TryGetValue(t[i], out var val))
                dt[t[i]] = val + 1;
            else
                dt[t[i]] = 1;
        }

        var need = 0;
        foreach (var kvp in ds)
        {
            if (dt.ContainsKey(kvp.Key))
                need += Math.Max(0, kvp.Value - dt[kvp.Key]);
            else
                need += kvp.Value;
        }

        return need;
    }
}
