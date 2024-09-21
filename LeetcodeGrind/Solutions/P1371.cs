namespace LeetcodeGrind.Solutions;

// 1371. Find the Longest Substring Containing Vowels in Even Counts
public class P1371
{
    public int FindTheLongestSubstring(string s)
    {
        // Bitmask solution. Copied with the hope of understanding
        // bitmasking in this context. (Spoiler: I still don't.)
        var vowels = new int[26];
        Array.Fill(vowels, -1);
        vowels[0] = 0;  // 'a' - 'a'
        vowels['e' - 'a'] = 1;
        vowels['i' - 'a'] = 2;
        vowels['o' - 'a'] = 3;
        vowels['u' - 'a'] = 4;

        var firstSeen = new int[32];
        Array.Fill(firstSeen, -1);
        firstSeen[0] = 0;

        var longest = 0;
        var current = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var x = vowels[s[i] - 'a'];

            // if x != -1, then it's a vowel
            if (x != -1)
                current ^= (1 << x);

            if (firstSeen[current] == -1)
                firstSeen[current] = i + 1;

            longest = Math.Max(longest, i + 1 - firstSeen[current]);
        }

        return longest;
    }
}
