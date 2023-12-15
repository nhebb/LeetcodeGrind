namespace LeetcodeGrind.Solutions;

// 1784. Check if Binary String Has at Most One Segment of Ones
public class P1784
{
    public bool CheckOnesSegment(string s)
    {
        return s.Split('0', StringSplitOptions.RemoveEmptyEntries).Length == 1;
    }
}
