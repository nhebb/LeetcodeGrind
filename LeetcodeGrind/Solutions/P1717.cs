namespace LeetcodeGrind.Solutions;

// 1717. Maximum Score From Removing Substrings
public class P1717
{
    public int MaximumGain(string s, int x, int y)
    {
        var score = 0;
        var stack = new Stack<char>();
        var first = x >= y ? 'a' : 'b';
        var second = x >= y ? 'b' : 'a';
        var firstScore = x >= y ? x : y;
        var secondScore = x >= y ? y : x;

        stack.Push(s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == second && stack.Count > 0 && stack.Peek() == first)
            {
                score += firstScore;
                _ = stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
        }

        if (stack.Count == 0)
            return score;

        var reversed = stack.ToArray();
        s = string.Join("", reversed.Reverse());
        stack.Clear();

        stack.Push(s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == first && stack.Count > 0 && stack.Peek() == second)
            {
                score += secondScore;
                _ = stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
        }

        return score;
    }
}
