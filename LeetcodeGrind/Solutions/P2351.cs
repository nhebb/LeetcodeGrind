namespace LeetcodeGrind.Solutions;

// 2351. First Letter to Appear Twice
public class P2351
{
    public char RepeatedCharacter(string s)
    {
        var hs = new HashSet<char>();
        char result = ' ';

        foreach (var c in s)
        {
            if (!hs.Add(c))
            {
                result = c;
                break;
            }
        }

        return result;
    }
}
