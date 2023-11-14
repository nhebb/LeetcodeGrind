using System.Text;

namespace LeetcodeGrind.Solutions;

// 1061. Lexicographically Smallest Equivalent String
public class P1061
{
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        var parent = new int[26];
        for (int i = 0; i < parent.Length; i++)
            parent[i] = i;

        int Find(int x)
        {
            while (x != parent[x])
                x = parent[x];
            return x;
        }

        void Union(char x, char y)
        {
            var lower = Find(x - 'a');
            var higher = Find(y - 'a');
            if (lower > higher)
                (lower, higher) = (higher, lower);
            parent[higher] = lower;
        }

        for (int i = 0; i < s1.Length; i++)
            Union(s1[i], s2[i]);

        var sb = new StringBuilder();
        for (int i = 0; i < baseStr.Length; i++)
            sb.Append((char)('a' + Find(baseStr[i] - 'a')));

        return sb.ToString();
    }
}
