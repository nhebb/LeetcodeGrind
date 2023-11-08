namespace LeetcodeGrind.Solutions;

// 20. Valid Parentheses
public class P0020
{
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
}
