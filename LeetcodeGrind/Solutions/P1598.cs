using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1598. Crawler Log Folder
public class P1598
{
    public int MinOperations(string[] logs)
    {
        var stack = new Stack<string>();

        foreach (var log in logs)
        {
            if (log == "./")
            {
                continue;
            }
            else if (log == "../")
            {
                if (stack.Count > 0)
                {
                    _ = stack.Pop();
                }
            }
            else
            {
                stack.Push(log);
            }
        }

        return stack.Count;
    }
}

