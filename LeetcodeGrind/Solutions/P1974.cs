namespace LeetcodeGrind.Solutions;

// 1974. Minimum Time to Type Word Using Special Typewriter
public class P1974
{
    public int MinTimeToType(string word)
    {
        // initialize result with 1 second for each letter
        int result = word.Length;
        var last = 'a';

        foreach (var c in word)
        {
            result += Math.Min(Math.Abs(c - last),
                               26 - Math.Abs(last - c));
            last = c;
        }

        return result;
    }
}
