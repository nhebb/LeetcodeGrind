namespace LeetcodeGrind.Solutions;

// 10. Regular Expression Matching
public class P0010
{
    public bool IsMatch(string s, string p)
    {
        // lol
        return System.Text.RegularExpressions.Regex.IsMatch(s, $"^{p}$");
    }
}
