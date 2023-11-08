namespace LeetcodeGrind.Solutions;

// 316. Remove Duplicate Letters
public class P0316
{
    public string RemoveDuplicateLetters(string s)
    {
        var stack = new Stack<char>();
        var visited = new HashSet<char>();
        var lastIndex = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            lastIndex[s[i] - 'a'] = i;
        }

        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (!visited.Contains(c))
            {
                while (stack.Count > 0 && stack.Peek() > c
                    && lastIndex[stack.Peek() - 'a'] > i)
                {
                    var skipped = stack.Pop();
                    visited.Remove(skipped);
                }
                visited.Add(c);
                stack.Push(c);
            }
        }
        var r = string.Join("", stack.Reverse());

        return string.Join("", stack.ToArray().Reverse());
    }
}
