namespace LeetcodeGrind.Solutions;

// 2027. Minimum Moves to Convert String
public class P2027
{
    public int MinimumMoves(string s)
    {
        var count = 0;
        var i = s.IndexOf("X");

        if (i < 0)
        {
            return 0;
        }

        while (i < s.Length)
        {
            i += 3;
            count++;

            while (i < s.Length && s[i] == 'O')
            {
                i++;
            }
        }

        return count;
    }
}
