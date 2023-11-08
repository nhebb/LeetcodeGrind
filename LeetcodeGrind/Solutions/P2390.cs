namespace LeetcodeGrind.Solutions;

// 2390. Removing Stars From a String
public class P2390
{
    public string RemoveStars(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
            if (c == '*')
                _ = stack.Pop();
            else
                stack.Push(c);

        var res = stack.Reverse();
        return string.Join("", res);
    }
}
