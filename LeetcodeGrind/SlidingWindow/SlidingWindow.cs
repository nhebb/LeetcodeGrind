﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.SlidingWindow;

internal class SlidingWindow
{
    // TODO: finish this
    //1838. Frequency of the Most Frequent Element
    public int MaxFrequency(int[] nums, int k)
    {
        if (nums.Length == 1) return 1;

        var max = 1;
        int i = 0;
        int j = 1;
        var sum = nums[0];
        var delta = Math.Abs(nums[j]-nums[i]);

        while (j < nums.Length)
        {

        }

        return max;
    }


    // 121. Best Time to Buy and Sell Stock
    public int MaxProfit(int[] prices)
    {
        int lowestPrice = int.MaxValue;
        int maxProfit = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            lowestPrice = Math.Min(lowestPrice, prices[i]);
            int currentProfit = prices[i] - lowestPrice;
            maxProfit = Math.Max(maxProfit, currentProfit);
        }
        return maxProfit;
    }


    // 3. Longest Substring Without Repeating Characters
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s)) { return 0; }

        var hs = new HashSet<char>();
        int max = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int len = 0;
            for (int j = i; j < s.Length; j++)
            {
                if (!hs.Add(s[j]))
                {
                    break;
                }
                len++;
            }
            max = Math.Max(max, len);
            hs.Clear();
        }
        return max;
    }


    // 424. Longest Repeating Character Replacement
    public int CharacterReplacement(string s, int k)
    {
        var abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var abcCount = new Dictionary<char, int>();
        foreach (char c in abc)
            abcCount[c] = 0;

        int max = 0;
        int i = 0;
        int j = 0;
        while (j < s.Length)
        {
            abcCount[s[j]]++;
            if (j - i + 1 - abcCount.Values.Max() > k)
            {
                abcCount[s[i]]--;
                i++;
            }
            max = Math.Max(max, j - i + 1);
            j++;
        }

        return max;
    }


    // 567. Permutation in String
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        if (s2.Contains(s1))
            return true;

        var counts1 = new Dictionary<char, int>();
        var counts2 = new Dictionary<char, int>();

        foreach (var c in s1)
        {
            if (!counts1.TryAdd(c, 1))
                counts1[c]++;
        }

        foreach (var c in s2.Substring(0, s1.Length))
        {
            if (!counts2.TryAdd(c, 1))
                counts2[c]++;
        }

        bool isMatch = true;
        foreach (var kvp in counts1)
        {
            if (!counts2.ContainsKey(kvp.Key) ||
                counts2[kvp.Key] != kvp.Value)
            {
                isMatch = false;
                break;
            }
        }
        if (isMatch) return true;

        for (int i = 1, j = s1.Length; j < s2.Length; i++, j++)
        {
            counts2[s2[i - 1]]--;
            if (!counts2.TryAdd(s2[j], 1))
                counts2[s2[j]]++;

            isMatch = true;
            foreach (var kvp in counts1)
            {
                if (!counts2.ContainsKey(kvp.Key) ||
                    counts2[kvp.Key] != kvp.Value)
                {
                    isMatch = false;
                    break;
                }
            }
            if (isMatch) return true;
        }
        return false;
    }


    // 76. Minimum Window Substring
    public string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(t)) return "";

        var window = new Dictionary<char, int>();
        var countT = new Dictionary<char, int>();

        foreach (char c in t)
        {
            if (!countT.ContainsKey(c))
                countT[c] = 0;
            countT[c]++;
        }

        var need = countT.Keys.Count;
        var have = 0;
        var resLen = s.Length + 1;
        var res = new int[] { -1, -1 };
        //var i = 0;
        var i = 0;

        for (int j = 0; j < s.Length; j++)
        {
            char c = s[j];
            if (!window.ContainsKey(c))
                window[c] = 0;
            window[c]++;

            if (countT.ContainsKey(c) && window[c] == countT[c])
                have++;

            while (have == need)
            {
                if (j - i + 1 < resLen)
                {
                    res[0] = i;
                    res[1] = j;
                    resLen = j - i + 1;
                }

                window[s[i]]--;
                if (countT.ContainsKey(s[i]) && window[s[i]] < countT[s[i]])
                    have--;
                i++;
            }
        }
        if (resLen <= s.Length)
            return s.Substring(res[0], res[1] - res[0] + 1);
        return "";
    }


    // 239. Sliding Window Maximum
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (k == 1) return nums;

        var d = new Dictionary<int, int>();
        var pq = new PriorityQueue<int, long>();
        var res = new List<int>();

        for (int i = 0; i < k; i++)
        {
            if (!d.TryAdd(nums[i], 1))
                d[nums[i]]++;
            pq.Enqueue(nums[i], -nums[i]);
        }
        res.Add(pq.Peek());

        for (int i = 1, j = k; j < nums.Length; i++, j++)
        {
            d[nums[i - 1]]--;
            while (d[pq.Peek()] == 0)
                _ = pq.Dequeue();
            if (!d.TryAdd(nums[j], 1))
                d[nums[j]]++;
            pq.Enqueue(nums[j], -nums[j]);
            res.Add(pq.Peek());
        }

        return res.ToArray();
    }
}
