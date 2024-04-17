// 3110. Score of a String
namespace LeetcodeGrind.Solutions;

public class P3110
{
    public int ScoreOfString(string s)
    {
        var sum = 0;
        for (int i = 1; i < s.Length; i++)
        {
            sum += Math.Abs(s[i] - s[i - 1]);
        }

        return sum;
    }
}
