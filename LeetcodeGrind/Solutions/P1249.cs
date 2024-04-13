using System.Text;

namespace LeetcodeGrind.Solutions;

// 1249. Minimum Remove to Make Valid Parentheses
public class P1249
{
    public string MinRemoveToMakeValid(string s)
    {
        var stack = new Stack<(int index, char val)>();
        var addList = new HashSet<int>();

        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c == '(')
            {
                stack.Push((i, c));
            }
            else if (c == ')' && stack.Count > 0 && stack.Peek().val == '(')
            {
                var item = stack.Pop();
                addList.Add(item.index);
                addList.Add(i);
            }
        }

        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != '(' && s[i] != ')')
            {
                sb.Append(s[i]);
            }
            else if (addList.Contains(i))
            {
                sb.Append(s[i]);
            }
        }

        return sb.ToString();
    }
}
