namespace LeetcodeGrind.Solutions;

// 1047. Remove All Adjacent Duplicates In String
public class P1047
{
    public string RemoveDuplicates(string s)
    {
        var stack = new Stack<char>();
        stack.Push(s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            if (stack.Count == 0 || s[i] != stack.Peek())
            {
                stack.Push(s[i]);
            }
            else
            {
                _ = stack.Pop();
            }
        }
        var result = stack.ToList();
        result.Reverse();
        return string.Join("", result);
    }
}
