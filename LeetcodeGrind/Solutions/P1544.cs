using System.Text;

namespace LeetcodeGrind.Solutions;

// 1544. Make The String Great
public class P1544
{
    // stack
    public string MakeGood(string s)
    {
        var stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (stack.Count > 0 && Math.Abs(stack.Peek() - s[i]) == 32)
            {
                _ = stack.Pop();
            }
            else if (i < s.Length - 1 && Math.Abs(s[i] - s[i + 1]) == 32)
            {
                i++;
            }
            else
            {
                stack.Push(s[i]);
            }
        }

        var sb = new StringBuilder();
        while (stack.Count > 0)
        {
            sb.Append(stack.Pop());
        }

        return string.Join("", sb.ToString().Reverse());
    }

    // // while loop
    public string MakeGood2(string s)
    {
        if (s.Length == 1)
            return s;

        var sb = new StringBuilder();
        var bad = true;

        while (bad)
        {
            bad = false;
            var i = 0;

            while (i < s.Length - 1)
            {
                if (Math.Abs(s[i] - s[i + 1]) == 32)
                {
                    i += 2;
                    bad = true;
                }
                else
                {
                    sb.Append(s[i]);
                    i++;

                }
                if (i == s.Length - 1)
                {
                    sb.Append(s[i]);
                }
            }
            s = sb.ToString();
            sb.Clear();

            if (s.Length == 1)
                break;
        }

        return s;
    }
}
