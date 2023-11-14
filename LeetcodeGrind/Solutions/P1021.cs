using System.Text;

namespace LeetcodeGrind.Solutions;

// 1021. Remove Outermost Parentheses
public class P1021
{
    public string RemoveOuterParentheses(string s)
    {
        var count = 0;
        var sb = new StringBuilder();
        var start = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                count--;
            else
                count++;

            if (count == 0)
            {
                sb.Append(s.Substring(start + 1, i - start - 1));
                start = i + 1;
            }
        }
        return sb.ToString();
    }
}
