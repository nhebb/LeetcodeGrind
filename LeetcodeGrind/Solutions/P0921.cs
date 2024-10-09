namespace LeetcodeGrind.Solutions;

// 921. Minimum Add to Make Parentheses Valid
public class P0921
{
    public int MinAddToMakeValid(string s)
    {
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (stack.Count == 0 || c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Peek() == '(')
                {
                    _ = stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }
        }

        return stack.Count;
    }
}
