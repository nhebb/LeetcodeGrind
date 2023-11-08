﻿using System.Data;
using System.Text;

namespace LeetcodeGrind.ArraysAndHashing;

public class ArraysAndHashing
{
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

    // TODO: 665. Non-decreasing Array
    // This fails test case { 3,4,2,3 }
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

        // make hashset of names by first letter
        foreach (var idea in ideas)
            suffixes[idea[0] - 'a'].Add(idea.Substring(1));

        long result = 0;

        // compare each hashset to the other hashsets
        for (int i = 0; i < 25; i++)
        {
            var iCount = suffixes[i].Count;
            for (int j = i + 1; j < 26; j++)
            {
                // get the count of common suffixes
                long common = suffixes[i].Intersect(suffixes[j]).Count();
                var jCount = suffixes[j].Count;

                // unique suffixes in 1st set x unique suffixes in 2nd 
                // set x 2 for order swap (e.g., Tin, Man => MinTan, TanMin)
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


    // 575. Distribute Candies
    public int DistributeCandies(int[] candyType)
    {
        var hs = candyType.ToHashSet();
        return Math.Min(hs.Count, candyType.Length / 2);
    }


    // 747. Largest Number At Least Twice of Others
    public int DominantIndex(int[] nums)
    {
        var max = int.MinValue;
        var maxIndex = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
                maxIndex = i;
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] * 2 > max)
            {
                return -1;
            }
        }
        return maxIndex;
    }


    // 521. Longest Uncommon Subsequence I
    public int FindLUSlength(string a, string b)
    {
        return a == b
            ? -1
            : Math.Max(a.Length, b.Length);
    }


    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        int count = 0;
        int q = 0;
        int product = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            // 1. Calculate product
            product *= nums[i];

            // 2. While the product is > target, increase left.
            while (product >= k && q < i)
            {
                product /= nums[q];
                q++;
            }
        }
        return count;
    }


    // 1980. Find Unique Binary String
    public string FindDifferentBinaryString(string[] nums)
    {
        var vals = nums.Select(x => Convert.ToInt32(x, 2));
        var max = vals.Max();
        var all = Enumerable.Range(0, max + 1);
        var missing = all.Except(vals);

        var len = nums[0].Length;
        return missing.Count() == 0
            ? Convert.ToString((max + 1), 2).PadLeft(len, '0')
            : Convert.ToString(missing.First(), 2).PadLeft(len, '0');
    }


    // 2283. Check if Number Has Equal Digit Count and Digit Value
    public bool DigitCount(string num)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < num.Length; i++)
        {
            var number = num[i] - '0';
            if (d.TryGetValue(number, out int count))
                d[number] = count + 1;
            else
                d[number] = 1;
        }

        for (int i = 0; i < num.Length; i++)
        {
            var count = d.ContainsKey(i) ? d[i] : 0;
            var val = num[i] - '0';
            if (val != count)
                return false;
        }
        return true;
    }


    // 1590. Make Sum Divisible by P
    public int MinSubarray(int[] nums, int p)
    {
        // The goal is to remove a minimal subarray that makes the remaining 
        // array sum divisible by p. Take the total and calculate the 
        // remainder => nums.Sum() % p. The subarray must sum to 
        // remainder + x * p, where x is unknown.

        // Calculate the remainder for the total sum by adding
        // each num and taking the modulus. (Prevents overflow.)
        var overallRemainder = 0;
        foreach (int num in nums)
            overallRemainder = (overallRemainder + num) % p;

        if (overallRemainder == 0)
            return 0;

        // Calculate the running prefix sum for each position the same way
        // we calculated the overall remainder. Store the mod value in a hash table
        // with the index.
        var modToIndexMap = new Dictionary<int, int>();

        var minLen = nums.Length;
        var remainder = 0;
        modToIndexMap[remainder] = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            remainder = (remainder + nums[i]) % p;

            // We are working left to right, so it's ok to overwrite the
            // last value since we want the nearest index to our current position
            modToIndexMap[remainder] = i;

            // Subtract the overall remainder from the current remainder, then
            // add p to ensure it's > 0. Then, take the modulus so the value
            // 0 <= key < p
            int key = (remainder - overallRemainder + p) % p;

            // When a matching key is found, it indicates that the subarray
            // between the indices sums to remainder + x * p
            if (modToIndexMap.ContainsKey(key))
                minLen = Math.Min(minLen, i - modToIndexMap[key]);
        }

        return minLen == nums.Length ? -1 : minLen;
    }


    // 383. Ransom Note
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var dm = new Dictionary<char, int>();
        for (int i = 0; i < magazine.Length; i++)
        {
            if (dm.TryGetValue(magazine[i], out int val))
                dm[magazine[i]] = val + 1;
            else
                dm[magazine[i]] = 1;
        }

        for (int i = 0; i < ransomNote.Length; i++)
        {
            if (dm.TryGetValue(ransomNote[i], out int val))
            {
                dm[ransomNote[i]] = val - 1;
                if (dm[ransomNote[i]] == 0)
                    dm.Remove(ransomNote[i]);
            }
            else
            {
                return false;
            }
        }
        return true;
    }


    // 387. First Unique Character in a String
    public int FirstUniqChar(string s)
    {
        var counts = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (counts.TryGetValue(s[i], out var val))
                counts[s[i]] = val + 1;
            else
                counts[s[i]] = 1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (counts[s[i]] == 1)
                return i;
        }

        return -1;
    }


    // 912. Sort an Array
    public int[] SortArray(int[] nums)
    {
        void Quicksort(int lo, int hi)
        {
            if (lo < hi)
            {
                var p = Partition(lo, hi);
                Quicksort(lo, p - 1);
                Quicksort(p + 1, hi);
            }
        }

        int Partition(int lo, int hi)
        {
            var pivot = nums[hi];
            var i = lo;

            for (int j = lo; j <= hi - 1; j++)
            {
                if (nums[j] <= pivot)
                {
                    i++;
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }

            i++;
            (nums[i], nums[hi]) = (nums[hi], nums[i]);

            return i;
        }

        Quicksort(0, nums.Length - 1);
        return nums;
    }


    // 324. Wiggle Sort II
    public void WiggleSort(int[] nums)
    {
        int len = nums.Length;
        var mid = (len + 1) / 2;
        var sorted = new int[len];
        Array.Copy(nums, sorted, len);
        Array.Sort(sorted);

        var i = mid - 1;
        var j = 0;
        while (i >= 0)
        {
            nums[j] = sorted[i];
            i--;
            j += 2;
        }

        i = len - 1;
        j = 1;
        while (i >= mid)
        {
            nums[j] = sorted[i];
            i--;
            j += 2;
        }
    }


    // 218. The Skyline Problem
    public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        var ans = new List<IList<int>>();
        if (buildings.Length == 1)
        {
            ans.Add(new List<int>() { buildings[0][0], buildings[0][2] });
            ans.Add(new List<int>() { buildings[0][1], 0 });
        }

        var min = int.MaxValue;
        var max = int.MinValue;

        for (int i = 0; i < buildings.Length; i++)
        {
            if (buildings[i][0] < min)
                min = buildings[i][0];
            if (buildings[i][1] > max)
                max = buildings[i][1];
        }

        var dx = max - min;
        var heights = new int[dx + 1];
        for (int i = 0; i < buildings.Length; i++)
        {
            long l = buildings[i][0] - min;
            long r = buildings[i][1] - min;
            for (long j = l; j < r; j++)
                heights[j] = Math.Max(heights[j], buildings[i][2]);
        }

        for (int i = 0; i < heights.Length; i++)
        {
            if (i == 0 && heights[i] > 0)
                ans.Add(new List<int>() { (int)min, heights[i] });
            else if (i > 0 && heights[i] != heights[i - 1])
                ans.Add(new List<int>() { (int)(i + min), heights[i] });
        }

        return ans;
    }


    // 2444. Count Subarrays With Fixed Bounds
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        var minFound = false;
        var maxFound = false;

        var firstValidIndex = 0;
        var minIndex = 0;
        var maxIndex = 0;
        long count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > maxK || nums[i] < minK)
            {
                minFound = false;
                maxFound = false;
                firstValidIndex = i + 1;
            }

            if (nums[i] == minK)
            {
                minIndex = i;
                minFound = true;
            }

            if (nums[i] == maxK)
            {
                maxIndex = i;
                maxFound = true;
            }

            if (minFound && maxFound)
            {
                count += Math.Min(minIndex, maxIndex) - firstValidIndex + 1;
            }
        }

        return count;
    }


    // 1345. Jump Game IV
    public int MinJumps(int[] arr)
    {
        var n = arr.Length;
        var dict = new Dictionary<int, HashSet<int>>();

        for (int i = 0; i < n; i++)
        {
            if (!dict.ContainsKey(arr[i]))
            {
                dict[arr[i]] = new HashSet<int>();
            }

            dict[arr[i]].Add(i);
        }

        var visited = new bool[n];
        visited[0] = true;
        var q = new Queue<(int, int)>();
        q.Enqueue((0, 0));

        while (q.Count > 0)
        {
            var (curIndex, count) = q.Dequeue();

            var curVal = arr[curIndex];

            if (curIndex == n - 1)
            {
                return count;
            }

            if (arr[^1] == curVal)
            {
                return count + 1;
            }

            if (curIndex > 0 && !visited[curIndex - 1])
            {
                visited[curIndex - 1] = true;
                q.Enqueue((curIndex - 1, count + 1));

                if (n - 1 == curIndex - 1)
                {
                    return count + 1;
                }
            }

            if (curIndex < n && !visited[curIndex + 1])
            {
                visited[curIndex + 1] = true;
                q.Enqueue((curIndex + 1, count + 1));

                if (n - 1 == curIndex + 1)
                {
                    return count + 1;
                }
            }

            foreach (var i in dict[curVal])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    q.Enqueue((i, count + 1));

                    if (n - 1 == i)
                    {
                        return count + 1;
                    }
                }
            }

            dict[curVal] = new HashSet<int>();
        }

        return n;
    }


    // 1539. Kth Missing Positive Number
    public int FindKthPositive(int[] arr, int k)
    {
        if (k < arr[0])
            return k;
        var last = arr[^1];
        var vals = Enumerable.Range(1, last);
        var missing = vals.Except(arr).ToArray();

        if (missing.Length >= k)
            return missing[k - 1];
        else
            return arr[^1] + k - missing.Length;
    }


    // 2187. Minimum Time to Complete Trips
    public long MinimumTime(int[] time, int totalTrips)
    {
        var minTime = time.Min();

        if (totalTrips == 1)
            return minTime;

        if (time.Length == 1)
            return (long)1.0 * totalTrips * time[0];

        long left = minTime;
        long right = (long)totalTrips * minTime;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            // how many trips can be made in elapsed time
            var trips = time.Sum(t => mid / (long)t);

            if (trips >= totalTrips)
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }


    // 2348. Number of Zero-Filled Subarrays
    public long ZeroFilledSubarray(int[] nums)
    {
        var zeroArraylengths = new List<long>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                long len = 1;
                i++;
                while (i < nums.Length && nums[i] == 0)
                {
                    len++;
                    i++;
                }
                zeroArraylengths.Add(len);
                i--;
            }
        }
        long count = 0;
        foreach (var n in zeroArraylengths)
        {
            count += n * (n + 1) / 2;
        }
        return count;
    }
    public long ZeroFilledSubarray2(int[] nums)
    {
        long count = 0;
        long sequence = 0;
        foreach (var num in nums)
        {
            if (num == 0)
                sequence++;
            else
                sequence = 0;
            count += sequence;
        }
        return count;
    }


    // 1431. Kids With the Greatest Number of Candies
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var maxCandies = candies[0];
        for (int i = 1; i < candies.Length; i++)
        {
            maxCandies = Math.Max(candies[i], maxCandies);
        }

        var ans = new bool[candies.Length];
        for (int i = 0; i < candies.Length; i++)
        {
            ans[i] = candies[i] + extraCandies >= maxCandies;
        }

        return ans;
    }


    // 1929. Concatenation of Array
    public int[] GetConcatenation(int[] nums)
    {
        var n = nums.Length;
        var ans = new int[n * 2];

        // slowest
        //Array.Copy(nums, 0, ans, 0, n);
        //Array.Copy(nums, 0, ans, n, n);

        // slower
        //nums.CopyTo(ans, 0);
        //nums.CopyTo(ans, n);

        // faster
        for (int i = 0; i < n; i++)
        {
            ans[i] = nums[i];
            ans[i + n] = nums[i];
        }
        return ans;
    }


    // 649. Dota2 Senate
    public string PredictPartyVictory(string senate)
    {
        var q = new Queue<char>();
        var dCount = 0;
        var rCount = 0;

        for (int i = 0; i < senate.Length; i++)
        {
            q.Enqueue(senate[i]);
            if (senate[i] == 'D')
                dCount++;
            else
                rCount++;
        }

        var dSkip = 0;
        var rSkip = 0;
        while (q.Count > 0 && dCount > 0 && rCount > 0)
        {
            var senator = q.Dequeue();
            if (senator == 'D')
            {
                if (dSkip > 0)
                {
                    dSkip--;
                    dCount--;
                }
                else
                {
                    rSkip++;
                    q.Enqueue(senator);
                }
            }
            else
            {
                if (rSkip > 0)
                {
                    rSkip--;
                    rCount--;
                }
                else
                {
                    dSkip++;
                    q.Enqueue(senator);
                }
            }

        }

        return dCount > 0 ? "Dire" : "Radiant";
    }


    // 68. Text Justification
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        var result = new List<string>();
        var lines = new List<(IList<string> items, int len)>();
        for (int i = 0; i < words.Length; i++)
        {
            var line = new List<string>();
            var lineLength = 0;
            var spaces = 0;
            var j = i;
            while (j < words.Length && words[j].Length + spaces + lineLength < maxWidth)
            {
                line.Add(words[j]);
                lineLength += words[j].Length;
                spaces++;
                j++;
            }
            lines.Add((line, lineLength));
            i = j - 1; // backstep to account for i increment
        }

        // handle lines up to last line
        var sb = new StringBuilder();
        for (int i = 0; i < lines.Count - 1; i++)
        {
            var len = lines[i].len;
            var items = lines[i].items;

            if (items.Count == 1)
            {
                sb.Append(items[0]);
                sb.Append(new String(' ', maxWidth - len));
            }
            else
            {
                var numGaps = items.Count - 1;
                var totalSpaces = maxWidth - len;
                var gapWidth = totalSpaces / numGaps;
                var extraSpaces = totalSpaces % numGaps;
                var padding = new String(' ', gapWidth);

                for (int j = 0; j < items.Count; j++)
                {
                    sb.Append(items[j]);
                    if (j < items.Count - 1)
                    {
                        sb.Append(padding);
                        if (extraSpaces > 0)
                        {
                            sb.Append(' ');
                            extraSpaces--;
                        }
                    }
                }
            }
            result.Add(sb.ToString());
            sb.Clear();
        }

        // handle last line
        sb.Append(string.Join(' ', lines[^1].items));
        var rightPadding = maxWidth - sb.Length;
        sb.Append(new string(' ', rightPadding));
        result.Add(sb.ToString());

        return result;
    }


    // 1027. Longest Arithmetic Subsequence
    public int LongestArithSeqLength(int[] nums)
    {
        var max = 1;
        var i = 0;
        var j = 1;
        while (j < nums.Length)
        {
            var delta = nums[j] - nums[i];
            while (j < nums.Length && nums[j] - nums[j - 1] == delta)
            {
                j++;
            }
            var len = j - i;
            max = Math.Max(max, len);
            i = j;
            j++;
        }

        return max;
    }


    // 1493. Longest Subarray of 1's After Deleting One Element
    public int LongestSubarray(int[] nums)
    {
        var inOnes = false;     // tracks whether we are in consecutive 1's
        var onesCount = 0;      // current 1's count
        var lastOnesCount = 0;  // previous 1's count
        var maxOnes = 0;        // longest pair of subarrays separated by 1 character
        var maxStreak = 0;      // max contiguous subarray of 1's
        var nonOnesCount = 0;   // current non-one characters count
        var lastNonOnesCount = 0;   // previous non-one character count

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                onesCount++;
                if (!inOnes)
                {
                    inOnes = true;
                    if (nonOnesCount == 1)
                    {

                    }
                    lastNonOnesCount = nonOnesCount;
                    nonOnesCount = 0;
                }
            }
            else
            {
                if (inOnes)
                {
                    inOnes = false;
                    maxStreak = Math.Max(maxStreak, onesCount);
                    lastOnesCount = onesCount;
                }
                else
                {

                }
            }
        }

        return Math.Max(maxOnes, maxStreak - 1);
    }


    // 2549. Count Distinct Numbers on Board
    public int DistinctIntegers(int n)
    {
        var board = new HashSet<int>() { n };
        var cache = new HashSet<int>();

        for (int i = 2; i <= n; i++)
        {
            foreach (var num in board)
            {
                if (num % i == 1)
                    cache.Add(num);
            }
            foreach (var num in cache)
            {
                board.Add(num);
            }
            cache.Clear();
        }

        return board.Count;
    }


    // 2384. Largest Palindromic Number
    public string LargestPalindromic(string num)
    {
        var nums = new int[10];
        foreach (var c in num)
            nums[c - '0']++;

        var maxSingle = -1;
        var sb = new StringBuilder();

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            while (nums[i] > 1)
            {
                if (i > 0)
                    sb.Append(i);
                else
                    break;

                nums[i] -= 2;
            }

            if (nums[i] > 0)
                maxSingle = Math.Max(maxSingle, i);
        }

        if (sb.Length == 0)
            return maxSingle.ToString();

        var sVal = sb.ToString();

        if (maxSingle >= 0)
            sVal = sVal + maxSingle.ToString() + string.Join("", sVal.Reverse());
        else
            sVal = sVal + string.Join("", sVal.Reverse());

        return sVal;
    }


    // 2038. Remove Colored Pieces if Both Neighbors are the Same Color
    public bool WinnerOfGame(string colors)
    {
        var i = 0;
        var countA = 0;
        var countB = 0;

        while (i < colors.Length)
        {
            var count = 0;
            while (i < colors.Length && colors[i] == 'A')
            {
                count++;
                i++;
            }
            if (count > 2)
                countA += count - 2;

            count = 0;
            while (i < colors.Length && colors[i] == 'B')
            {
                count++;
                i++;
            }
            if (count > 2)
                countB += count - 2;
        }

        return countA > countB;
    }


    // 2009. Minimum Number of Operations to Make Array Continuous
    public int MinOperations2(int[] nums)
    {
        var unique = nums.ToHashSet().OrderBy(x => x).ToArray();
        var len = nums.Length;
        var ans = len;

        int j = 0;
        for (int i = 0; i < unique.Length; i++)
        {
            // j is essentially counting the number of items
            // that need to change to be continuous.
            while (j < unique.Length
                && unique[j] < unique[i] + len)
            {
                j++;
            }

            int diff = j - i;

            // take min in case incrementing goes past length needed.
            ans = Math.Min(ans, len - diff);
        }

        return ans;
    }


    // 2251. Number of Flowers in Full Bloom
    public int[] FullBloomFlowers(int[][] flowers, int[] people)
    {
        var d = new Dictionary<int, int>();

        for (int i = 0; i < people.Length; i++)
        {
            d[people[i]] = 0;
        }

        foreach (var flower in flowers)
        {
            for (int time = flower[0]; time <= flower[1]; time++)
            {
                if (d.ContainsKey(time))
                {
                    d[flower[time]]++;
                }
            }
        }

        var ans = new int[people.Length];
        for (int i = 0; i < ans.Length; i++)
        {
            ans[i] = d[people[i]];
        }

        return ans;
    }
}
