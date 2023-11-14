using System.Text;

namespace LeetcodeGrind.Solutions;

// 1768. Merge Strings Alternately
public class P1768
{
    public string MergeAlternately(string word1, string word2)
    {
        var len = Math.Max(word1.Length, word2.Length);
        int i = 0;
        int j = 0;
        var sb = new StringBuilder(word1.Length + word2.Length);

        while (i < len)
        {
            if (i < word1.Length)
                sb.Append(word1[i]);
            if (j < word2.Length)
                sb.Append(word2[j]);
            i++;
            j++;
        }

        return sb.ToString();
    }

    // LINQ version
    public string MergeAlternatelyLinq(string word1, string word2)
    {
        // With LINQ, C# treats strings as char arrays, so c1 is each
        // character in word1, and c2 is each character in word2.
        return string.Join("", word1.Zip(word2, (c1, c2) => c1 + c2));
    }
}
