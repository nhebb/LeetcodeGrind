namespace LeetcodeGrind.Solutions;

// 3084. Count Substrings Starting and Ending with Given Character
public class P3084
{
    public long CountSubstrings(string s, char c)
    {
        long charCount = s.Count(x => x == c);
        return charCount * (charCount + 1) / 2;
    }
}
