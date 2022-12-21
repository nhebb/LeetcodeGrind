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
}
