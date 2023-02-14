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


    // TODO: Finish (or at least get started)
    // 402. Remove K Digits
    public string RemoveKdigits(string num, int k)
    {
        return num;
    }


    // 84. Largest Rectangle in Histogram
    public int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<int[]>();
        var maxArea = 0;

        for (int i = 1; i < heights.Length; i++)
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
            maxArea = Math.Max(maxArea, height * (heights.Length - index);
        }

        return maxArea;
    }
}
