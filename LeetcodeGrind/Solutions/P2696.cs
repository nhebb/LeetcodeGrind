namespace LeetcodeGrind.Solutions;

// 2696. Minimum String Length After Removing Substrings
public class P2696
{
    public int MinLength(string s)
    {
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (c == 'B' && stack.Count > 0 && stack.Peek() == 'A')
                _ = stack.Pop();
            else if (c == 'D' && stack.Count > 0 && stack.Peek() == 'C')
                _ = stack.Pop();
            else
                stack.Push(c);
        }

        return stack.Count;
    }
}
