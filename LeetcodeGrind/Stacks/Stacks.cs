﻿using LeetcodeGrind.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Stacks;

public class Stacks
{
    // 20. Valid Parentheses
    public bool IsValid(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) { return true; }
        if (s.Length % 2 == 1) { return false; }

        var stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '{' || c == '[' || c == '(')
            {
                stack.Push(c);
            }
            else if (stack.Count == 0)
            {
                return false;
            }
            else
            {
                var oldChar = stack.Pop();
                if ((oldChar == '{' && c != '}')
                    || (oldChar == '[' && c != ']')
                    || (oldChar == '(' && c != ')'))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }


    // 739. Daily Temperatures
    public int[] DailyTemperatures(int[] temperatures)
    {
        var days = new int[temperatures.Length];
        var stack = new Stack<int>();

        for (int cur = 0; cur < temperatures.Length; cur++)
        {
            while (stack.Count > 0 &&
                   temperatures[cur] > temperatures[stack.Peek()])
            {
                var prev = stack.Pop();
                days[prev] = cur - prev;
            }

            stack.Push(cur);
        }

        return days;
    }


    // 853. Car Fleet
    public int CarFleet(int target, int[] position, int[] speed)
    {
        // convert position to remaining distance
        for (int i = 0; i < position.Length; i++)
            position[i] = target - position[i];

        // sort ascending by remaining distance with
        // speed sorted in parallel array
        Array.Sort(position, speed);

        // create an array of travel times for each
        // car to reach the target
        var times = new double[position.Length];
        for (int i = 0; i < position.Length; i++)
            times[i] = position[i] / (double)(speed[i]);

        // a car cannot go faster than the car ahead of it, 
        // so set the travel time to the max of itslef and
        // the previous car
        for (int i = 1; i < times.Length; i++)
            times[i] = Math.Max(times[i - 1], times[i]);

        // Count the distinct time groups (fleets)
        return times.Distinct().Count();
    }


    // TODO: 402. Remove K Digits
    public string RemoveKdigits(string num, int k)
    {
        return num;
    }


    // 84. Largest Rectangle in Histogram
    public int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<int[]>();
        var maxArea = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            var startIndex = i;
            while (stack.Count > 0 && stack.Peek()[1] > heights[i])
            {
                var rect = stack.Pop();
                var index = rect[0];
                var height = rect[1];
                maxArea = Math.Max(maxArea, height * (i - index));
                startIndex = index;
            }
            stack.Push(new int[] { startIndex, heights[i] });
        }

        while (stack.Count > 0)
        {
            var rect = stack.Pop();
            var index = rect[0];
            var height = rect[1];
            maxArea = Math.Max(maxArea, height * (heights.Length - index));
        }

        return maxArea;
    }


    // 71. Simplify Path
    public string SimplifyPath(string path)
    {
        var stack = new Stack<string>();
        var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

        foreach (var segment in segments)
        {
            if (segment == ".")
                continue;

            if (segment != "..")
                stack.Push(segment);
            else if (stack.Count > 0)
                _ = stack.Pop();
        }

        return "/" + string.Join('/', stack.Reverse());
    }


    // 2390. Removing Stars From a String
    public string RemoveStars(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
            if (c == '*')
                _ = stack.Pop();
            else
                stack.Push(c);

        var res = stack.Reverse();
        return string.Join("", res);
    }


    // 445. Add Two Numbers II
    public ListNode? AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var s1 = new Stack<int>();
        var s2 = new Stack<int>();
        ListNode? nextNode = null;

        while (l1 != null)
        {
            s1.Push(l1.val);
            l1 = l1.next;
        }
        while (l2 != null)
        {
            s2.Push(l2.val);
            l2 = l2.next;
        }

        var carry = 0;
        ListNode? node = null;
        while (s1.Count > 0 || s2.Count > 0)
        {
            var num1 = s1.Count > 0 ? s1.Pop() : 0;
            var num2 = s2.Count > 0 ? s2.Pop() : 0;
            var sum = num1 + num2 + carry;
            var val = sum % 10;
            carry = sum / 10;
            node = new ListNode(val);
            node.next = nextNode;
            nextNode = node;
        }

        if (carry > 0)
        {
            node = new ListNode(carry);
            node.next = nextNode;
        }

        return node;
    }
}
