namespace LeetcodeGrind.Solutions;

// 1967. Number of Strings That Appear as Substrings in Word
public class P1967
{
    public int NumOfStrings(string[] patterns, string word)
    {
        var count = 0;
        foreach (var pattern in patterns)
        {
            if (word.Contains(pattern))
                count++;
        }
        return count;
    }
}
