namespace LeetcodeGrind.Solutions;

// TODO: 30. Substring with Concatenation of All Words
// This approach won't work. words[] has a length of up
// to 5000, which means there are 5000! possible permutations.
public class P0030
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        var ans = new List<int>();

        // store indices of each char in s in a dictionary to
        // shorten the substring lookup time
        var d = new Dictionary<char, List<int>>();
        for (char i = 'a'; i <= 'z'; i++)
            d[i] = new List<int>();

        var subLength = words.Length * words[0].Length;
        for (int i = 0; i < s.Length - subLength; i++)
            d[s[i]].Add(i);

        // create permutations of the words
        var perms = new List<string>();


        // check each permutation for existence in s, and if
        // found, add the index to the answer

        return ans;
    }
}

