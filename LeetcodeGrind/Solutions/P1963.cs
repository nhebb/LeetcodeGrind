namespace LeetcodeGrind.Solutions;

// 1963. Minimum Number of Swaps to Make the String Balanced
public class P1963
{
    public int MinSwaps(string s)
    {
        // This solution is based on the following observation
        // (not my own):
        // mismatches: 0, 1, 2, 3, 4, 5, 6, 7, ...
        // swaps:      0, 1, 1, 2, 2, 3, 3, 4, ...

        var stack = new Stack<char>();
        var mismatch = 0;

        foreach (var c in s)
        {
            if (c == '[')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count > 0)
                    _ = stack.Pop();
                else
                    mismatch++;
            }
        }

        return (mismatch + 1) / 2;
    }
}
