namespace LeetcodeGrind.Solutions;

// 3174. Clear Digits
public class P3174
{
    public string ClearDigits(string s)
    {
        var stack = new Stack<char>(s.Length);
        var i = 0;

        while (i < s.Length)
        {
            if (!char.IsDigit(s[i]))
            {
                stack.Push(s[i]);
            }
            else if (stack.Count > 0)
            {
                _ = stack.Pop();
            }

            i++;
        }

        if (stack.Count == 0)
        {
            return "";
        }

        var result = stack.ToArray();
        Array.Reverse(result);
        return string.Join("", result);
    }
}
