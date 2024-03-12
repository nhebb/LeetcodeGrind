using System.Text;

namespace LeetcodeGrind.Solutions;

// 791. Custom Sort String
public class P0791
{
    public string CustomSortString(string order, string s)
    {
        var d = new Dictionary<char, int>();
        var stack = new Stack<char>();
        for (int i = order.Length - 1; i >= 0; i--)
        {
            stack.Push(order[i]);
            d[order[i]] = 0;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (d.TryGetValue(s[i], out int value))
            {
                d[s[i]] = ++value;
            }
        }

        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (!d.ContainsKey(s[i]))
            {
                sb.Append(s[i]);
            }
            else
            {
                var c = stack.Peek();
                sb.Append(c);
                d[c]--;
                if (d[c] == 0)
                {
                    _ = stack.Pop();
                }
            }
        }

        return sb.ToString();
    }
}
