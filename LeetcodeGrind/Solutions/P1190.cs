namespace LeetcodeGrind.Solutions;

// 1190. Reverse Substrings Between Each Pair of Parentheses
public class P1190
{
    public string ReverseParentheses(string s)
    {
        var chars = s.ToCharArray();
        var stack = new Stack<int>();

        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '(')
            {
                stack.Push(i);
            }
            else if (chars[i] == ')')
            {
                var left = stack.Pop();
                var right = i;
                while (left < right)
                {
                    (chars[left], chars[right]) = (chars[right], chars[left]);
                    left++;
                    right--;
                }
            }
        }

        return new string(chars).Replace("(", "")
                                .Replace(")", "");
    }
}
