namespace LeetcodeGrind.Solutions;

// 2278. Percentage of Letter in String
public class P2278
{
    public int PercentageLetter(string s, char letter)
    {
        return s.Count(x => x == letter) * 100 / s.Length;
    }
}
