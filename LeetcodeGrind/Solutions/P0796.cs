namespace LeetcodeGrind.Solutions;

// 796. Rotate String
public class P0796
{
    public bool RotateString(string s, string goal)
    {
        return s.Length == goal.Length &&
               (s + s).Contains(goal);
    }
}
