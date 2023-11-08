using System.Data;
using System.Text;

namespace LeetcodeGrind.ArraysAndHashing;

public class ArraysAndHashing
{
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
