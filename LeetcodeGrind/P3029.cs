namespace LeetcodeGrind;

// 3029. Minimum Time to Revert Word to Initial State I
public class P3029
{
    public int MinimumTimeToInitialState(string word, int k)
    {
        // Since we can add any characters to the end of
        // the new string, create a wildcard substring
        // of length k and pretend we added the correct 
        // letters.
        var suffix = new string('*', k);
        var s = word[k..] + suffix;

        bool AreEqual()
        {
            for (int i = 0; i < word.Length; i++)
            {
                // If get to s[i] == '*', strings match.
                if (s[i] == '*')
                    return true;
                else if (word[i] != s[i])
                    return false;
            }
            return true;
        }

        var time = 1;
        while (!AreEqual())
        {
            s = s[k..] + suffix;
            time++;
        }

        return time;
    }
}
