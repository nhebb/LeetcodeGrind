namespace LeetcodeGrind.Solutions;

// 1668. Maximum Repeating Substring
public class P1668
{
    public int MaxRepeating(string sequence, string word)
    {
        var count = 0;
        var s = word;

        while (sequence.Contains(s))
        {
            count++;
            s += word;
        }
        return count;
    }
}
