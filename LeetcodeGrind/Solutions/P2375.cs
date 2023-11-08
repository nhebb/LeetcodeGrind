using System.Text;

namespace LeetcodeGrind.Solutions;

// 2375. Construct Smallest Number From DI String
public class P2375
{
    public string SmallestNumber(string pattern)
    {
        var sb = new StringBuilder();
        var stack = new StringBuilder();
        for (int i = 1; i <= pattern.Length + 1; i++)
        {
            stack.Append(i);
            if (i == pattern.Length + 1 || pattern[i - 1] == 'I')
            {
                var substr = string.Join(" ", stack.ToString().Reverse());
                sb.Append(substr);
                stack.Clear();
            }
        }
        return sb.ToString();
    }
}
