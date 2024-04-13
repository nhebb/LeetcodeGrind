namespace LeetcodeGrind.Solutions;

// 1614. Maximum Nesting Depth of the Parentheses
public class P1614
{
    public int MaxDepth(string s)
    {
        var stack = new Stack<char>();
        var depth = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                stack.Push(c);
                depth = Math.Max(depth, stack.Count);
            }
            else if (c == ')')
            {
                _ = stack.Pop();
            }
        }

        return depth;
    }
}
