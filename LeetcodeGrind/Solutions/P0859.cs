namespace LeetcodeGrind.Solutions;

// 859. Buddy Strings
public class P0859
{
    public bool BuddyStrings(string s, string goal)
    {
        if (s.Length == 1 || s.Length != goal.Length)
            return false;

        var misMatches = new List<int>();
        for (int i = 0; i < s.Length; i++)
            if (s[i] != goal[i])
                misMatches.Add(i);

        // edge case where we have to find any repeated character
        if (misMatches.Count == 0)
        {
            var arr = new int[26];
            foreach (var c in s)
            {
                arr[c - 'a']++;
                if (arr[c - 'a'] > 1)
                    return true;
            }
            return false;
        }

        if (misMatches.Count != 2)
            return false;

        if (s[misMatches[0]] != goal[misMatches[1]] ||
            s[misMatches[1]] != goal[misMatches[0]])
            return false;

        return true;
    }
}
