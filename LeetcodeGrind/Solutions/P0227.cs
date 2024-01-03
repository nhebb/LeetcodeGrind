namespace LeetcodeGrind.Solutions;

// 227. Basic Calculator II
public class P0227
{
    public int Calculate(string s)
    {
        var ops = new Stack<char>();
        var vals = new Stack<int>();

        s = s.Replace(" ", "");
        s = s.Replace("+", ",+,");
        s = s.Replace("-", ",-,");
        s = s.Replace("*", ",*,");
        s = s.Replace("/", ",/,");

        var tokens = s.Split(',', StringSplitOptions.RemoveEmptyEntries);

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out var val))
            {
                vals.Push(val);

                // Do multiplication and divisions as they come up
                if (ops.Count > 0)
                {
                    if (ops.Peek() == '*')
                    {
                        _ = ops.Pop();
                        var val1 = vals.Pop();
                        var val2 = vals.Pop();
                        vals.Push(val1 * val2);
                    }
                    else if (ops.Peek() == '/')
                    {
                        _ = ops.Pop();
                        var val1 = vals.Pop();
                        var val2 = vals.Pop();
                        vals.Push(val2 / val1);
                    }
                }
            }
            else
            {
                ops.Push(token[0]);
            }
        }

        var ops2 = new Stack<char>();
        while (ops.Count > 0)
        {
            ops2.Push(ops.Pop());
        }

        var vals2 = new Stack<int>();
        while (vals.Count > 0)
        {
            vals2.Push(vals.Pop());
        }

        while (ops2.Count > 0)
        {
            var op = ops2.Pop();
            if (op == '+')
            {
                vals2.Push(vals2.Pop() + vals2.Pop());
            }
            else
            {
                var val1 = vals2.Pop();
                var val2 = vals2.Pop();
                vals2.Push(val1 - val2);
            }
        }

        return vals2.Pop();
    }
}
