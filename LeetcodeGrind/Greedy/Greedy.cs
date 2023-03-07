using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Greedy;

public class Greedy
{
    // 53. Maximum Subarray
    public int MaxSubArray(int[] nums)
    {
        var maxSum = nums[0];
        var currentMaxSum = maxSum;

        for (int i = 1; i < nums.Length; i++)
        {
            currentMaxSum = Math.Max(currentMaxSum + nums[i], nums[i]);
            maxSum = Math.Max(maxSum, currentMaxSum);
        }
        return maxSum;
    }


    // 55. Jump Game
    public bool CanJump(int[] nums)
    {
        var target = nums.Length - 1;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (i + nums[i] >= target)
                target = i;
        }
        return target == 0;
    }


    // 45. Jump Game II
    public int Jump(int[] nums)
    {
        if (nums.Length == 1) return 0;

        var jumps = 0;
        var maxJumps = nums.Max();
        var target = nums.Length - 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            var minIndex = Math.Max(0, i - maxJumps);
            var nextTarget = target;
            for (int j = i; j >= minIndex; j--)
            {
                if (nums[j] + j >= target)
                {
                    i = j;
                    nextTarget = j;
                }
            }
            target = nextTarget;
            jumps++;
        }
        return jumps;
    }


    // 846. Hand of Straights
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
            return false;

        var pq = new PriorityQueue<int, int>();
        var d = new Dictionary<int, int>();

        foreach (var card in hand)
        {
            if (d.ContainsKey(card))
            {
                d[card]++;
            }
            else
            {
                d[card] = 1;
                pq.Enqueue(card, card);
            }
        }

        var count = 0;
        while (pq.Count > 0)
        {
            count = 0;
            var nextCard = pq.Peek();
            while (count < groupSize)
            {
                if (!d.ContainsKey(nextCard))
                    return false;

                d[nextCard]--;
                if (d[nextCard] == 0)
                    _ = pq.Dequeue();

                count++;
                nextCard++;
            }
        }

        return true;
    }


    // 2389. Longest Subsequence With Limited Sum
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        Array.Sort(nums);
        var ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            var count = 0;
            var sum = 0;
            var j = 0;
            while (j < nums.Length)
            {
                sum += nums[j];
                if (sum <= queries[i])
                    count++;
                else
                    break;

                j++;
            }
            ans[i] = count;
        }
        return ans;
    }


    // 678. Valid Parenthesis String
    public bool CheckValidString(string s)
    {
        var leftMin = 0;
        var leftMax = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                leftMin++;
                leftMax++;
            }
            else if (s[i] == ')')
            {
                leftMin--;
                leftMax--;
            }
            else
            {
                leftMin--;
                leftMax++;
            }

            if (leftMax < 0)
                return false;

            if (leftMin < 0)
                leftMin = 0;
        }

        return leftMin == 0;
    }


    // 1663. Smallest String With A Given Numeric Value
    public string GetSmallestString(int n, int k)
    {
        var chars = new char[n];
        Array.Fill(chars, 'a');
        var sum = chars.Length;

        for (int i = chars.Length - 1; i >= 0; i--)
        {
            while (chars[i] - 'a' < 25 && sum < k)
            {
                chars[i]++;
                sum++;
            }
            if (sum == k)
                break;
        }

        return new string(chars);
    }
}
