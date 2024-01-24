namespace LeetcodeGrind.Solutions;

// 2546. Apply Bitwise Operations to Make Strings Equal
public class P2546
{
    public bool MakeStringsEqual(string s, string target)
    {
        return s.Any(c => c == '1') == target.Any(c => c == '1');
    }
}
